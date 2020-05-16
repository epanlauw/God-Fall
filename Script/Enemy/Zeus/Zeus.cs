using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{

    public float speed = 20.0f;
    public GameObject[] waypoints;
    public GameObject thunder;
    private int waypointIndex = 0;
    private int stups = 0 ;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        movement();
        attack();
    }

    void movement()
    {
        this.transform.position = Vector2.MoveTowards(
            this.transform.position,
            waypoints[waypointIndex].transform.position,
            speed * Time.deltaTime);
        stups++;
        if (stups % 60 == 0)
        {
            waypointIndex = Random.Range(1, 3);
        }
    }

    void attack()
    {
        if (stups % 60 == 0)
        {
            Instantiate(thunder, this.transform.position, this.transform.rotation);
        }
       
    }
}
