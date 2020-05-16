using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_bar_test_2 : MonoBehaviour
{

    public float health = 100f;
    public float regenSpeed = 1;
    public Vector3 ori,end;
    private float timer = 0;
    private float move = 257f;
    public float limit;
    // Start is called before the first frame update
    void Start()
    {
        ori = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        //if()
    }
}
