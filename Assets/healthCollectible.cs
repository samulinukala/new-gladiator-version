using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollectible : MonoBehaviour
{
    public float healthGained;
    public float initialVel=300;
    public Rigidbody2D rb => gameObject.GetComponent<Rigidbody2D>();
    private void Start()
    {
        rb.AddForce(new Vector2(initialVel, initialVel), ForceMode2D.Impulse);   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() != null)
        {
            collision.gameObject.GetComponent<playerMovement>().health += healthGained;
            Destroy(gameObject);
        }
    }
}
