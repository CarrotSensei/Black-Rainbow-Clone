Hello there! #speaker:left bird #portrait:left_bird_default #layout:left #audio:beep_1
-> main

=== main ===
How are you feeling today?
    +[happy]
        That make me feel <color=\#F8FF30>happy</color> as well! #portrait:left_bird_default
    +[sad]
        Oh, well that makes me <color=\#5B81FF>sad</color> too. #portrait:left_bird_default

- Don't trust him, he's <b><color=\#FF1E35>not</color></b> the real one. #speaker:right bird #portrait:right_bird_default #layout:right #audio:beep_3

Well do you have any more questions? #speaker:left bird #portrait:left_bird_default #layout:left #audio:beep_1
    +[yes]
        ->main
    +[no]
        Goodbye then!
        -> END