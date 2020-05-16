using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(4,6);
        this.transform.position = new Vector2(this.transform.position.x,rand);
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.Translate(new Vector2(-3f, 0f)*Time.deltaTime);
    }
}
