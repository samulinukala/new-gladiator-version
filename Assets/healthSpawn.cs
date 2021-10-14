using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSpawn : MonoBehaviour
{
  
    public bool breakIsOn;
    public bool hasSpawnedHealthBalls;
    public GameObject healthballPrefab;
    public List<GameObject> healthBalls;
    public int ballCount=1;
    private Collider2D collider2d=>gameObject.GetComponent<Collider2D>();
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject i in healthBalls)
        {
            if (i == null)
            {
                healthBalls.Remove(i);
            }
        }
        breakIsOn = GameObject.FindObjectOfType<Spawner>().BreakIsOn;
      
        if (breakIsOn == true )
        {
            if (healthBalls.Count < ballCount)
            {
                for (int i = 0; i < ballCount; i++)
                {
                    healthBalls.Add(GameObject.Instantiate(healthballPrefab));
                }
                foreach (GameObject i in healthBalls)
                {
                    i.transform.position = new Vector2(Random.Range(collider2d.bounds.min.x, collider2d.bounds.max.x), Random.Range(collider2d.bounds.min.y, collider2d.bounds.max.y));

                }
             
            }

        }
        if (breakIsOn == false)
        {
            foreach(GameObject i in healthBalls)
            {
                Destroy(i);
            }
        }
    }
}
