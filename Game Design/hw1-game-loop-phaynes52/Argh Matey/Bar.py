#decisions.py
import config
import Ship

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
    if config.drinks > 10 :
        print("You have had too much to drink. The night gets hazy, and next thing you know you wake up on a dingy in the middle of a small lake downtown. You're pants and wallet are gone, but you've acquired a pirate hat and the helm of a ship. You check your phone and see you have 1000 texts and videos of you thiking you're a pirate are all over the internet. Try to keep yourself in control next time. Goodbye.")
        quit()
    if config.drinks < 1 :
        answer = raw_input("( Order a beer / Order a Rum / Go to the Dancefloor ): ").lower()
    elif 0 < config.drinks < 5 :
        answer = raw_input("The buzzing sound you've been hearing grows louder. No one else seems to notice. \n( Order a beer / Order a Rum / Go to the Dancefloor / Investigate the sound ): ").lower()
    elif 4 < config.drinks < 8 :
        answer = raw_input("The buzzing sound you've been hearing grows very loud. Still no one seems to notice. \n( Oredr *burp* bere / Oedrr a Rmu / to go Dncfaloeor / Invsgat the soun ): ").lower()
    elif 7 < config.drinks < 11 :
        answer = raw_input("The buzzing sound becomes defeaning. You can't believe no one else is annoyed by it.. \n( bE *burp* r / MRu / Dnce / vstgate ): ").lower()
    if answer in ["order a beer", "oredr *burp* bere", "be *burp* r"]  :
        config.drinks = config.drinks + 1
        raw_input("*GLUG* *GLuG* *burp* *GLUG* ahhhhh how refreshing.")
        theBar()
    elif answer in ["order a rum", "oedrr a rmu", "mru"] :
        config.drinks = config.drinks + 2
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
            config.health = config.health - 5
            if config.health <= 0:
                print("Your health is critically low and you can no longer continue You pass out. Thank you for playing. Goodbye.")
                quit()
        elif choice == "give up the floor" :
            raw_input("You leave the circle and go catch your breath. Hard to be the center of attention all the time.")
    elif dance == "chicken out" :
        raw_input("You freeze up and run out of the circle. The crowd is angry. You got their hopes up only to crush them. Their anger manifests and people start throwing things at you. It starts with ice, then bottles, then chairs. It hurts. You should have just danced. \n-10 health\n")
        config.health = config.health - 10
        if config.health <= 0:
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
    while config.hat == False or config.sword == False :
 
        if config.hat == False and config.sword == False:
            choice = raw_input("You open the door and find an almost empty closet. Against the back wall is a singular table. A light shines down from above illuminating a pirate hat and a sword. The sound seems to be coming from the table but you don't know how. \n( Leave the closet / Take the sword / Put on the hat): ").lower()
        elif config.hat == True and config.sword == False:
            choice = raw_input("( Leave the closet / Take the sword ): ").lower()
        elif config.sword == True and config.hat == False:
            choice = raw_input("( Leave the closet / Put on the hat): ").lower()
        while choice not in ["leave the closet", "take the sword", "put on the hat"] :
            if config.hat == False and config.sword == False:
                choice = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Leave the closet / Take the sword / Put on the hat): ").lower()
            elif config.hat == True and config.sword == False:
                choice = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Leave the closet / Take the sword ): ").lower()
            elif config.sword == True and config.hat == False:
                choice = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n( Leave the closet / Put on the hat): ").lower()

        if choice == "leave the closet" :
            break
        elif choice == "put on the hat":
            config.hat = True
        elif choice == "take the sword":
            config.sword = True
            config.inventory.append("Sword")

    if choice == "leave the closet" :
            investigate(2)
    else :
        raw_input("The buzzing sound stops. You can hear yourself think again. Outside of the closet things seem to be really picking up - the shanties have gotten louder and it sounds like they've turned on the wave pool.")
        Ship.hereWeGoMatey()

    return