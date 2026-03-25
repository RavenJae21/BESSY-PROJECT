using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ControlsUI;

    private void Start() 
    {
        ControlsUI.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ControlsMenu() 
    {
        //Debug.Log("You clicked Controls");
        ControlsUI.SetActive(true);

    }

    public void Back()
    {
        //Debug.Log("You clicked Back");
        ControlsUI.SetActive(false);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
