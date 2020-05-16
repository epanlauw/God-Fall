using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobSlime : MonoBehaviour
{
    public float speed;
    public float left, right;
    public float wait;
    public bool reverse;
    public float health = 100;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private float tampung,oneTime,change;
    private Vector3 ori, le,ri;
    public Transform player;
    private bool getHit;
    private float hit_count;
    public bool ISeePlayer = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ori = transform.position;
        le = new Vector3(ori.x - left, ori.y, ori.z);
        ri = new Vector3(ori.x + right, ori.y, ori.z);
        tampung = Random.Range(0.0f, 1.0f);
        oneTime = 1;
        change = 0;
        getHit = false;
    }

    void Update()
    {
        anim.SetBool("GetHit", false);
        if (!getHit && !ISeePlayer)
        {
            if (oneTime == 1)
            {
                if (tampung < 0.6f)
                {
                    go_left();
                }
                else
                {
                    go_right();
                }
                oneTime = 0;
            }
            else
            {
                if (change == 0)
                {
                    go_left();
                }
                else
                {
                    go_right();
                }
            }
        }
        else if (ISeePlayer && !getHit)
        {
            letsMoveToPlayer();
            if (transform.position.x > le.x - 10 && transform.position.x < ri.x + 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            }
            else
            {
                ISeePlayer = false;
            }
        }
        else
        {
            Vector3 nwPos = transform.position;
            if (hit_count > 0)
            {
                if (nwPos.x < player.position.x)
                {
                  
                    transform.Translate(-1f, 0, 0);
                }
                else
                {
                    
                    transform.Translate(1f, 0, 0);
                }
                hit_count--;
            }
            
            letsMoveToPlayer();
            if (nwPos.x > le.x - 10 && nwPos.x < ri.x + 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            }
            else
            {
                getHit = false;
            }
        }
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    void letsMoveToPlayer()
    {
        Vector3 nwPos = transform.position;
        if (nwPos.x < player.position.x)
        {
            if (reverse)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            if (reverse)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
    
    void go_left()
    {
        if(transform.position.x > le.x)
        {
            if (reverse)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }
        else
        {
            if (reverse)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        
        float distance = Vector3.Distance(transform.position, new Vector3(le.x, transform.position.y, transform.position.z));

        if(distance > 0.5f)
        {
            anim.SetFloat("move", 2.0f);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(le.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(le.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("move", 2.0f);
            tampung += Time.deltaTime;
            if (tampung >= wait)
            {
                tampung = 0;
                change = 1;
            }
        }
    }

    void go_right()
    {
        if(transform.position.x < ri.x)
        {
            if (reverse)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        else
        {
            if (reverse)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }
        float distance = Vector3.Distance(transform.position, new Vector3(ri.x,transform.position.y,transform.position.z));

        if (distance > 0.5f)
        {
            anim.SetFloat("move", 2.0f);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(ri.x, transform.position.y, transform.position.z), speed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(ri.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("move", 0);
            tampung += Time.deltaTime;
            if (tampung >= wait)
            {
                tampung = 0;
                change = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player_Attack")
        {
            hit_count = 1;
            health -= 25f;
            getHit = true;
            anim.SetBool("GetHit", true);          
        }
        
        if (collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rb.gravityScale = 0;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 0;
        }
        if (collision.gameObject.tag == "ground")
        {
            rb.gravityScale = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 1;
        }
        if (collision.gameObject.tag == "ground")
        {
            rb.gravityScale = 1;
        }
    }
}
