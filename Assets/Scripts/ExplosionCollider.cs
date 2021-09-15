﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollider : MonoBehaviour
{
    public List<GameObject> explosionEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if(collision.CompareTag("enemy"))
        {
            explosionEnemies.Add(collision.gameObject);
        }
        
    }
    
}
