using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30; 
    private float lowerBound = -10;
    private float horizontalBound = 17;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When an object get's out of the player's view, destroy it
        if (transform.position.z> topBound )
        {
            Destroy(gameObject);
        }else if(transform.position.z < lowerBound)
        {
            PlayerController.lives -= 1;
            if (PlayerController.lives > 0)
            {
                Debug.Log("Lives: " + PlayerController.lives + "\nScore: " + PlayerController.score);
            }
           
            Destroy(gameObject);
        }else if (transform.position.x > horizontalBound || -horizontalBound > transform.position.x)
        {
            Destroy(gameObject);
        }
       
    }
}
