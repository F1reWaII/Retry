using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(5);
    }

    public void Settings()
    { 
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        
    }
}
