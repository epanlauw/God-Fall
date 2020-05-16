using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public GameObject preBird;
    private int timeEnemy = 1;

    void Start() 
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        timeEnemy++;
        if(timeEnemy % 100 == 0){
            Instantiate(preBird,this.transform.position,this.transform.rotation);
        }
    }
}
