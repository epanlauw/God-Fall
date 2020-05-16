using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdventure : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
           Instantiate(obj,this.transform.position,this.transform.rotation);
        }
    }
     void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
           obj.gameObject.SetActive(false);
        }
    }
}
