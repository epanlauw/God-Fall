using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{  
    private float arrowspeed = 7f;
    public AdventurerBow emr;
    public SpriteRenderer sr;
    // Start is called before the first frame update

    private void Awake()
    {
        sr = transform.parent.GetComponent<SpriteRenderer>();
        emr = transform.parent.GetComponent<AdventurerBow>();
    }
    void Start()
    {
        //sr = ab.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (emr.reverse)
        {
            if (sr.flipX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                //transform.localPosition = new Vector3((float)0.0, 0, 0);
                transform.Translate(Vector2.left * arrowspeed * Time.deltaTime);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                //transform.localPosition = new Vector3((float)0.0, 0, 0);
                transform.Translate(Vector2.right * arrowspeed * Time.deltaTime);
            }
        }
        else
        {
            if (sr.flipX)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                //transform.localPosition = new Vector3((float)0.0, 0, 0);
                transform.Translate(Vector2.left * arrowspeed * Time.deltaTime);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                //transform.localPosition = new Vector3((float)0.0, 0, 0);
                transform.Translate(Vector2.right * arrowspeed * Time.deltaTime);
            }
        }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
        if(collision.gameObject.tag == "Player"){
            player_move_Test001.health-=5;
            Destroy(this.gameObject);
        }
    }
}
