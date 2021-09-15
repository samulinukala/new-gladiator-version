using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialShootAbility : MonoBehaviour
{
    public GameObject shootableObject;
    public Vector2 playerLocation;
    public GameObject[] playerShot;
    public float magicplosionTimer;
    public float magicExplosionDelay=0.7F;
    public float mana=0;
    public float maxMana=100;
    public float manaRecoverySpeed=0.02F;
    public float manaCost=20F;
    public bool isKeyDown=false;
    public GameObject tmpShot;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(manaCost < mana && Input.GetKey(KeyCode.RightControl)==true)
        {
            isKeyDown = true;
        }
        else
        {
            isKeyDown = false;
        }
        if (mana < maxMana)
        {
                mana = mana +manaRecoverySpeed * Time.deltaTime;
                
        }
        GameObject.FindGameObjectWithTag("playerManaBar").GetComponent<healthBar>().valueRetriver(mana, 100);
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;


        if (Input.GetKeyDown(KeyCode.DownArrow)==true &&isKeyDown==true|| 
            Input.GetKeyDown(KeyCode.UpArrow) == true && isKeyDown == true || Input.GetKeyDown(KeyCode.LeftArrow) == true && isKeyDown == true || 
            Input.GetKeyDown(KeyCode.RightArrow) == true && isKeyDown == true)
        {
           

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady == true)
            {
                tmpShot= Instantiate(shootableObject, playerLocation, transform.rotation);
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().attackReady = false;
                mana = mana - manaCost;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) == true) tmpShot.GetComponent<shot>().movementDirection = 2;
            if (Input.GetKeyDown(KeyCode.UpArrow) == true) tmpShot.GetComponent<shot>().movementDirection = 0;
            if (Input.GetKeyDown(KeyCode.LeftArrow) == true) tmpShot.GetComponent<shot>().movementDirection = 1;
            if (Input.GetKeyDown(KeyCode.RightArrow) == true) tmpShot.GetComponent<shot>().movementDirection = 3;
        }
        
        
    }
    public void addMana(float _addedMana)
    {
        if (mana < maxMana)
        {
            mana = mana + _addedMana;
        }
    }
}
