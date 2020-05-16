using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_move_Test001 : MonoBehaviour
{
    public static bool cinematic;
    public float speed;
    public float jumpForce;
    public float dashMax;
    public float dashTimeCoolDown;
    public static float health;
    public static bool interact = false;
    public static float minCam;
    public static float maxCam;
    public static float minhighCam;
    public static float maxlowCam;
    public static float norCam;
    public enum PlayerMove { joy, keyboard};
    public PlayerMove playerMove;
    public GameObject Camera;
    public GameObject hitBox;
    public GameObject groundAttack;
    public GameObject AirAttack;
    public VariableJoystick variableJoystick;
    private float dashTime, direction, temp_speed, temp_speed2, dash_cooldown, h, hit_timer, hit_time, jump_Count;
    private bool moveCam, DashCooldown, onetimehit, canJump, inair;
    private Vector3 stop_c, move_cam;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D col;
    private PlayerShadow ps;
    private PlayerHitBox phb;
    private AudioSource aso;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ps = GetComponent<PlayerShadow>();
        phb = hitBox.GetComponent<PlayerHitBox>();
        aso = GetComponent<AudioSource>();
        h = 0;
        moveCam = true;
        direction = 1;
        temp_speed = speed;
        temp_speed2 = speed * 3;
        DashCooldown = false;
        dash_cooldown = dashTimeCoolDown;
        onetimehit = false;
        hit_time = 0.6f;
        canJump = true;
        jump_Count = 1;
        inair = false;
        health  = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cinematic)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                switch (playerMove)
                {
                    case PlayerMove.joy:
                        h = variableJoystick.Horizontal;
                        break;
                    case PlayerMove.keyboard:
                        h = Input.GetAxis("Horizontal");
                        break;
                    default:
                        h = variableJoystick.Horizontal;
                        break;
                }
                float raw_h = Input.GetAxisRaw("Horizontal");
                anim.SetFloat("move", Mathf.Abs(h));
                if (h > 0)
                {
                    sr.flipX = false;
                    direction = 1;
                }
                if (h < 0)
                {
                    sr.flipX = true;
                    direction = -1;
                }


                if (DashCooldown)
                {
                    if (dash_cooldown > 0)
                    {
                        dash_cooldown -= Time.deltaTime;
                    }
                    else
                    {
                        dash_cooldown = dashTimeCoolDown;
                        DashCooldown = false;
                    }
                }

                if (dashTime > 0)
                {
                    dashTime -= Time.deltaTime * 5f;
                    ps.turnOn = true;
                    rb.velocity = Vector2.zero;
                    phb.enemy = false;
                    transform.Translate(speed * Time.deltaTime, 0, 0);

                }
                if (dashTime <= 0)
                {
                    speed = temp_speed;
                    ps.turnOn = false;
                    if (!onetimehit)
                    {
                        transform.Translate(h * speed * Time.deltaTime, 0, 0);
                    }
                    if (phb.enemy)
                    {

                        onetimehit = true;
                        if (hit_timer <= 0)
                        {
                            hit_timer = hit_time;
                        }
                    }
                    if (onetimehit)
                    {
                        if (hit_timer == hit_time)
                        {
                            health -= 10f;
                            Debug.Log("hit");
                        }
                        if (hit_timer > 0.3f)
                        {
                            if (phb.pos.x > transform.position.x)
                            {
                                sr.flipX = false;
                                //rb.AddForce(Vector2.right * -20);
                                transform.Translate(-5 * Time.deltaTime, 0, 0);
                            }
                            else
                            {
                                sr.flipX = true;
                                //rb.AddForce(Vector2.right * 20);
                                transform.Translate(5 * Time.deltaTime, 0, 0);
                            }
                        }
                        if (hit_timer > 0)
                        {
                            hit_timer -= Time.deltaTime;
                        }
                        if (hit_timer <= 0)
                        {
                            phb.enemy = false;
                            onetimehit = false;
                        }
                    }

                }

            }
            moveCamera();
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
                Destroy(this.gameObject);
                Debug.Log(health);
            }
        }
        
    }

    public void died(){
        
    }
    public void letsTryDashNow()
    {
        if (!cinematic)
        {
            if (!DashCooldown)
            {
                speed = temp_speed2 * direction;
                DashCooldown = true;
                dashTime = dashMax;
            }
        }
        
    }

    public void iWannaJump()
    {
        if (!cinematic)
        {
            if (jump_Count == 1)
            {
                jump_Count--;
                rb.AddForce(Vector2.up * jumpForce);
                anim.Play("Jump");
                canJump = false;
            }
        }
        
    }

    public void letsAttackNow()
    {
        if (!cinematic)
        {
            if (!interact)
            {
                if (inair && !anim.GetCurrentAnimatorStateInfo(0).IsName("Jump_Attack"))
                {
                    anim.Play("Jump_Attack");
                    transform.Translate(direction * 0.1f, 0, 0);
                    Invoke("attackSpawn", 0.15f);

                }
                else if (!inair && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    Invoke("landAttack", 0);
                    aso.Play();
                    anim.Play("Attack");
                    transform.Translate(direction * 0.1f, 0, 0);
                }
            }
            else
            {
                CinematicMoveCamera.letInteract = true;
            }
        }
        
    }

    void landAttack()
    {
        GameObject ga = Instantiate(groundAttack, transform);
        if (sr.flipX)
        {
            ga.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            ga.transform.localScale = new Vector3(1, 1, 1);
        }
        Destroy(ga, 0.7f);
    }

    void attackSpawn()
    {
        GameObject ga = Instantiate(AirAttack, transform);
        if (sr.flipX)
        {
            ga.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            ga.transform.localScale = new Vector3(1, 1, 1);
        }
        Destroy(ga, 0.25f);
    }

    private void moveCamera()
    {
        if (moveCam)
        {
            float distance = Vector2.Distance(Camera.transform.position, transform.position);
            move_cam = transform.position;
        }
        else
        {
            move_cam = stop_c;
        }

        if ((transform.position.y > maxlowCam || transform.position.y < minhighCam) && transform.position.y >= minCam && transform.position.y <= maxCam)
        {
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, new Vector3(move_cam.x, transform.position.y, -10), 2 * Time.deltaTime);
        }
        else
        {
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, new Vector3(move_cam.x, norCam, -10), 2 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            anim.Play("Idle");
            canJump = true;
            jump_Count = 1;
            inair = false;
        }
        if(collision.gameObject.tag == "Slop")
        {
            rb.velocity = Vector2.zero;
            anim.Play("Idle");
            canJump = true;
            jump_Count = 1;
            inair = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Slop")
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.gravityScale = 1;
            }
            else
            {
                rb.gravityScale = 0;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            inair = true;
        }
            if (collision.gameObject.tag == "Slop")
        {
            rb.gravityScale = 1;
            inair = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stop_Cam")
        {
            stop_c = collision.transform.position;
            moveCam = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stop_Cam") 
        {
            moveCam = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop_Cam")
        {
            moveCam = true;
        }
    }
}
