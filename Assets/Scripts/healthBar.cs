using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    //health that will be shown
    private float healthValue;
    //scales the health to make the healthBar work
    private float healthScale;
    //image that shows the max health
    public GameObject movingHealthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        movingHealthBar.GetComponent<Image>().fillAmount = healthValue / healthScale;
        
    }
    //put in update of the target 
    public void valueRetriver(float _value,float _scale)
    {
        healthValue = _value;
        healthScale = _scale;
    }
   
    
   
}
