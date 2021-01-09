#ArghMatey.py

import config
import Bar
import Fight
import Ship
import Island
import Montauk


start = raw_input("Last week, you and your friends got together and marathoned the entire Pirates of the Caribean series. About halfway through the third movie, one of them mentioned a pirate themed bar she had heard just opened up. You all excitedly made plans for the following Friday. Now, the day has come. You've been laying in bed all day - regretting you said you would go and debating whether or not you should tell them you have scurvy and continue playing red dead til 3 in the morning. \n ( Stay home / Go out ): ").lower()

Bar.stay_or_go(start)
        
raw_input( "You get to the bar. Outside there's a big ship-shaped sign that says The Ship in old-timey lettering. Beneath that, there's an even bigger bouncer with a fake parrot sitting on his shoulder. No one in line is in costume. You look ridiculous.")
config.name = raw_input("Bouncer: 'Ahoy Matey and welcome to The Ship! If you're on the list head in. If not, walk the plank. What's your name?' \nEnter your name: ")

raw_input("Bouncer: '{}, {}, {}. Ah! There it is! Head on in.'".format(config.name, config.name, config.name))
raw_input("As you walk past, the parrot on his shoulder squawks at you and lurches. I guess it was real after all. You say something about it to your friends but none of them saw it.")
raw_input("When you walk in, you are greeted by a sea shanty and a lively bar. In the background, you hear a dull buzzing sound.")

dance = ""
Bar.danceFloor(0)
