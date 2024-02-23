using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;

    private int currentAmountFed;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FeedAnimal(int amount)
    {
        currentAmountFed += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentAmountFed;

        if (currentAmountFed >= amountToBeFed)
        {
            PlayerController.score += 1;
            Debug.Log("Lives: " + PlayerController.lives + "\nScore: " + PlayerController.score);
            Destroy(gameObject, 0.1f);
        }


    }
}
