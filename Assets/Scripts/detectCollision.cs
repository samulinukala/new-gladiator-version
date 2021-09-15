using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
   public bool isCollidingWithEnemy=false;
    public List<GameObject> meleeRangeEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("enemy"))
        {
        meleeRangeEnemies.Add(collision.gameObject);
        isCollidingWithEnemy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CompareTag("enemy"))
        {
            meleeRangeEnemies.Remove(collision.gameObject);
            isCollidingWithEnemy = false;
        }
    }

}
