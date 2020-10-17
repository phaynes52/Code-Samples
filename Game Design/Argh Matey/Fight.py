#fight.py
import config

def fight(opph, opps, oppq):
    config.tutorial
    config.strength
    config.health
    config.oppHealth = opph
    config.oppStrength = opps
    config.oppQuickness = oppq

    if config.tutorial == True :
        config.tutorial = False
        combatTutorial()

    attackThread = config.threading.Thread(target = attack)
    defendThread = config.threading.Thread(target = defend)

    print("Fight! \n")
    
    attackThread.start()
    defendThread.start()

    attackThread.join()
    defendThread.join()

    if config.health < 1 :
        print("You fought valiantly, but ultimately your swordsmanship was not enough to win the battle. You never pictured this is how it would end, but as you bleed out you feel an overwhelming peace and come to acceptance. Thank you for playing. Goodbye.")
        quit()

    return

def attack():
    config.strength
    config.health
    config.oppHealth

    while( config.health > 0 and config.oppHealth > 0) :
        base = config.random.randrange(1, config.strength)
        strikemult = config.random.randrange(1, 4)
        jabmult = config.random.randrange(0,2)
        extra = config.random.randrange(0,6)
        config.fightLock.acquire()
        start = config.time.time()
        attack = raw_input().lower()
        stop = config.time.time()
        hit = config.random.randrange(0, 100)

        if attack not in ["strike", "jab"] :
            print("Miss! Not a command.")
            config.fightLock.release()
            continue

        if attack == "strike" :
            damage = base*strikemult + extra
        
        elif attack == "jab" :
            damage = base*jabmult + extra

        if (stop - start > 1.51) :
            print("Miss! Too slow!")

        elif( hit < 25 or damage == 0 or attack not in ["strike", "jab", "dodge"]):
            print("Miss! \n")

        else :
            print("Hit! \n{} damage dealt \n".format(damage))
            config.oppHealth = config.oppHealth - damage
            if config.oppHealth > 0 :
                print("Opponents health is {} \n".format(config.oppHealth))

        config.fightLock.release()

    return

def defend():
    config.strength
    config.health
    config.oppHealth
    config.oppStrength
    config.oppQuickness

    while( config.health > 0 and config.oppHealth > 0) :
        config.time.sleep(config.random.randrange(config.oppQuickness, config.oppQuickness+3))
        config.fightLock.acquire()
        start = config.time.time()
        response = raw_input("\nYou're being attacked! \n").lower()
        stop = config.time.time()
        if ( config.health > 0 and config.oppHealth > 0) : 
            print("\nYou're being attacked! \n \n").lower()
            if response == "dodge" and (stop - start) < 2.01:
                print("Successful dodge! \n")
            else :
                attack = config.random.randrange(0,2)
                base = config.random.randrange(1, config.oppStrength)
                strikemult = config.random.randrange(1, 4)
                jabmult = config.random.randrange(0,2)
                extra = config.random.randrange(0,6)

                if attack == 0 :
                    damage = base*strikemult + extra
            
                elif attack == 1 :
                    damage = base*jabmult + extra

                print("You've been hit! \n{} damage taken \n".format(damage))
                config.health = config.health - damage
                if config.health > 0 :
                    print("Your health level is {} \n".format(config.health))
        config.fightLock.release()

    return

def combatTutorial() :
    config.tutorial
    config.tutorial = False
    raw_input("Woah easy now warrior. I can't send you into battle unprepared. Let me show you the ropes. \nAt all times you may type any of three commands: \n")
    raw_input("    1. jab (quick attack that deals light damage)\n")
    raw_input("    2. strike (strong attack that deals moderate damage) \n")
    raw_input("    3. dodge (used to avoid enemy attacks) \n")
    raw_input("In the case of attack commands (jab and strike) you will have 1.5 seconds from the time you enter the previous attack to enter your next attack. If it takes longer than this you will miss. (you may also miss based on the enemy dodging unrelated to your response time) \n")
    raw_input("For the dodge command you will recieve a prompt saying 'You are being attacked!'. You will have 2 second from the issuing of this prompt to successfully dodge the enemy attack.")
    raw_input("Got it? Let's try that out. Whenever you're ready hit enter to begin the fight.")
    return
         