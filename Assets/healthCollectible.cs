using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollectible : MonoBehaviour
{
    public float healthGained;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() != null)
        {
            collision.gameObject.GetComponent<playerMovement>().health += healthGained;
            Destroy(gameObject);
        }
    }
}
