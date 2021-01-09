#Montauk.py
import config
import Fight

def entry(visit) :
    if visit == 0 :
        raw_input("When you come to, you find yourself handuffed to a large iron post in a small room. By the door sits a guard who doesn't notice you woke up.")
        escape = raw_input("You examine your situation and decide you can either bribe the guard or try to trick him. \n(Bribe guard / Trick guard)").lower()
        while escape not in ["bribe guard", "trick guard"] :
            escape = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Bribe guard / Trick guard)").lower()
        if escape == "bribe guard" :
            if "gold piece" in config.inventory :
                raw_input("You get the guard's attention and offer him the gold piece you took earlier if he releases you.")
                raw_input("The guard accepts your offer and unshackles you from your post. You hand him the gold, and he offers you some bread and water. You take it happily and thank him for his help.")
                config.health = min(100, config.health + 30)
                raw_input("You drink the glass of water and eat the bread before leaving the room. \nHealth restored to {}".format(config.health))
            else :
                raw_input("You decide to bribe the guard but realize you don't have any gold, and you're pretty sure he doesn't take venmo. You're just gonna have to trick him.")
                escape = "trick guard"
        if escape == "trick guard" :
            raw_input("You start hyperventilating to get the guard's attention. He asks what's wrong with you. You start panting harder and writhing in pain. Your face is turning purple.")
            raw_input("The guard comes over to check on you. When he gets within range, you kick his legs out from underneath him. He falls hard to the ground and you quickly wrap him up and choke him out with your legs. Nicely done.")
            raw_input("You use your feet to grab the key off his belt and unlock the handcuffs with your teeth.")
        raw_input("Outside of the makeshift jail you can hear the buzz has gotten louder. You open the door and try to find it's source.")
    elif visit == 1 :
        raw_input("You push yourself into the fort. Once inside you duck behind the nearest building to hide yourself.")
        meal = raw_input("Beind the building is a small table. On top is a small canteen and a loaf of bread. \n(Take canteen and bread / Move on) ").lower()
        while meal not in ["take canteen and bread", "move on"] :
            meal = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Take canteen and bread / Move on)").lower()
        if meal == "take canteen and bread" :
            config.health = min(100, config.health + 30)
            raw_input("You drink the canteen and eat the bread. \nHealth restored to {}".format(config.health))
        if meal == "move on" :
            pass
        raw_input("Inside the fort the buzz has gotten louder. You peek your head around the corner and try to identify where it's coming from.")

    
    targetAcquired()

    return

def targetAcquired() :
    raw_input("You look in the direction of the buzz. It seems to be coming from the Officer's Quarters.")
    raw_input("You sneak toward the quarters, careful not to be deteced. With each step the buzz grows louder until it's pounding in your ears outside the door.")
    raw_input("When you enter the quarters, you're met with a large soldier guarding a door. He says something to you but you can't make it out over the sound eminating from the door.")
    raw_input("Whatever it was, it wasn't good. The soldier draws his sword and lunges at you.")
    raw_input("You step out of the way just in time and draw your sword.")
    Fight.fight(80, 4, 2)
    raw_input("The soldier collapses to the ground. You're too distracted by the buzz to even comprehend what's happening.")
    DunstanIrvingCorneliusKinsingtonIII()

    return

def DunstanIrvingCorneliusKinsingtonIII():
    raw_input("You open the door and the world goes quiet. Inside, the back wall shines bright with a shimmering wave of light. Nothing else is in the room except for one man facing the wall. Without turning to face you he address you.")
    raw_input("Man: 'Isn't it glorious Remington. Oh how I wonder what lies beyond this wall. I long to discover, but alas I'm afaid I never will.'")
    raw_input("The man takes a bite of an apple he is holding then lightly tosses the apple against the wall. Upon impact, it disappears. \nHe turns around to face you and is shocked to see you are not Remington.")
    raw_input("Man: 'Who the hell are you? What the devil are you doing in my quarters? Did Remington let -- ' ")
    raw_input("The man peaks around you to see Remington lying dead on the floor outside his room")
    raw_input("Man: 'Do you have any idea what you have done? Do you know who I am? I am Dunstan Irving Cornelius Kinsington, third of his name and Duke of Charles Island. You dare walk into MY fort, kill MY guard, and now stand before ME with no reverance for authority!? Explain yourself RIGHT NOW and MAYBE I will have the geneoristy to ALLOW YOU TO LIVE.'")
    explanation = raw_input("Explain yourself: ")
    raw_input("Dunstan Irving Cornelius Kinsington III: 'Have you no decency sir? I have come across some revolting figures in my time. But you, I dare say, are the most horrendoes of them all. As Duke of Charles Island - I hearby sentence you to die. If you have any debts to settle with the almight I suggest you do it now as this will be your last chance.' ")
    raw_input("Duke Kinsington unsheaths an intricately designed sword with a golden handle. He flourishes twice then points its tip at you.")
    raw_input("You take out your sword and prepare to duel. \n Any last words for Duke Kinsington? : ")
    Fight.fight(150, 10, 1)
    raw_input("You deliver a devastatin blow to Duke Kinsington. He staggers - dropping his sword.")
    raw_input("Dunstan Irving Cornelius Kinsington III: 'You think you're strong? You're weak. You can take me down, but this world will catch up with you. You're nothing. You're less than nothing. I am ROYALTY, and in that I will live forever. YOU WILL BE FORGOTTEN.' ")
    raw_input("Duke Kinsington staggers around the room in slow, plodding steps. He shouts 'LONG LIVE THE KING AND LONG LIVE THE EMPIRE' then tosses himself into the wall, disappearing.")
    finalChoice = raw_input("You stand in the room alone. Staring at the wall. You've come so far on your journey, and you're not sure you're ready for it to be over. You assume that on the other side of that wall is the bar you left earlier tonight. If you step through you return to your old life, your old friends, and all of this will be forgotten. But if you don't who knows what this world has in store for you? Do you belong here? Can you be a pirate forever? That choice is up to you. \n(Go home / Stay) ").lower()
    while finalChoice not in ["stay", "go home"] :
            finalChoice = raw_input("Please enter a choice from the options provided. \n(Go home / Stay)").lower()
    theEnd(finalChoice)
    return

def theEnd(choice):
    if choice == "go home" :
        raw_input("Playing pirate had been fun, but you don't think this world is built for you. You take a deep breath and step into the wall. For a half instant you feel yourself falling, then you land on top of a pile of half-eaten apples and Duke Kensington's body in the dumpster behind the bar.")
        raw_input("You pull yourself out of the dumpster, dust yourself off, and walk back into the bar. You check your phone and find you've been gone for a little over an hour.")
        raw_input("One of your friend finds you by the back of the bar.")
        raw_input("Friend: 'We've been looking all over for you where'd you go?' \nYou think about telling them, but decide to keep the story to yourself. Besides, they'd never believe you. \n  'Oh I was just exploring. Made some friends.' \nFriend: 'Sounds like you had a fun night. C'mon Allie got way too drunk we're gonna head out.")
        raw_input("You follow your friend back to the group and help carry Allie to the door. As your passing the bar she points to a picture hanging above the beer taps and says, drunkenly, 'hEy loOkf is't {}' ".format(config.name))
        raw_input("You turn to look and see a painting of Captain Blackbreath and the crew. Standing a few people to Captain Blackbreath's right is you with a smile on your face and a sword in your hand. I guess someone remembered after all.")
        print("Thank you for playing. Goodbye.")
        quit()
    elif choice == "stay" :
        raw_input("You debate over the choice for a while, but ultimately you decide to stay on the island. You know what's waiting for you back home - an uneventful life with friends you're not even sure you really like. But here you could be anything.")
        raw_input("You pick up the Duke's sword and take whatever you can find off of Remington. You leave through the front door and look around the fort for a way out.")
        raw_input("On your way out, you sneak into the treasury, quietly take out the guard, and stuff whatever you can in your pockets. You need something to start your new life.")
        raw_input("You find your way out of the fort without being caught and set out for Cifuentes and Captain Blackbreath. You're not entirely sure where it is, but you feel something pulling you West. You don't know what the rest of this life holds for you, but you're excited for the adventure.")
        print("Thank you for playing. Goodbye.")
        quit()
    return

