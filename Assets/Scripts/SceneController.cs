using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void Settings()
    { 
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        
    }
}
