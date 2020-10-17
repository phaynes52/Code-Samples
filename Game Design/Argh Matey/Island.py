#Island.py
import Fight
import config
import Montauk

def landho():
    raw_input("Pirate in the Crow's Nest: 'LAND HO!!!' ")
    raw_input("Captain Blackbreath: 'All hands on deck! Head the masts toward the coast!' \nCaptain Blackbreath walks over to you.")
    raw_input("Captain Blackbreath: 'Unfortunately this is where I must let ye off matey. Our crew is headed toward Cifuentes - a dangerous free city on the other side of that island. If I brought ye there they'd eat you alive. On this side of the island is a small group of British soldiers.  I'll ready a dingy and send you off to them. Hopefully their kind enough to help you.")
    theBritishAreComing()

def theBritishAreComing():
    raw_input("You thank the captain for all he's done for you and he walks off to prepare your transport.")
    raw_input("Captain Blackbreath: 'Good luck out there. The British have never been kind to us, but I've got a good feeling about you.'")
    business = raw_input("You row to the island, and as soon as you step on shore you are greeted by a British soldier. \nSoldier: 'You there! Stop! This land belongs to Dunstan Irving Cornelius Kinsington III Duke of Charles Island and you are trespassing. State your business.' \n Explain yourself: ")
    duel = raw_input("Soldier: ' \"{}\"? You really think I'd believe that? What do you think I am? French? I'm a damn Baron of the British Empire! I will have none of this nonsense. Come with me.' \n(Go with the soldier / Draw sword) ".format(business)).lower()
    while duel not in ["go with the soldier", "draw sword"]:
        duel = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Go with the soldier / Draw sword) ").lower()
    if duel == "go with the soldier" :
        raw_input("Soldier: 'Good choice sir. May the crown have mercy on your wayward life.' \nThe soldier slaps some iron handcuffs on you and takes your shoes just to be a dick. You walk behind his horse for a few miles until you reach a small encampment on the interior of the island with a sign that reads FORT MANTAUK.")
        raw_input("As you approach the compound, you can hear a very faint but familiar buzz.")
        raw_input("Before you enter, the soldier blindfolds you and puts you on the back of his horse. As he walks the horse though camp you can hear muffled conversation. The soldier drops you down in an unknown location and knocks you out with the butt of his sword.")
        Montauk.entry(0)
    elif duel == "draw sword" :
        raw_input("Soldier: 'Poor choice good sir. I shall vanquish you to the deepest rungs of Hell. Or maybe France.")
        Fight.fight(70, 6, 4)
        loot = raw_input("The soldier collapses to the ground bloodied from his wounds. \nSoldier: 'You shall rue the day you killed Edmund Kinsington Dingleberry IV Baron of... *cough*... *gargle*...' \n(Search body / Leave) ").lower()
        while loot not in ["search body", "leave"] :
             loot = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Search body / Leave) ").lower()
        if loot == "search body" :
            raw_input("You find a small gold piece and put it in your pocket. \nYou also take the soldiers gloves giving you a better grip on your sword. \n+1 strengh")
            config.inventory.append("gold piece")
            config.strength = config.strength + 1
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
    return

def forkright() :
    raw_input("You follow the path to the right. It seems to be worn down from frequent travel. After walking about a mile into the forest you start to hear a faint but familiar buzz.")
    raw_input("You pick up the pace heading in the direction of the sound. Slowly, you see a gap in the trees starting to appear as the buzz grows louder.")
    raw_input("As you approach the gap you veer off the path preferring the secrecy of the trees. From the edge of the clearing you see a tall wooden wall concealing a small emcampment.")
    entry = raw_input("British soldiers stand guard on the top of the wall, and you notice a sign that reads FORT MONTAUK. \n(Approach the fort / Look for another entrance) ").lower()
    while entry not in ["approach the fort", "look for another entrance"] :
        entry = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Approach the fort / Look for another entrance) ").lower()

    if entry == "look for another entrance" :
        raw_input("You walk the perimeter of the fort being careful to stay out of sight. On the backside of the fort you notice that one piece of the wall is starting to weather away.")
        raw_input("You think you can probably pry it open enough to get yourself inside.")
        if config.strength > 7 :
            raw_input("You pull at the boards and open a gap just large enough to slide into the fort.")
            Montauk.entry(1)
        else:
            raw_input("You pull at the boards but you are not strong enough to make an opening. You cut your losses and circle back to the front of the fort.")
    raw_input("You walk up to the front of the fort and shout to the soldiers on top of the wall")
    raw_input("'Excuse me! I seem to have gotten lost in the jungle. Would you be so kind as to help me find my way home?'")
    raw_input("Soldier: 'OY! You lost mate? We'll help you alright. *laughs* Let him in men!' ")
    raw_input("The soldiers open the gates and you walk into the fort. \n'Thank you all so much I don't know wha--'")
    raw_input("One of the soldiers smacks a baton across the back of your head and you collapse unconscious.")
    Montauk.entry(0)
    return

def waterfall() :
    if config.bearSlain == False :
        raw_input("You follow the path and find a small cave behind the waterfall. Inside, the sunlight shines through a small hole in the ceiling illuminating an ornate sword.")
        bear = raw_input("As you apporach, you hear something rustle on the ground. You look down and realize that you were so focused on the sword that you failed to realize the giant bear in the cave. You can only assume that the English imported it and it escaped from their compound or something equally crazy to explain the carribean Grizzly Bear in front of you. You decide that despite the bear, you have to have that sword. \n(Sneak around / Attack) ").lower()
        while bear not in ["sneak around", "attack"]:
            bear = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Sneak around / Attack) ").lower()
        if bear == "sneak around" :
            raw_input("You try to sneak around the bear but accidentally step on it's paw. It roars awake and swipes at you, making a small gash in your left leg. \n-10 health")
            config.health = config.health - 10
            if config.health < 1 :
                print("The strike from the bear is too much for you to handle. You succumb to your injuries as the bear feeds on your body then goes back to sleep. Thank you for playing. Goodbye.")
                quit()
            raw_input("The bear stands up. It turns to face you and lets out a roar directly into your face. You draw your sword and prepare for battle. \n(Press enter to begin fight)")
            Fight.fight(150, 10, 4)
        elif bear == "attack" :
            raw_input("You plunge your sword into the bear while it sleeps and land a strong hit. \n15 damage dealt")
            raw_input("The bear roars awake and stands up to face you. It stands up on its hind legs letting out another great roar. It comes down to face you, pawing at the ground as it prepares to fight. \n(Press enter to begin fight)")
            Fight.fight(135, 10, 4)
        raw_input("The bear lets out one final roar and falls to the ground. You step over the bear triumphantly and grab the sword. \n+2 strength")
        config.strength = config.strength + 2
        config.bearSlain = True
        drink = raw_input("You exit the cave and take a minute to sit on the edge of the path near the waterfall and catch your breath. You're very thirsty. \n(Drink from the waterfall / Pass) ").lower()
        while drink not in ["drink from the waterfall", "pass"]:
            drink = raw_input("Shiver me timbers, who would try to do that??. Please enter a choice from the options provided. \n(Drink from the waterfall / Pass) ").lower()
        if drink == "drink from the waterfall" :
            config.health = min(100, config.health + 30)
            raw_input("*Glug* *Glug* *Glug* Ahhhhhhhhhh \nHealth restored to {}".format(config.health))
        if drink == "pass" :
            config.health = min(100, config.health + 15)
            raw_input("You decide you're not that thirsty and take in the scenery. \nHealth restored to {}".format(config.health))
        raw_input("You see the sun starting to set and figure it's time to get back on the road. You walk back the way you came.")
    else:
        raw_input("You walk up the path and see the cave you entered before. Inside sits the slain bear. You return back down the path.")
        raw_input("You decide you've seen all there is to see here and head back toward the main path.")

    fork(1)