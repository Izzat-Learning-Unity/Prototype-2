using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 20f;

    public float xRange = 10f;
    public float zRange = 4.5f;

    public GameObject projectilePrefab;

    public Transform projectileSpawnPosition;

    public static int  lives = 3;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives: " + lives + "\nScore: " + score);
    }

    // Update is called once per frame
    void Update()
    {


        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(horizontalInput * Time.deltaTime * speed, 0, verticalInput * Time.deltaTime * speed);

        if(lives < 1)
        {
            Debug.Log("No More Lives Game Over!");
            Destroy(gameObject);
        }


    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn a Projectile whenever space is pressed.
            SpawnProjectile();
        }

        //Control the movement of the player
        LimitMovement();
    }

    private void LimitMovement()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        } 
        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    private void SpawnProjectile()
    {

        Vector3 newSpawnPosition  = new Vector3( transform.position.x, transform.position.y, transform.position.z+projectileSpawnPosition.position.z);  

        Instantiate(projectilePrefab, newSpawnPosition, projectilePrefab.transform.rotation);
    }
}
