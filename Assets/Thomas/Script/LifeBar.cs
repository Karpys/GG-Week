using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Sprite lifeZero, lifeOne, lifeTwo, lifeTree;
    public CharaCircle charaCircle;
    public int currentHealth;

    private void Start()
    {
        charaCircle = FindObjectOfType<CharaCircle>();
    }

    private void FixedUpdate()
    {
        currentHealth = charaCircle.currentHealth;
        // TEST
        /*if (Input.GetMouseButtonDown(0))
        {
            --currentHealth;
        }*/

        if (currentHealth == 3)
        {
            GetComponent<Image>().sprite = lifeTree;
        }
        else if (currentHealth == 2)
        {
            GetComponent<Image>().sprite = lifeTwo;
        }
        else if (currentHealth == 1)
        {
            GetComponent<Image>().sprite = lifeOne;
        }
        else if (currentHealth == 0)
        {
            GetComponent<Image>().sprite = lifeZero;
        }
    }
}
