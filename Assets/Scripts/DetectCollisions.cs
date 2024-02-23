using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.lives -= 1;
            if(PlayerController.lives > 0)
            {
                Debug.Log("Lives: " + PlayerController.lives + "\nScore: " + PlayerController.score);
            }

           
        }
        else
        {
            if (gameObject.CompareTag("Projectile"))
            {
                if (PlayerController.lives > 0)
                {
                    other.GetComponent<AnimalHunger>().FeedAnimal(1);
             
                }
                Destroy(gameObject);
            }
            

        }
        
    }
}
