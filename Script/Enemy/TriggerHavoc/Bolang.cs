using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolang : MonoBehaviour
{
    public GameObject adven;
    public GameObject radius;
    public GameObject luls;
    
    // Start is called before the first frame update
    void Start()
    {
        adven.SetActive(false);
        radius.SetActive(false);
        luls.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if(adven==null)
        {
            luls.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Mammamia");
            adven.SetActive(true);
            radius.SetActive(true);
        }
    }

}
