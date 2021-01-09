using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Sources:
    Start Menu UI tutorial: 
    - https://www.youtube.com/watch?v=zc8ac_qUXQY
    Getting & Loading a scene: 
    - https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html 
    - https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetActiveScene.html
    - https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-buildIndex.html

*/

public class SceneLoader : MonoBehaviour
{
    public SceneLoader singleton;
    public bool beginningNext;
    public bool finalLevelNext;
    public bool endingNext;
    public bool regularNext;

    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Ensure only one instance of scene loader exists at a time.
        // This allows you to call functions in this script without needing to find a reference to it.
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Allows this GameObject to persist through scene changes

    }

    public void NextScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (beginningNext){
            MusicTransition.PlayGameMusic(0);
        } else if (finalLevelNext){
            MusicTransition.PlayGameMusic(3);
        } else if (endingNext){
            MusicTransition.PlayGameMusic(2);
        } else if (regularNext){
            MusicTransition.PlayGameMusic(1);
        }

    }

    public void Again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        MusicTransition.PlayGameMusic(0);
        
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void SkipSideLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        if (endingNext){
            MusicTransition.PlayGameMusic(2);
        } 
    }

    // For the optional Scene Transitions portion
    private IEnumerator NextSceneCoroutine()
    {
        // Your code here
        yield return new WaitForSeconds(0f);
    }
}
