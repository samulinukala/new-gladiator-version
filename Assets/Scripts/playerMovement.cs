using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Vector3 playerLocation;
    public float moveSpeed;
    public float playerDamage=25;
    public float health=100;
    public int lastDirectionInput;
    public float attackSpeed=1;
    public float timer=0;
    public bool attackReady=true;
    public int score=0;
    public bool canMoveUp=true;
    public bool canMoveDown = true;
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public int spellKillUnlock=9;
    public specialShootAbility specialShootAbility;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("playerHealthBar").GetComponent<healthBar>().valueRetriver(health, 100);
        if(score>spellKillUnlock)
        {
            specialShootAbility.enabled = true;
        }
        if (timer < attackSpeed)
        {
           
            timer = timer + 1 * Time.deltaTime;
        }
        if(timer>=attackSpeed)
        {
            attackReady = true;
        }
        if (health < 0)
        {
            GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>().saveScore(score);
            GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>().pauseGame();
            GameObject.FindGameObjectWithTag("endMenu").GetComponent<Canvas>().enabled = true;
        }
        
        
       
    //movement
    //to do mana limiter explosion thing. magic stuff.
    if (Input.GetKey(KeyCode.W)&& canMoveUp==true)
        {
            transform.Translate(playerLocation.x, +moveSpeed*Time.deltaTime, playerLocation.z);
          
        }
        if (Input.GetKey(KeyCode.A)&&canMoveLeft==true)
        {
            transform.Translate(-moveSpeed*Time.deltaTime , playerLocation.y, playerLocation.z);
           
            
        }
        if (Input.GetKey(KeyCode.S)&&canMoveDown==true)
        {
            transform.Translate(playerLocation.x,  -moveSpeed*Time.deltaTime, playerLocation.z);
            
           
        }
        if (Input.GetKey(KeyCode.D)&&canMoveRight==true)
        {
            transform.Translate( +moveSpeed*Time.deltaTime, playerLocation.y, playerLocation.z);
            
            
        }

    
       
       

        //Attack implement later.
       

        if (health < 0)
        {
            
        }
       
    }
   
    public void damagePlayerSlow(float _damage)
    {
        health=health - _damage*Time.deltaTime;
        
    }
    
    private void collider2d(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            transform.Translate(other.transform.position);
            Debug.Log("wall");
        }
    }

}
