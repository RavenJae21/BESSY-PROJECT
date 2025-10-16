using UnityEngine;

public class Grass_Sound : MonoBehaviour
{
    public AudioSource walkSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walkSound = GetComponent<AudioSource>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            walkSound.Play();
        }
        else
        {
            walkSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
