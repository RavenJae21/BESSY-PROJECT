using TMPro;
using UnityEngine;
using System.Collections.Generic;

public enum KeyType
    {
        Black,
        Red,
        Silver
    }

public class Player_Collectibles : MonoBehaviour
{
    /*public TextMeshProUGUI collectibles;//slot for collectibles text
    public TextMeshProUGUI interactText;//slot for pick up text

    public GameObject collectible;//the game object that is being used for this

    public List<KeyType> keys = new List<KeyType>();
    public int currentCollectibles;
    public int maxCollectibles;

    public void Start()
    {
        //make sure pick up text is not showing when start
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collectible"))//searches to see if trigger has this tag
        {
            //if the pickuptext is null set it to true 
            if (interactText != null)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = "Press E to pick up key";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //if E is pressed destroy the game obj and update UI
                    RequiredKey key = other.GetComponent<RequiredKey>();

                    if (key != null)
                    {
                        keys.Add(key.keyType);
                        Destroy(other.gameObject);
                        currentCollectibles++;
                        UpdateText();
                    }
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if away from trigger turn off pick up text
        interactText.gameObject.SetActive(false);
    }

    public void UpdateText()
    {
        //to update number of collectibles 
        collectibles.text = "Keys: " + currentCollectibles + "/" + maxCollectibles;
    }

     public void LoadNextScene()
    {
        // Load the scene with the next build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        //if (SceneManager.GetActiveScene().buildIndex == 2 && currentCollectibles == maxCollectibles)
        {
            //SceneManager.LoadScene(0);
        }
    }*/

    [Header("UI References")]
    public TextMeshProUGUI collectibles; // Text displaying current keys
    public TextMeshProUGUI interactText; // Text showing pickup prompt

    [Header("Collectible Settings")]
    public List<KeyType> keys = new List<KeyType>();
    public int currentCollectibles;
    public int maxCollectibles;

    private RequiredKey currentKey = null; // Tracks the collectible player is near

    private void Start()
    {
        // Ensure pickup text is hidden at start
        if (interactText != null)
            interactText.gameObject.SetActive(false);

        UpdateText(); // initialize key count display
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            currentKey = other.GetComponent<RequiredKey>();
            if (currentKey != null && interactText != null)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = "Press E to pick up key";
                interactText.ForceMeshUpdate(); // prevent TMP duplicate character errors
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            RequiredKey key = other.GetComponent<RequiredKey>();
            if (key != null)
            {
                // Show interact text
                if (interactText != null)
                {
                    interactText.gameObject.SetActive(true);
                    interactText.text = "Press E to pick up key";
                }

                // Pickup key
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!keys.Contains(key.keyType))
                    {
                        keys.Add(key.keyType);
                        currentCollectibles++;
                        UpdateText();
                    }

                    Destroy(other.gameObject);

                    if (interactText != null)
                        interactText.gameObject.SetActive(false);
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            currentKey = null;
            if (interactText != null)
                interactText.gameObject.SetActive(false);
        }
    }

    private void UpdateText()
    {
        if (collectibles != null)
        {
            collectibles.text = $"Keys: {currentCollectibles}/{maxCollectibles}";
            collectibles.ForceMeshUpdate(); // TMP safe mesh update
        }
    }
}
