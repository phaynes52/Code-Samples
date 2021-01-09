using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    // source: https://www.youtube.com/watch?v=ToVL_f9G9Yk&t=63s
    // transitioning BGM: https://www.youtube.com/watch?v=AjDhUiyBTHc
    // https://www.youtube.com/watch?v=XoH8Qyqje1g
    // https://answers.unity.com/questions/838467/change-music-when-changing-scene.html

    private static MusicTransition instance;

    [SerializeField]
    public AudioSource BGM;
    
    [SerializeField]
    public AudioClip MainTrack, EmotionalTrack, BeginningTrack, FinalTrack;

    [SerializeField]
    public int TrackSelector;

    void Awake()
    {
        if(instance==null){
            instance = this;
            PlayGameMusic(TrackSelector);
            
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);            
        }

        
    }

    void Start(){
        
    }

    public static void PlayGameMusic(int track){

        if (instance != null) {
            if (track == 1){
                instance.BGM.Stop();
                instance.BGM.clip = instance.MainTrack;
                instance.BGM.Play();
        } else if (track == 2){
                instance.BGM.Stop();
                instance.BGM.clip = instance.EmotionalTrack;
                instance.BGM.Play();
        } else if (track == 0){
                instance.BGM.Stop();
                instance.BGM.clip = instance.BeginningTrack;
                instance.BGM.Play();
        } else if (track == 3){
                instance.BGM.Stop();
                instance.BGM.clip = instance.FinalTrack;
                instance.BGM.Play();
        }


        }
    }

    public static void RestartMusic(){
        instance.BGM.Stop();
        instance.BGM.clip = instance.MainTrack;
        instance.BGM.Play();
    }

    void Update()
    {

    }
}
