using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collectibles : MonoBehaviour
{
    public TextMeshProUGUI collectibles;//slot for collectibles text
    public TextMeshProUGUI pickUpText;//slot for pick up text

    public GameObject collectible;//the game object that is being used for this

    public int currentCollectibles = 0;
    public int maxCollectibles = 24;

    public void Start()
    {
        //make sure pick up text is not showing when start
        if (pickUpText != null)
        {
            pickUpText.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        UpdateText();//update every frame
        PickUpUI();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collectible"))//searches to see if trigger has this tag
        {
            //if the pickuptext is null set it to true 
            pickUpText.gameObject.SetActive(true);
            if (pickUpText != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //if E is pressed destroy the game obj and update UI
                    Destroy(other.gameObject);
                    currentCollectibles++;
                    LoadNextScene();
                    pickUpText.gameObject.SetActive(false);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if away from trigger turn off pick up text
        pickUpText.gameObject.SetActive(false);
    }

    public void UpdateText()
    {
        //to update number of collectibles 
        collectibles.text = "Keys: " + currentCollectibles + "/" + maxCollectibles;
    }

    public void PickUpUI()
    {
        //show this text once in trigger event
        pickUpText.text = "Press E to collect";
    }

     public void LoadNextScene()
    {
        // Load the scene with the next build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
