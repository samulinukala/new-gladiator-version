using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    private playerMovement player;
    private float playerDamage;
    private float timer = 0;
    public int attackCollider;
    public GameObject AttackTrigger;
    public SpriteRenderer Sword;
    public float Swordtimer = 1.3f;
    public float SwordTimerTarget = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        playerDamage = player.playerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            attackCollider = 0;
        }else
        if (Input.GetKey(KeyCode.DownArrow))
        {
            attackCollider = 2;
        }else
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            attackCollider = 1;
        }else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            attackCollider = 3;

        }
        else
        {
            attackCollider = 7;
        }
        if (Swordtimer < SwordTimerTarget)
        {
            Sword.enabled = true;
            Swordtimer = Swordtimer + 1 * Time.deltaTime;
        }
        else if(Swordtimer>SwordTimerTarget)
        {
            Sword.enabled = false;
        }
        switch (attackCollider)
        {
            case 3:

                AttackTrigger.transform.eulerAngles = new Vector3(0, 0, -90);
                Swordtimer = 0;
                break;
            case 2:

                AttackTrigger.transform.eulerAngles = new Vector3(0, 0, -180);
                Swordtimer = 0;
                break;
            case 1:

                AttackTrigger.transform.eulerAngles = new Vector3(0, 0, 90);
                Swordtimer = 0;
                break;
            case 0:

                AttackTrigger.transform.eulerAngles = new Vector3(0, 0, 0);
                Swordtimer = 0;
                break;
            default:

                break;

        }

    }
   
}