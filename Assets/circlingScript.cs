using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlingScript : MonoBehaviour
{
    public GameObject enemy;
    public Vector2 Center;
    public float RotateSpeed = 5f;
    public float changingRadius;
    public float RadiusMultiplier = 1f;
    private float angle;
    public float rotationOffset;
    public float changeSpeed;
    public float damage;

    private void Start()
    {
        angle = rotationOffset;
        
    }
    // Update is called once per frame
    void Update()
    {
        changingRadius=Mathf.Sin(Time.time * changeSpeed)*RadiusMultiplier;
       Center = enemy.transform.position;
        angle += RotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * changingRadius;
        transform.position = Center + offset;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() != null)
        {
            collision.gameObject.GetComponent<playerMovement>().damagePlayerSlow(damage);
        }
    }
}
