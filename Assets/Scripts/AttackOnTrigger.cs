using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnTrigger : MonoBehaviour
{
    public playerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && playerMovement.attackReady == true ||
                Input.GetKeyDown(KeyCode.UpArrow) && playerMovement.attackReady == true ||
                Input.GetKeyDown(KeyCode.LeftArrow) && playerMovement.attackReady == true ||
                Input.GetKeyDown(KeyCode.RightArrow) && playerMovement.attackReady == true)
            {
                collision.GetComponent<EnemyAI>().damageEnemy(GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().playerDamage);
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady = false;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true || 
            Input.GetKeyDown(KeyCode.UpArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true || 
            Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true || 
            Input.GetKeyDown(KeyCode.RightArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true)
        {

            collision.GetComponent<EnemyAI>().damageEnemy(GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().playerDamage);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady = false;


        }

    }
}
