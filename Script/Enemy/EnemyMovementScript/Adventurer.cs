using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    public float speed = 100f;
    public float left, right,distance;
    public float health;
    private bool getHit,reverse,alive;
    private Animator anim;
    private Rigidbody2D rigid;
    private SpriteRenderer gambarnak;
    private Vector3 kanan, kiri, original,newshiet;
    public GameObject serangan1,serangan2;
    public bool iseeplayer = false;
    public Transform player;
    private int state,state2;
    private float direction;
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
        InvokeRepeating("randomnyerang", 0, 2);
        //InvokeRepeating("randomMovement", 1, 2);
        health = 1000f;
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
                if (Vector3.Distance(this.transform.position, player.transform.position) > 1)
                {
                    letsMoveToPlayer();
                    anim.SetBool("IsRunning", true);
                }
                else
                {
                    anim.SetBool("IsRunning", false);
                }

                // Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
                //transform.Translate(direction * 0.1f, 0, 0);            
        }
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
    }

    void randomMovement()
    {
        state2 = Random.Range(1, 3);
        if(state2 == 1)
        {
            anim.SetBool("IsRunning", true);
            letsMoveToPlayer();
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    void randomnyerang()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 1f)
        {
            state = Random.Range(1, 3);
            if (state == 1)
            {
                attack1();
                speed = 2;
            }
            else
            {
                attack2();
                speed = 2;
            }
            //Debug.Log(state);
        }
        else
        {
            speed = 4;
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

    public void attack1()
    {
        Invoke("seranganke1", 0.1f);
        anim.Play("Attack 1");
        //transform.Translate(direction * 0.1f, 0, 0);
        //GameObject Sa = Instantiate(serangan2, this.transform.position, this.transform.rotation);
    }
    public void attack2()
    {
            Invoke("seranganke2", 0.1f);
            anim.Play("Attack 2");
            //transform.Translate(direction*0.1f,0,0);
        //GameObject Sa = Instantiate(serangan2, this.transform.position, this.transform.rotation);
    }

    public void seranganke1()
    {
        GameObject Sa = Instantiate(serangan1, this.gameObject.transform);
        //Sa.transform.parent = gameObject.transform.parent;
        if (gambarnak.flipX)
        {
            Sa.transform.localScale = new Vector3(-1, 1, 1);
            Sa.transform.localPosition = new Vector3((float)-0.2, 0, 0);
        }
        else
        {
            Sa.transform.localScale = new Vector3(1, 1, 1);
            Sa.transform.localPosition = new Vector3((float)0.2, 0, 0);
        }
        Destroy(Sa, 0.2f);

    }

    public void seranganke2()
    {
        GameObject Sa = Instantiate(serangan2,this.gameObject.transform);
        //Sa.transform.parent = gameObject.transform.parent;
        if (gambarnak.flipX)
        {
            Sa.transform.localScale = new Vector3(-1, 1, 1);
            Sa.transform.localPosition = new Vector3((float)-0.2, 0, 0);
        }
        else
        {
            Sa.transform.localScale = new Vector3(1, 1, 1);
            Sa.transform.localPosition = new Vector3((float)0.2, 0, 0);
        }
        Destroy(Sa, 0.2f);

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
            rigid.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 0;
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
            rigid.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rigid.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rigid.gravityScale = 0;
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
