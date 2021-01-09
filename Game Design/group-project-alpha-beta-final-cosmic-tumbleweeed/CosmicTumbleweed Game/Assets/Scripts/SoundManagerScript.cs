using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

// https://www.youtube.com/watch?v=8pFlnyfRfRc
// https://www.youtube.com/watch?v=QL29aTa7J5Q

    public AudioClip deathSound, playerDash, playerJump, groundPound, powerUp, platformCrumble, fallingDebris, step, checkpoint, grandpa, aunt, greatGrandma, lightning, willow, mom, dad;
    public AudioSource source;
    public static SoundManagerScript instance;

    void Start()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
            
        }
        source = GetComponent<AudioSource>();        
    }

    public static void PlaySound(string clip){
        
        switch(clip){
            
            case "death":
                instance.source.volume = 1f;
                instance.source.PlayOneShot(instance.deathSound);
                break;
            case "jump":
                instance.source.volume = 1f;
                instance.source.PlayOneShot(instance.playerJump);
                break;
            case "dash":
                instance.source.volume = 1f;
                instance.source.PlayOneShot(instance.playerDash);
                break;
            case "crumble":
                instance.source.volume = 1f;
                instance.source.PlayOneShot(instance.platformCrumble);
                break;
            case "groundPound":
                instance.source.volume = 1f;
                instance.source.PlayOneShot(instance.groundPound);
                break;
            case "power":
                instance.source.volume = 0.7f;
                instance.source.PlayOneShot(instance.powerUp);
                break;
            case "fallingDebris":
                instance.source.volume = 0.7f;
                instance.source.PlayOneShot(instance.fallingDebris);
                break;
            case "step":
                instance.source.volume = 0.7f;
                instance.source.PlayOneShot(instance.step);
                break;
            case "checkpoint":
                instance.source.PlayOneShot(instance.checkpoint);
                instance.source.volume = 0.7f;
                break;
            case "grandpa":
                instance.source.volume = 0.6f;
                instance.source.PlayOneShot(instance.grandpa);
                break;
            case "aunt":
                instance.source.volume = 0.6f;
                instance.source.PlayOneShot(instance.aunt);
                break;
            case "greatGrandma":
                instance.source.volume = 0.6f;
                instance.source.PlayOneShot(instance.greatGrandma);
                break;
            case "lightning":
                instance.source.volume = 1f;
                instance.source.PlayOneShot(instance.lightning);
                break;
            case "Willow":
                instance.source.volume = 0.2f;
                instance.source.PlayOneShot(instance.willow);
                break;
            case "willow":
                instance.source.volume = 0.2f;
                instance.source.PlayOneShot(instance.willow);
                break;
            case "Mom":
                instance.source.volume = 0.1f;
                instance.source.PlayOneShot(instance.mom);
                break;
            case "Dad":
                instance.source.volume = 0.4f;
                instance.source.PlayOneShot(instance.dad);
                break;
        }
    }

    public static void StopSound(){
        instance.source.Stop();
    }
}
