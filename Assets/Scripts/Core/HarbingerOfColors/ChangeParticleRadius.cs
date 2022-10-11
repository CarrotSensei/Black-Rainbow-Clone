using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ParticleSystem))]
public class ChangeParticleRadius : MonoBehaviour
{
    private ParticleSystem ps;
    public ParticleSystemShapeType shapeType = ParticleSystemShapeType.Donut;
    public float arc;
    public ParticleSystemShapeMultiModeValue arcMode = ParticleSystemShapeMultiModeValue.Random;
    public float arcSpread;
    public float arcSpeed;
    public float angle;
    public float radius = 0;
    public float radiusThickness;
    public ParticleSystemShapeMultiModeValue radiusMode = ParticleSystemShapeMultiModeValue.Random;
    public float radiusSpread;
    public float radiusSpeed;
    public float donutRadius;
    public float length;
    public Vector3 boxThickness;
    public ParticleSystemMeshShapeType meshShapeType;
    public float normalOffset;
    public float randomizeDirection;
    public float spherizeDirection;
    public float randomizePosition;
    
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRange = 25f;

    public float rateOverTime;
    public float startSize;
    public float startSpeed;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        var main = ps.main;
        //main.startSpeed = 0.1f;
        //main.startSize = 0.1f;
        //main.startLifetime = 0.1f;

        var emission = ps.emission;
        emission.rateOverTime = 0;

        var shape = ps.shape;
        shape.mesh = Resources.GetBuiltinResource<Mesh>("Capsule.fbx");
        
        radius = 0.0001f;
        startSize = 0.1f;
        donutRadius = 0.0001f;
        startSpeed = 0f;
    }

    
    private void FixedUpdate()
    {
        var main = ps.main;
        main.startSize = startSize;
        main.startSpeed = startSpeed;

        var shape = ps.shape;
        shape.shapeType = shapeType;
        shape.arc = arc;
        shape.arcMode = arcMode;
        shape.arcSpread = arcSpread;
        shape.arcSpeed = arcSpeed;
        shape.radius = radius;
        shape.radiusSpread = radiusSpread;
        shape.radiusSpeed = radiusSpeed;
        shape.radiusThickness = radiusThickness;
        shape.donutRadius = donutRadius;

        var emission = ps.emission;
        emission.rateOverTime = rateOverTime;

        /*
        if (Input.GetKey("e") && Timer.timeIsZero == false)
        {
            ExpandParticleRadius();
        }
        if (Input.GetKey("q") && Timer.timeIsZero == false)
        {
            ShrinkParticleRadius();
        }
        */
    }

    public void ExpandParticleRadius()
    {
        radius = Mathf.Clamp(radius + 0.4f, minRange, maxRange);
        rateOverTime = radius * 100;
        //startSize = Mathf.Clamp(radius / 100, 0, 0.1f);
        startSpeed = radius / 10;
    }

    public void ShrinkParticleRadius()
    {
        radius = Mathf.Clamp(radius - 0.4f, minRange, maxRange);
        rateOverTime = radius * 100;
        //startSize = Mathf.Clamp(radius / 100, 0, 0.1f);
        startSpeed = radius / 10;
    }

}
