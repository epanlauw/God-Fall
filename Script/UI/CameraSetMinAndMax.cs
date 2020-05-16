using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetMinAndMax : MonoBehaviour
{
    public float min;
    public float minhigh;
    public float normal;
    public float maxlow;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player_move_Test001.minCam = min;
            player_move_Test001.minhighCam = minhigh;
            player_move_Test001.norCam = normal;
            player_move_Test001.maxlowCam = maxlow;
            player_move_Test001.maxCam = max;
        }
    }
}
