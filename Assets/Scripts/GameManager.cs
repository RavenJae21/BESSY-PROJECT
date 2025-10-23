using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;//cursor is invisible on awake of the game
        Cursor.lockState = CursorLockMode.Locked;//lock the cursor in the middle 
    }
}
