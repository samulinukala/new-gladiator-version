using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAnim : MonoBehaviour
{
    
    public float currentMovementRange=0;
    public Quaternion transformAtStart;
    public float movementrangeMultiplier = 0.25f;
    public float speedOfAnim=10;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        transformAtStart = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            currentMovementRange = Mathf.Sin(Time.time * speedOfAnim);

            gameObject.transform.rotation = new Quaternion(transformAtStart.x, transformAtStart.y, transformAtStart.z + currentMovementRange * movementrangeMultiplier, transform.rotation.w);
        }
    }
}
