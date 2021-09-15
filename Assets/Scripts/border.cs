using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    public float repelspeed = -1;
    public Vector3 start;
    public bool isWall;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            if (collision.transform.position.x < 0 && isWall == true)
            {
                collision.GetComponent<playerMovement>().canMoveLeft = false;
                collision.GetComponent<playerMovement>().canMoveRight = true;
            }
            else if (collision.transform.position.x > 0 && isWall == true)
            {
                collision.GetComponent<playerMovement>().canMoveLeft = true;
                collision.GetComponent<playerMovement>().canMoveRight = false;
            }

            if (collision.transform.position.y < 0 && isWall == false)
            {
                collision.GetComponent<playerMovement>().canMoveUp = true;
                collision.GetComponent<playerMovement>().canMoveDown = false;
            }
            else if (collision.transform.position.y > 0 && isWall == false)
            {
                collision.GetComponent<playerMovement>().canMoveUp = false;
                collision.GetComponent<playerMovement>().canMoveDown = true;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < 0 && isWall == true)
            {
                collision.GetComponent<playerMovement>().canMoveLeft = false;
                collision.GetComponent<playerMovement>().canMoveRight = true;
            }
            else if (collision.transform.position.x > 0 && isWall == true)
            {
                collision.GetComponent<playerMovement>().canMoveLeft = true;
                collision.GetComponent<playerMovement>().canMoveRight = false;
            }

            if (collision.transform.position.y < 0 && isWall == false)
            {
                collision.GetComponent<playerMovement>().canMoveUp = true;
                collision.GetComponent<playerMovement>().canMoveDown = false;
            }
            else if (collision.transform.position.y > 0 && isWall == false)
            {
                collision.GetComponent<playerMovement>().canMoveUp = false;
                collision.GetComponent<playerMovement>().canMoveDown = true;
            }
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<playerMovement>().canMoveUp = true;
            collision.GetComponent<playerMovement>().canMoveDown = true;
            collision.GetComponent<playerMovement>().canMoveLeft = true;
            collision.GetComponent<playerMovement>().canMoveRight = true;
        }
    }
}
 
