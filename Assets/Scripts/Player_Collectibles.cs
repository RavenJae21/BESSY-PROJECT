using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Collectibles : MonoBehaviour
{
    public TextMeshProUGUI collectibles;
    public TextMeshProUGUI pickUpText;

    public GameObject collectible;

    public int currentCollectibles = 0;
    public int maxCollectibles = 24;

    public void Start()
    {
        UpdateText();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectible"))
        {
            //disable collider immediately to disable more than one hit
            Collider col = hit.collider;
            col.enabled = false;

            Destroy(hit.gameObject);//destroy once player collides with this

            //add one if less than maxcollectibles
            if (currentCollectibles < maxCollectibles)
            {
                //Debug.Log("Collectible!");
                currentCollectibles ++;
                UpdateText();
            }

        }
    }

    public void UpdateText()
    {
        collectibles.text = "Collectables: " + currentCollectibles + "/" + maxCollectibles;
    }
}
