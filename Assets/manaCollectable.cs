using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaCollectable : MonoBehaviour
{
    public float manaGained;
    public float initialVel = 300;
    public Rigidbody2D rb => gameObject.GetComponent<Rigidbody2D>();
    private void Start()
    {
        rb.AddForce(new Vector2(initialVel, initialVel), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() != null)
        {
            collision.gameObject.GetComponent<specialShootAbility>().mana += manaGained;
            Destroy(gameObject);
        }
    }
}
