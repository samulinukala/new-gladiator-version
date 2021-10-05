using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiketrap : MonoBehaviour
{
    public float damage;
    public float inactivityTimer=2;
    private float inactivitytimerCounter=0;
    public bool trapReady = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trapReady == false&inactivityTimer>inactivitytimerCounter)
        {
            inactivitytimerCounter += 1 * Time.deltaTime;
        }
        if (inactivityTimer < inactivitytimerCounter)
        {
            trapReady = true;
            inactivitytimerCounter = 0;
        }
        if (trapReady == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if(trapReady == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            
            if (collision.gameObject.GetComponent<playerMovement>() != null & trapReady == true)
            {
                trapReady = false;
                collision.gameObject.GetComponent<playerMovement>().health -= damage;
            }
            if (collision.gameObject.GetComponent<EnemyAI>() != null & trapReady == true)
            {
                trapReady = false;
                collision.gameObject.GetComponent<EnemyAI>().enemyHealth -= damage;
            }
        
    }
}
