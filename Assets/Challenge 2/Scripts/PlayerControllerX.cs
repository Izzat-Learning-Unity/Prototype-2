using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool cooldownFinished = true;
    private float cooldown = 1.5f;
    private float cooldownTimePassed =0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (cooldownFinished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                cooldownFinished = false;
                cooldownTimePassed = 0;
            }
        }

        cooldownTimePassed += Time.deltaTime;
        if(cooldownTimePassed >= cooldown)
        {
            cooldownFinished = true;
        }


    }
        
}
