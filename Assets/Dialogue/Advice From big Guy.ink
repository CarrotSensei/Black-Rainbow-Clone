VAR myName = "Carrot"

->main1
->main2

=== main1 ===
Hello there small guy. May I procure what you name is?
    + [No Comment]
        ~ myName = "No Comment"
        -> main2
    + [Carrot]
        ~ myName = "Carrot"
        -> main3
-> END

=== main2 ===
Well then mr {myName}. How may I be of assistance to you?
    + [I am looking for clues to escape this place?]
        Clues you say....?
        Hmmmmmm....
        ...
        Well you know if I knew your name I may have been able to help.
        Sadly I don't.
        So tough luck kid.
        Don't come looking for me again.
        -> END


=== main3 ===
Well then mr {myName}. How may I be of assistance to you?
    +[I am looking for clues to escape this place?]
        Clues huh
        Well I may know of a way.
        First you need to collect at least 3 coins.
        Then you want to climb to the highest place possible and search for the exit there.
        Oh be carefull though some creatures local to this place seem to have gone mad.
        They attack anyone on sight.
        Don't be to alarmed though they can't see too far.
        Also they all seem to be walking back and forth non stop.
        Almost like a monkey that has been locked in a cage for ages.
        I'd be certainly cautious around them.
        -> END