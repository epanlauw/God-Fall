using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float speed,jumpForce;
    public bool reverve;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private int jmp = 2;
    private float health = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (reverve)
        {
            sr.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("move", Mathf.Abs(h));

        if (reverve)
        {
            if(h > 0)
            {
                sr.flipX = true;
            }
            else if(h < 0)
            {
                sr.flipX = false;
            }
        }
        else
        {
            if (h > 0)
            {
                sr.flipX = false;
            }
            else if (h < 0)
            {
                sr.flipX = true;
            }
        }
        transform.Translate(h * speed * Time.deltaTime, 0, 0);
        //rb.MovePosition(transform.position + transform.right * h * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            if(jmp > 0)
            {
                jmp--;
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            health -= Random.Range(10, 30);
            anim.Play("Slime_getHit");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("restore Jump");
            jmp = 2;
        }
    }
}
