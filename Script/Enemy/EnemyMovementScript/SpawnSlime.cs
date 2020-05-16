using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    public GameObject slime;
    private void OnTriggerEnter2D(Collider2D other) {
        for(int i=0;i<4;i++){
            Instantiate(slime,this.transform.position,this.transform.rotation);
        }
    }
}
