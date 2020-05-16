using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSeus : MonoBehaviour
{
    public GameObject seus;
    public GameObject adventuur;
    // Start is called before the first frame update
    void Start()
    {
        seus.SetActive(false);
        adventuur.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            seus.SetActive(true);
            adventuur.SetActive(true);
        }    
    }
}
