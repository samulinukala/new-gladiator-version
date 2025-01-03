﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public int movementDirection;
    public float maxSpeed=20F;
    public List<GameObject> enemiesInRadius=new List<GameObject>();
    public float auraDamage=5;
    private float lifetimeTimer=0;
    public float lifetime=40;
    public float minSpeed = 10;
    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(minSpeed, maxSpeed);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetimeTimer<lifetime)
        {
            lifetimeTimer += 1 * Time.deltaTime;
        }
        if(lifetime<lifetimeTimer)
        {
            DestroyImmediate(this.gameObject);
        }
       
            switch (movementDirection)
            {
                case 3:
                    transform.Translate(Speed * Time.deltaTime, 0, 0);
                    break;
                case 2:
                    transform.Translate(0, -Speed * Time.deltaTime, 0);
                    break;
                case 1:
                    transform.Translate(-Speed * Time.deltaTime, 0, 0);
                    break;
                case 0:
                    transform.Translate(0, +Speed * Time.deltaTime, 0);
                    break;
            }
        
        foreach(GameObject e in enemiesInRadius)
        {
            e.gameObject.GetComponent<EnemyAI>().takeDamageFromAura(auraDamage * Time.deltaTime);
            

        }
    }
   public void setShootingDirection(int _Dir)
    {
        movementDirection = _Dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyAI>()!=null)
        {
           
            enemiesInRadius.Add(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {   if(collision.gameObject.GetComponent<EnemyAI>() != null)
            {
            
            enemiesInRadius.Remove(collision.gameObject);
            }
        
    }
    
    
}
