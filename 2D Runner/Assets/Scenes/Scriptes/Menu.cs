using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour

{ 
    public void MainMenu ()
    {
        SceneManager.LoadScene(0);

    }
    public void CharacterSelection ()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
    public void Options ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void HowToPlay ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Play ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
