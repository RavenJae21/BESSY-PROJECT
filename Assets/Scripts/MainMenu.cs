using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenu() {
        Debug.Log("You clicked Options");
    
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
