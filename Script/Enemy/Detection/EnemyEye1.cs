using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEye1 : MonoBehaviour
{
    public EnemyMobSlime emr;
    public SpriteRenderer sr;

    private void Awake()
    {
        sr = transform.parent.GetComponent<SpriteRenderer>();
        emr = transform.parent.GetComponent<EnemyMobSlime>();
    }

    private void Update()
    {
        if (emr.reverse)
        {
            if (sr.flipX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if (sr.flipX)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<EnemyMobSlime>().ISeePlayer = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<EnemyMobSlime>().ISeePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<EnemyMobSlime>().ISeePlayer = false;
        }
    }
}
