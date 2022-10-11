VAR myName = "Carrot"

->main1
->main2

=== main1 ===
Hello Sir how shall i adress you?
    + [Just Sir]
        ~ myName = "Sir"
        -> main2
    + [Carrot]
        ~ myName = "Carrot"
        -> main2
-> END

=== main2 ===
Fine by me {myName}. So what brings you here?
        + [I am looking for Peyote do you know where i may find some?]
            I think I saw some right below here.
            You should go take a look.
            -> END
        + [Oh nothing much I'll be gone imideatelly I was just looking for something]
            Fine by me have a nice day {myName}
            -> END
