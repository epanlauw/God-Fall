using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject walls;
    public GameObject walls2;
    private int slimes;
    // Start is called before the first frame update
    void Start()
    {
        walls.gameObject.SetActive(false);
        walls2.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        spawner2.gameObject.SetActive(false);
        spawner3.gameObject.SetActive(false);
        spawner4.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            walls.gameObject.SetActive(true);
            walls2.gameObject.SetActive(true);
            spawner.gameObject.SetActive(true);
            spawner2.gameObject.SetActive(true);
            spawner3.gameObject.SetActive(true);
            spawner4.gameObject.SetActive(true);
        }
    }

}
