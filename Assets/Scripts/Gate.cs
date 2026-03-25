using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public KeyType requiredKey;               // Set in Inspector (Black, Red, Silver)
    public TextMeshProUGUI interactText;      // Optional UI text to show prompt
    private bool playerIsNear = false;
    private Player_Collectibles player;       // Reference to player script
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if player entered the trigger
        player = other.GetComponent<Player_Collectibles>();
        if (player != null && !isOpen)
        {
            playerIsNear = true;

            // Show interact text if player has the key
            if (player.keys.Contains(requiredKey) && interactText != null)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = $"Press E to open {requiredKey} gate";
            }
            else if (interactText != null)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = $"You need a {requiredKey} key!";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!playerIsNear || isOpen || player == null) return;

        // Check for E press and key possession
        if (Input.GetKeyDown(KeyCode.E) && player.keys.Contains(requiredKey))
        {
            OpenGate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player != null && other.GetComponent<Player_Collectibles>() != null)
        {
            playerIsNear = false;
            if (interactText != null)
                interactText.gameObject.SetActive(false);
        }
    }

    private void OpenGate()
    {
        isOpen = true;
        if (interactText != null)
            interactText.gameObject.SetActive(false);

        Debug.Log($"{requiredKey} gate opened!");
        Destroy(gameObject); // Or play animation
    }
}
