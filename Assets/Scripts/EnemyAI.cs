using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerLocation;
    private Vector3 enemylocation;
    public float enemySpeed;
    public float damage=5;
    public float enemyHealth=10;
    public float stopDistance;
    public float minEnemyDistance;
    public int scoreValue;
    private bool enemyAtTop;
    private bool enemyAtBottom;
    private bool enemyAtLeft;
    private bool enemyAtRight;
    private float timer=0;
    private float unstuckTimer=4;
    private bool isTouchingPlayer=false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
      
        enemylocation = transform.position;
        playerLocation = player.transform.position;
        //chase player
        if (enemylocation.x != playerLocation.x)
        {
            if (playerLocation.x+stopDistance < enemylocation.x&&enemyAtRight==false)
            {
                transform.Translate(-enemySpeed * Time.deltaTime, 0, 0);
            }
            if(playerLocation.x-stopDistance > enemylocation.x&&enemyAtLeft==false)
            {
                transform.Translate(+enemySpeed * Time.deltaTime, 0, 0);
            }
        }
        if (enemylocation.y != playerLocation.y)
        {
            if (playerLocation.y+stopDistance < enemylocation.y&&enemyAtTop==false)
            {
                transform.Translate(0,-enemySpeed * Time.deltaTime,0);
            }
            if (playerLocation.y-stopDistance > enemylocation.y&&enemyAtBottom==false)
            {
                transform.Translate(0,+enemySpeed * Time.deltaTime, 0);
            }
        }
        if (enemyHealth <= 0)
        {
            player.GetComponent<playerMovement>().score = player.GetComponent<playerMovement>().score + scoreValue;
            Destroy(gameObject);
        }
        if (isTouchingPlayer == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().damagePlayerSlow(damage);
        }

     
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
         if (collision.gameObject.CompareTag("enemy"))
        {
            if (collision.transform.position.x > transform.position.x && collision.transform.position.y > transform.position.y)
            {
                enemyAtBottom = true;
            }
            if (collision.transform.position.x < transform.position.x && collision.transform.position.y < transform.position.y)
            {
                enemyAtTop = true;
            }
            if (collision.transform.position.x > transform.position.x && collision.transform.position.y < transform.position.y)
            {
                enemyAtRight = true;
            }
            if (collision.transform.position.x < transform.position.x && collision.transform.position.y > transform.position.y)
            {
                enemyAtLeft=true;
            }
        }
       
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }
    public void giveScoreToPlayer()
    {
        player.GetComponent<playerMovement>().score = player.GetComponent<playerMovement>().score + scoreValue;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (timer < unstuckTimer)
        {
            timer = +1 * Time.deltaTime;        
        }
        if (timer > unstuckTimer)
        {
            enemyAtBottom = false;
            enemyAtTop = false;
            enemyAtRight = false;
            enemyAtLeft = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyAtTop = false;
            enemyAtBottom = false;
            enemyAtLeft = false;
            enemyAtRight = false;
            timer = 0;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;  
        }
    }

    public void damageEnemy(float _damage)
    {
        enemyHealth = enemyHealth - _damage;
        
    }

}
