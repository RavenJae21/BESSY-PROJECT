using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ControlsMenu() 
    {
        Debug.Log("You clicked Controls");
        SceneManager.LoadScene("ControlsMenu");
    
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
