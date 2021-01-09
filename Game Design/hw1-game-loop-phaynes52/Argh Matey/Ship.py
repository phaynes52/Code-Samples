#ship.py

import config
import Fight
import Island


def hereWeGoMatey():
    config.drinks = 0
    raw_input("You open the door of the closet and are greeted by the blinding light of day. The smell of salty sea air hits your nostrils just as a splash of salt water slaps across your face. \n'What the hell? How long was I in there?'")
    raw_input("The bar seems to have become an actual pirate ship. On an actual ocean. You don't remember reading about this when you googled it. Your friends are nowhere to be found.")
    raw_input("Everyone on the ship is dressed like a pirate. I guess the bar closed and only the staff is left?")
    raw_input("You pull out your phone to call an uber but you don't have any service. Also, you're not sure if Uber does boats. You walk up to a staff member to ask how to get home.")
    raw_input("Pirate: 'wut thee 'ell er u doin ere? u just come from the cap'in's cabin? lit'l stowaway, eh? think ur hot stuff eh? ur not mate.'")
    raw_input("There's something seriously off about this guy. You're starting to think somethings up here.")
    duel = raw_input("Pirate: 'I'm takin' you to the Cap'in. 'e'll know wut to do with ya. \n(Go with the pirate / Draw sword) ").lower()
    while duel not in ["go with the pirate", "draw sword"] :
        duel = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Go with the pirate / Draw sword)")
    if duel == "draw sword" :
        raw_input("Pirate: 'Oh lit'l ninny got uh sword eh? Think u can beat me eh? I'll teach u some manners.'")
        raw_input("The pirate draws his sword and prepares to fight")
        Fight.fight(50, 3, 4)
        raw_input("Pirate: 'Ok! Ok! I yield! I yield! U damn near killed me. I like th'is one he's got sum spunk! Please, let me introduce you to the Cap'in. I'm sure he can help u out mate.'")
    raw_input("The pirate leads you back through the door that you came out of earlier, but this time it's differrent inside. The closet has gotten much larger now and looks more like an office. At the back of the room there's a desk and behind it a burly, weathered man with long black hair, a beard down to his chest, and rotten teeth.")
    raw_input("The man behind the desk addresses you: 'Arggggggggh.... You with the English? No. You be dressed too stupid to be one of them. What r u doin in me ship?'")
    story = raw_input("Explain yourself: ")
    raw_input("Captain Blackbreath: ' \"{}\"? Argh seems pretty far fetched to me, but I've heard far more outlandish in these waters. Make youself at home lad. We'll get you to shore.' ".format(story))
    decision = raw_input("You thank Captain Blackbreath and walk back out amongst the pirates. \n( Rest up / Explore the ship )").lower()
    while decision not in {"rest up", "explore the ship"}:
        decision = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n (Rest up / Explore the ship)").lower()
    if decision == "rest up" :
        restup()
    elif decision == "explore the ship" :
        explore()
    return

def restup():
    raw_input("You grab a nondescript bowl of slop and a glass of beer from the galley and head to the sleeping cabin. The food isn't great but it gets the job done. You hit the hay ready for a big day tomorrow.")
    if config.health < 100:
        config.health = 100
        raw_input("Health restored to max of 100.")
    else:
        raw_input("Health at max value.")
    raw_input("The next day you wake up refreshed and head to the main deck to start the day.")
    Island.landho()
    
def explore():
    location = "main deck"
    timeout_start = config.time.time()
    while location in ["main deck", "below deck", "observation deck", "galley", "brig"] :
        if location == "main deck" :
            location = raw_input("You stand on the main deck of the ship. Looking out over the side of the boat there's nothing but ocean as far as the eye can see. In the distance you hear a few members of the crew talking about how it's been forever since they made someone walk the plank. Maybe stay away from them. (You have 2 minutes to explore the ship) \n(Observation Deck / Below Deck / Rest Up) ").lower()
            while location not in ["below deck", "observation deck", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Observation Deck / Below Deck / Rest Up) ").lower()
        elif location == "below deck":
            location = raw_input("You walk down the steps below deck. It smells like death. Like, oh my god, how can it smell this bad? In the corner of the room you see a few pirates playing poker.\n( Play Poker / Main Deck / Brig / Galley / Rest Up) ").lower()
            while location not in ["main deck", "galley", "brig", "rest up", "play poker"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Play Poker / Main Deck / Galley / Brig / Rest Up) ").lower()
            if location == "play poker" :
                print("You ask if you can join. \n")
                raw_input("Pirate: 'Piss off mate, private game. Besides, letting you play would be way too much work.' \nNote taken.")
                location = raw_input("(Main Deck / Brig / Galley / Rest Up)").lower()
            while location not in ["main deck", "galley", "brig", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Main Deck / Galley / Brig / Rest Up) ").lower()
        elif location == "observation deck":
            location = raw_input("You stand on top of the observation deck. There's a telescope at the bow. You can see the whole ship from here - it's filthy. \n(Use Telescope / Main Deck / Rest Up) ").lower()
            while location not in ["main deck", "rest up", "use telescope"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Use Telescope / Main Deck / Rest Up) ").lower()
            if location == "use telescope" :
                location = raw_input("You look out at the ocean but can't see anything but water. Just as you're about to leave you see a whale breach. Nice. \n(Main Deck / Rest Up) ")
            while location not in ["main deck", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Main Deck / Rest Up) ").lower()
        elif location == "galley":
            location = raw_input("You walk into the galley and see mostly empty cabinets. On the table you see a single apple. \n(Take apple / Below Deck / Rest Up) ")
            while location not in ["below deck", "take apple", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Take apple / Below Deck / Rest Up) ").lower()
            if location == "take apple" :
                config.inventory.append("apple")
                location = raw_input("Taken. \n(Below Deck / Rest Up)").lower()
            while location not in ["below deck", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Below Deck / Rest Up) ").lower()
        elif location == "brig":
            raw_input("You descend down a ladder into the bottom level of the ship. It is dank and dark. You can feel the misery seeping into your bones. The brig sits to the left of the ladder, and inside you see a singular huddled mass.")
            location = raw_input("Prisoner: 'Who are you? Down here to torment me again are you? No? You sure got some funny clothes on. You must not be with this crew. Please sir, I'm miserable down here. I don't think I'm long for this world. Do you have any food to spare? I haven't eaten in days.' \n( Give apple / Below Deck / Rest Up) ").lower()
            while location not in ["main deck", "give apple", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Give apple / Below Deck / Rest Up) ").lower()
            if location == "give apple" :
                if "apple" in config.inventory :
                    raw_input("Prisoner: 'Thank you, sir! Thank you so much! Oh the taste of a fresh apple how I've missed this. Here, take this, I don't think I'll have much use for it anymore.' \n The prisoner hands you the sword from his belt. It appears to be of much finer quality than the one you took from the bar. You see the name Edgar Davies engraved on the blade.")
                    raw_input("+2 strength")
                    config.strength = config.strength + 2
                    config.inventory.append("Davies' sword")
                    location = raw_input("(Below Deck / Rest Up)").lower()
                else :
                    location = raw_input("Hmmm you don't seem to have an apple. Perhaps look around a bit more and see if you can find one. \n(Below Deck / Rest Up) ").lower()
            while location not in ["below deck", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Below Deck / Rest Up) ").lower()
        if config.time.time() > (timeout_start + 120) or location == "rest up":
            print("You're exhausted from your exploring and decide to hit the hay. You head below deck to the sleeping cabin and get some shut eye.")
            break

    restup()

    return
