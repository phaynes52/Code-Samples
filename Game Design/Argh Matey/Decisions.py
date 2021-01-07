#decisions.py
import time
import random
import threading

drinks = 0
health = 100
oppHealth = 100
strength = 5
oppStrength = 5
oppQuickness = 8
hat = False
sword = False
inventory = []
save = []
tutorial = True
fightLock = threading.Lock()
response = ""
bearSlain = False

def stay_or_go(staygo):
    while staygo not in ["stay home", "go out"] :
        staygo = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n").lower()
    if staygo == "stay home":
        print("You text your friends that you have scurvy. No one responds, but they're definitely making fun of you in their other groupchat you're not allowed in. You spend the night wondering if they're having fun and questioning if they really like you. Goodbye.")
        quit()
    elif staygo == "go out":
        raw_input("You text your friends and look for some pirate themed clothing. You do a pretty good job. When your friends show up, you're the only one in costume. They all laugh and tell you its too late to change now.  \n(press Enter to continue)")

    return

def danceFloor(visit):
    if visit == 0 :
        raw_input("You walk starboard to the dancefloor. On your way there, a couple people try to order drinks from you because they think you work there.")
        dance = raw_input("Your friends all start dancing. Do you join in? \n( Bust a move / Go to the bar / Make a dance circle ): ").lower()
    if visit == 1:
        dance = raw_input("You find your friends dancing. Do you join in? \n( Bust a move / Go to the bar / Make a dance circle ): ").lower()
    while dance not in [ "bust a move", "go to the bar", "make a dance circle"]:
        dance = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Bust a move / Go to the bar / Make a dance circle ): ").lower()
    while dance == "bust a move":
        dance = raw_input("You pull out a sick dance move. Your friends are not impressed. \n( Bust a move / Go to the bar / Make a dance circle ): ").lower()
    if dance == "go to the bar" :
        raw_input("You walk over to the bar and get the bartenders attention.")
        theBar()
    elif dance == "make a dance circle" :
        raw_input("You start pushing people away and make a dance circle. You're standing in the middle of it. \n")
        danceCircle()
    return

def theBar():
    global drinks
    if drinks > 10 :
        print("You have had too much to drink. The night gets hazy, and next thing you know you wake up on a dingy in the middle of a small lake downtown. You're pants and wallet are gone, but you've acquired a pirate hat and the helm of a ship. You check your phone and see you have 1000 texts and videos of you thiking you're a pirate are all over the internet. Try to keep yourself in control next time. Goodbye.")
        quit()
    if drinks < 2 :
        answer = raw_input("( Order a beer / Order a Rum / Go to the Dancefloor ): ").lower()
    elif 1 < drinks < 5 :
        answer = raw_input("The buzzing sound you've been hearing grows louder. No one else seems to notice. \n( Order a beer / Order a Rum / Go to the Dancefloor / Investigate the sound ): ").lower()
    elif 4 < drinks < 8 :
        answer = raw_input("The buzzing sound you've been hearing grows very loud. Still no one seems to notice. \n( Oredr *burp* bere / Oedrr a Rmu / to go Dncfaloeor / Invsgat the soun ): ").lower()
    elif 7 < drinks < 11 :
        answer = raw_input("The buzzing sound becomes defeaning. You can't believe no one else is annoyed by it.. \n( bE *burp* r / MRu / Dnce / vstgate ): ").lower()
    if answer in ["order a beer", "oredr *burp* bere", "be *burp* r"]  :
        drinks = drinks + 1
        raw_input("*GLUG* *GLuG* *burp* *GLUG* ahhhhh how refreshing.")
        theBar()
    elif answer in ["order a rum", "oedrr a rmu", "mru"] :
        drinks = drinks + 2
        raw_input("*GULP* Geez do they use this stuff to clean the boat?")
        theBar()
    elif answer in ["go to the dancefloor", "to go dncfaloeor", "dnce" ] :
        danceFloor(1)
    elif answer in ["investigate the sound", "invsgat the soun", "vstgate"] :
        investigate(0)
    else:
        print("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n")
        theBar()
        return
    return
    
    
def danceCircle() :
    global health
    dance = raw_input("(Bust a move / chicken out): ").lower()

    while dance not in ["bust a move", "chicken out"]:
        dance = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Bust a move / Chicken out)").lower()
    if dance == "bust a move":
        print("You pull out a sick move. The crowd goes wild. You don't have anything left in the tank but the crowd wants more.\n")
        choice = ""
        while choice not in ["keep going", "give up the floor"]:
            choice = raw_input("(Keep going / Give up the floor): ").lower()
            print("\n")
        if choice == "keep going" :
            raw_input("You try to do a backflip (which you've never tried before) and land on your face. Everyone laughs. \n-5 health\n")
            health = health - 5
            if health <= 0:
                print("Your health is critically low and you can no longer continue You pass out. Thank you for playing. Goodbye.")
                quit()
        elif choice == "give up the floor" :
            raw_input("You leave the circle and go catch your breath. Hard to be the center of attention all the time.")
    elif dance == "chicken out" :
        raw_input("You freeze up and run out of the circle. The crowd is angry. You got their hopes up only to crush them. Their anger manifests and people start throwing things at you. It starts with ice, then bottles, then chairs. It hurts. You should have just danced. \n-10 health\n")
        health = health - 10
        if health <= 0:
            print("Your health is critically low and you can no longer continue. You pass out. Thank you for playing. Goodbye.")
            quit()
    
    danceFloor(1)

    return

def investigate(visit) :
    if visit == 0 :
        choice = raw_input("You listen for the buzz and try to find where it's coming from. You push you're way through the bar as the buzz gets louder. You reach a broom closet and the buzz is so loud you can barely hear yourself think. \n( Enter the closet / Return to the bar / Return to the dancefloor ): ").lower()
    elif visit == 2 :
        choice = raw_input("The buzz gets louder as you close the door. You feel like it's asking you to go back in.\n( Enter the closet / Return to the bar / Return to the dancefloor ): ").lower()
    else:
        choice = raw_input("( Enter the closet / Return to the bar / Return to the dancefloor ): ").lower()
    if choice == "enter the closet":
        closet()
    elif choice == "return to the bar":
        theBar()
    elif choice == "return to the dancefloor":
        danceFloor(1)
    else:
        raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n")
        investigate(1)
    return

def closet():
    global hat
    global sword
    hatandsword = False

    while hat == False or sword == False :
 
        if hat == False and sword == False:
            choice = raw_input("You open the door and find an almost empty closet. Against the back wall is a singular table. A light shines down from above illuminating a pirate hat and a sword. The sound seems to be coming from the table but you don't know how. \n( Leave the closet / Take the sword / Put on the hat): ").lower()
        elif hat == True and sword == False:
            choice = raw_input("( Leave the closet / Take the sword ): ").lower()
        elif sword == True and hat == False:
            choice = raw_input("( Leave the closet / Put on the hat): ").lower()
        while choice not in ["leave the closet", "take the sword", "put on the hat"] :
            if hat == False and sword == False:
                choice = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Leave the closet / Take the sword / Put on the hat): ").lower()
            elif hat == True and sword == False:
                choice = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Leave the closet / Take the sword ): ").lower()
            elif sword == True and hat == False:
                choice = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Leave the closet / Put on the hat): ").lower()

        if choice == "leave the closet" :
            investigate(2)
        elif choice == "put on the hat":
            hat = True
        elif choice == "take the sword":
            sword = True
            inventory.append("Sword")

    raw_input("The buzzing sound stops. You can hear yourself think again. Outside of the closet things seem to be really picking up - the shanties have gotten louder and it sounds like they've turned on the wave pool.")
    hereWeGoMatey()

    return

def hereWeGoMatey():
    global drinks
    drinks = 0
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
        fight(50, 3, 4)
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
    global health
    raw_input("You grab a nondescript bowl of slop and a glass of beer from the galley and head to the sleeping cabin. The food isn't great but it gets the job done. You hit the hay ready for a big day tomorrow.")
    if health < 100:
        health = 100
        raw_input("Health restored to max of 100.")
    else:
        raw_input("Health at max value.")
    raw_input("The next day you wake up refreshed and head to the main deck to start the day.")
    landho()
    
def explore():
    global health
    global strength
    location = "main deck"
    timeout_start = time.time()
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
                inventory.append("apple")
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
                if "apple" in inventory :
                    raw_input("Prisoner: 'Thank you, sir! Thank you so much! Oh the taste of a fresh apple how I've missed this. Here, take this, I don't think I'll have much use for it anymore.' \n The prisoner hands you the sword from his belt. It appears to be of much finer quality than the one you took from the bar. You see the name Edgar Davies engraved on the blade.")
                    raw_input("+2 strength")
                    strength = strength + 2
                    inventory.append("Davies' sword")
                    location = raw_input("(Below Deck / Rest Up)").lower()
                else :
                    location = raw_input("Hmmm you don't seem to have an apple. Perhaps look around a bit more and see if you can find one. \n(Below Deck / Rest Up) ").lower()
            while location not in ["below deck", "rest up"] :
                print("Argh Matey why would you try to go there? \n")
                location = raw_input("(Below Deck / Rest Up) ").lower()
        if time.time() > (timeout_start + 120) or location == "rest up":
            print("You're exhausted from your exploring and decide to hit the hay. You head below deck to the sleeping cabin and get some shut eye.")
            break

    restup()

    return

def landho():
    raw_input("Pirate in the Crow's Nest: 'LAND HO!!!' ")
    raw_input("Captain Blackbreath: 'All hands on deck! Head the masts toward the coast!' \nCaptain Blackbreath walks over to you.")
    raw_input("Captain Blackbreath: 'Unfortunately this is where I must let ye off matey. Our crew is headed toward Cifuentes - a dangerous free city on the other side of that island. If I brought ye there they'd eat you alive. On this side of the island is a small group of British soldiers.  I'll ready a dingy and send you off to them. Hopefully their kind enough to help you.")
    theBritishAreComing

def theBritishAreComing():
    raw_input("You thank the captain for all he's done for you and he walks off to prepare your transport.")
    raw_input("Captain Blackbreath: 'Good luck out there. The British have never been kind to us, but I've got a good feeling about you.'")
    business = raw_input("You row to the island, and as soon as you step on shore you are greeted by a British soldier. \nSoldier: 'You there! Stop! This land belongs to Dunstan Irving Cornellius Kinsington III Duke of Charles Island and you are trespassing. State your business.' \n Explain yourself: ")
    duel = raw_input("Soldier: ' \"{}\"? You really think I'd believe that? What do you think I am? French? I'm a damn Baron of the British Empire! I will have none of this nonsense. Come with me.' \n(Go with the soldier / Draw sword) ".format(business)).lower()
    while duel not in ["go with the soldier", "draw sword"]:
        duel = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Go with the soldier / Draw sword) ").lower()
    if duel == "go with the soldier" :
        raw_input("Soldier: 'Good choice sir. May the crown have mercy on your wayward life.' \nThe soldier slaps some iron handcuffs on you and takes your shoes just to be a dick. You walk behind his horse for a few miles until you reach a small encampment on the interior of the island with a sign that reads Fort Montauk. As you enter the compound, you can hear a very faint buzz.")
        Montauk(0)
    elif duel == "draw sword" :
        raw_input("Soldier: 'Poor choice good sir. I shall vanquish you to the deepest rungs of Hell. Or maybe France.")
        fight(70, 6, 4)
        loot = raw_input("The soldier collapses to the ground bloodied from his wounds. \nSoldier: 'You shall rue the day you killed Edmund Kinsington Dingleberry IV Baron of... *cough*... *gargle*...' \n(Search body / Leave) ").lower()
        while loot not in ["search body", "leave"] :
             loot = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Search body / Leave) ").lower()
        if loot == "search body" :
            raw_input("You find a small gold piece and put it in your pocket. \nYou also take the soldiers gloves giving you a better grip on your sword. \n+2 strengh")
            inventory.append("gold piece")
            strength = strength + 1
        raw_input("You look up and down the coast and see nothing in either direction. To the Northwest you see a small trail carved into the treeline and decide to follow that.")
        fork(0)
    return 

def fork(visit):
    if visit == 0:
        fork = raw_input("You walk through the jungle for about a quarter mile when you come across a fork in the road. There is nothing to indicate which direction to go. \n(Left / Right)").lower()
    else:
        fork = raw_input("You return to the fork in the road. \n(Left / Right)").lower()
    while fork not in ["left", "right"] :
      fork = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Left / Right) ").lower()
    if fork == "left" :
        forkleft()
    elif fork == "right" :
        forkright()
    return

def forkleft():
    fall = raw_input("You take the left path and walk about half a mile before you reach a clearing. In the middle is a small lake fed into by a magnificent waterfall. From the other end of the lake you think you see a small path leading behind the waterfall. \n(Investigate the path / Turn around) ").lower()
    while fall not in ["investigate the path", "turn around"]:
        fall = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Investigate the path / Turn around) ").lower()
    if fall == "investigate the path" :
        waterfall()
    elif fall == "turn around" :
        fork(1)

def waterfall() :
    global strength
    global bearSlain
    if bearSlain == False :
        raw_input("You follow the path and find a small cave behind the waterfall. Inside, the sunlight shines through a small hole in the ceiling illuminating an ornate sword.")
        bear = raw_input("As you apporach, you hear something rustle on the ground. You look down and realize that you were so focused on the sword that you failed to realize the giant bear in the cave. You can only assume that the English imported it and it escaped from their compound or something equally crazy to explain the carribean Grizzly Bear in front of you. You decide that despite the bear, you have to have that sword. \n(Sneak around / Attack) ").lower()
        while bear not in ["sneak around", "attack"]:
            bear = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Sneak around / Attack) ").lower()
        if bear == "sneak around" :
            raw_input("You try to sneak around the bear but accidentally step on it's paw. It roars awake and swipes at you, making a small gash in your left leg. \n-10 health")
            health = health - 10
            if health < 1 :
                print("The strike from the bear is too much for you to handle. You succumb to your injuries as the bear feeds on your body then goes back to sleep. Thank you for playing. Goodbye.")
                quit()
            raw_input("The bear stands up. It turns to face you and lets out a roar directly into your face. You draw your sword and prepare for battle. \n(Press enter to begin fight)")
            fight(150, 10, 4)
        elif bear == "attack" :
            raw_input("You plunge your sword into the bear while it sleeps and land a strong hit. \n15 damage dealt")
            raw_input("The bear roars awake and stands up to face you. It stands up on its hind legs letting out another great roar. It comes down to face you, pawing at the ground as it prepares to fight. \n(Press enter to begin fight)")
            fight(135, 10, 4)
        raw_input("The bear lets out one final roar and falls to the ground. You step over the bear triumphantly and grab the sword. \n+3 strength")
        strength = strength + 2
        bearSlain = True
        drink = raw_input("You exit the cave and take a minute to sit on the edge of the path near the waterfall and catch your breath. You're very thirsty. \n(Drink from the waterfall / Pass) ").lower()
        while drink not in ["drink from the waterfall", "pass"]:
            bear = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Drink from the waterfall / Pass) ").lower()
        if drink == "drink from the waterfall" :
            health = min(100, health + 30)
            raw_input("*Glug* *Glug* *Glug* Ahhhhhhhhhh \nHealth restored to {}".format(health))
        if drink == "pass" :
            health = min(100, health + 15)
            raw_input("You decide you're not that thirsty and take in the scenery. \nHealth restored to {}".format(health))
        raw_input("You see the sun starting to set and figure it's time to get back on the road. You walk back the way you came.")
    else:
        raw_input("You walk up the path and see the cave you entered before. Inside sits the slain bear. You return back down the path.")
        raw_input("You decide you've seen all there is to see here and head back toward the main path.")

    fork(1)

def Montauk(entry) :

    if entry == 0 :
        pass
        #enter as a prisoner of the british

    return



def fight(opph, opps, oppq):
    global tutorial
    global strength
    global health
    global oppHealth
    global oppStrength
    global oppQuickness
    oppHealth = opph
    oppStrength = opps
    oppQuickness = oppq

    if tutorial == True :
        tutorial = False
        combatTutorial()

    attackThread = threading.Thread(target = attack)
    defendThread = threading.Thread(target = defend)

    print("Fight! \n")
    
    attackThread.start()
    defendThread.start()

    attackThread.join()
    defendThread.join()

    if health < 1 :
        print("You fought valiantly, but ultimately your swordsmanship was not enough to win the battle. You never pictured this is how it would end, but as you bleed out you feel an overwhelming peace and come to acceptance. Thank you for playing. Goodbye.")
        quit()

    return

def attack():
    global strength
    global health
    global oppHealth

    while( health > 0 and oppHealth > 0) :
        base = random.randrange(1, strength)
        strikemult = random.randrange(1, 4)
        jabmult = random.randrange(0,2)
        extra = random.randrange(0,6)
        fightLock.acquire()
        attack = raw_input().lower()
        hit = random.randrange(0, 100)

        if attack not in ["strike", "jab"] :
            fightLock.release()
            continue

        if attack == "strike" :
            damage = base*strikemult + extra
        
        elif attack == "jab" :
            damage = base*jabmult + extra

        if( hit < 25 or damage == 0 or attack not in ["strike", "jab", "dodge"]):
            print("Miss! \n")

        else :
            print("Hit! \n{} damage dealt \n".format(damage))
            oppHealth = oppHealth - damage
            if oppHealth > 0 :
                print("Opponents health is {} \n".format(oppHealth))

        fightLock.release()

    return

def defend():
    global strength
    global health
    global oppHealth
    global oppStrength
    global oppQuickness

    while( health > 0 and oppHealth > 0) :
        time.sleep(random.randrange(oppQuickness, oppQuickness+3))
        fightLock.acquire()
        start = time.time()
        response = raw_input("\nYou're being attacked! \n").lower()
        stop = time.time()
        if ( health > 0 and oppHealth > 0) : 
            print("\nYou're being attacked! \n \n").lower()
            if response == "dodge" and (stop - start) < 2.1:
                print("Successful dodge! \n")
            else :
                attack = random.randrange(0,2)
                base = random.randrange(1, oppStrength)
                strikemult = random.randrange(1, 4)
                jabmult = random.randrange(0,2)
                extra = random.randrange(0,6)

                if attack == 0 :
                    damage = base*strikemult + extra
            
                elif attack == 1 :
                    damage = base*jabmult + extra

                print("You've been hit! \n{} damage taken \n".format(damage))
                health = health - damage
                if health > 0 :
                    print("Your health level is {} \n".format(health))
        fightLock.release()

    return

def combatTutorial() :
    global tutorial
    tutorial = False
    raw_input("Woah easy now warrior. I can't send you into battle unprepared. Let me show you the ropes. \nAt all times you may type any of three commands: \n")
    raw_input("    1. jab (quick attack that deals light damage) \n")
    raw_input("    2. strike (strong attack that deals moderate damage) \n")
    raw_input("    3. dodge (used to avoid enemy attacks - must be entered within two seconds of an enemy attack prompt to succesfully dodge) \n")
    raw_input("Got it? Let's try that out. Whenever you're ready hit enter to begin the fight.")
    return
         