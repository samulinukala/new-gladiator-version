using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghettoUIManager : MonoBehaviour
{
 
    public Text score;
    public GameObject Player;
    public healthBar healthBar;
    public healthBar manaBar;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        score.text ="Kills: "+ Player.GetComponent<playerMovement>().score.ToString();
        healthBar.valueRetriver(Player.GetComponent<playerMovement>().health, 100f);
        manaBar.valueRetriver(Player.GetComponent<specialShootAbility>().mana, 100f);
       
        
    }
}
