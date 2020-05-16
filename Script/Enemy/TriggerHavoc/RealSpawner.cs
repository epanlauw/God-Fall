using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealSpawner : MonoBehaviour
{
    public GameObject servants;
    private int i;
    private int contoh;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void spawn()
    {
        
            Instantiate(servants,transform);
            contoh++;
       
    }
    
}
