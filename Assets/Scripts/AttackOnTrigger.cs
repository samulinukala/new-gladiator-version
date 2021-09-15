using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnTrigger : MonoBehaviour
{
    public playerMovement playerMovement;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true ||
           Input.GetKeyDown(KeyCode.UpArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true ||
           Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true ||
           Input.GetKeyDown(KeyCode.RightArrow) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true)
        {
            foreach (GameObject enemy in enemies)
            {


                if (enemy.GetComponent<EnemyAI>() != null)
                {
                    enemy.GetComponent<EnemyAI>().damageEnemy(playerMovement.playerDamage);
                }
                else
                {
                    enemies.Remove(enemy);
                }

            }
        }

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
        
            if (collision.GetComponent<EnemyAI>() != null)
            {
                enemies.Add(collision.gameObject);
            }
           
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady = false;

       


        }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyAI>() != null)
        {
            enemies.Remove(collision.gameObject);
        }
    }
}
