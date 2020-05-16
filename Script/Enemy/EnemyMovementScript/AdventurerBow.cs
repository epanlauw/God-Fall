using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerBow : MonoBehaviour
{
    public float speed = 100f;
    public float left, right,distance,arrowspeed = 5;
    public float health;
    public bool getHit,reverse,alive;
    private Animator anim;
    private Rigidbody2D rigid;
    private SpriteRenderer gambarnak;
    private Vector3 kanan, kiri, original,newshiet;
    public GameObject serangan1;
    public bool iseeplayer = false;
    public Transform player;
    private int state,state2;
    private float direction;
    public float projectileSpeed=5;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        gambarnak = GetComponent<SpriteRenderer>();
        getHit = false;
        original = transform.position;
        alive = true;
        kiri = new Vector3(original.x - left, original.y, original.z); 
        kanan = new Vector3(original.x + left, original.y, original.z);
        direction = 1;
        health = 1000f;
        InvokeRepeating("randomnyerang",0,2);
    }

    // Update is called once per frame
    void Update()
    {
         newshiet = transform.position;
        
        if (alive)
        {
            
                // Debug.Log("manusiawi");
                if (this.gameObject.transform.position.x < 0)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }
                //InvokeRepeating("letsMoveToPlayer", 2, 5);
                if (Vector3.Distance(this.transform.position, player.transform.position) > 4)
                {
                    letsMoveToPlayer();
                    anim.SetBool("isRunning", true);
                }
                else
                {
                    anim.SetBool("isRunning", false);
                }
                

                // Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
                //transform.Translate(direction * 0.1f, 0, 0);            
        }
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
    }
    void letsMoveToPlayer()
    {
        Vector3 nwPos = transform.position;
        //anim.SetBool("IsRunning", true);
        if (nwPos.x < player.position.x)
        {
            if (reverse)
            {
                gambarnak.flipX = true;
            }
            else
            {
                gambarnak.flipX = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            if (reverse)
            {
                gambarnak.flipX = false;
            }
            else
            {
                gambarnak.flipX = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
    void randomnyerang()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 7f)
        {
            attack1();
            speed = 2;
        }
        else
        {
            speed = 4;
        }
    }


    public void seranganke1()
    {
        GameObject Sa = Instantiate(serangan1, this.gameObject.transform);
        if (gambarnak.flipX)
        {
            Sa.transform.localScale = new Vector3(-1, 1, 1);
            Sa.transform.localPosition = new Vector3((float)0.0, 0, 0);
            Sa.transform.Translate(Vector2.left*arrowspeed*Time.deltaTime);
        }
        else if(!gambarnak.flipX)
        {
            Sa.transform.localScale = new Vector3(1, 1, 1);
            Sa.transform.localPosition = new Vector3((float)0.0, 0, 0);
            Sa.transform.Translate(Vector2.right*arrowspeed*Time.deltaTime);
        }
        Destroy(Sa, 4f);
    }

     public void attack1()
    {
        Invoke("seranganke1", 1f);
        anim.Play("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Attack")
        {
            //hit_count = 1;
            health -= 25f;
            getHit = true;
        }
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 1;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 1;
        }
    }
}
