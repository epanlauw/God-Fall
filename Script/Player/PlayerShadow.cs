using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public bool turnOn = false;
    public GameObject shadow;
    public float timmer,timez;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timmer = timez;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnOn)
        {
            if(timmer > 0)
            {
                timmer -= Time.deltaTime;
            }
            else
            {
                GameObject shadows = Instantiate(shadow, transform.position, transform.rotation);
                shadows.GetComponent<SpriteRenderer>().sprite = sr.sprite;
                shadows.GetComponent<SpriteRenderer>().flipX = sr.flipX;
                timmer = timez;
                if (player_move_Test001.cinematic)
                {
                    Destroy(shadows);
                }
                Destroy(shadows, 1f);
            }
        }
        
    }
}
