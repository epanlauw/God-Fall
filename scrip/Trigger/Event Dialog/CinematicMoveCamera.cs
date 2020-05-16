using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CinematicMoveCamera : MonoBehaviour
{
    public Transform cameraz;
    public enum Testing { Opening_cut, Dialog_on_first_stage, Ok, change_interact_001, Dialog_on_zeus_01 };
    public Testing testing;
    public GameObject dialog;
    public Transform[] pivot;
    public Animator controler;
    public Animator cinematicView;
    public AudioSource audio;
    public Text T_Name;
    public Text T_chat;
    private float te = 1;
    private bool hit = false;
    private bool onetime = false;
    private BoxCollider2D col;

    public string[] name;
    [TextArea(0, 200)]
    public string[] text;
    [Range(0.1f, 0.5f)]
    public float[] m_characterInterval;

    private bool done = false;
    private bool textFill = false;
    private string nowLetsTextItOut = "";
    private float counterTime = 0;
    private int countFor = 0;

    public static bool letInteract = false;



    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            
            switch (testing)
            {
                case Testing.Dialog_on_first_stage:
                    if (onetime)
                    {
                        done = false; textFill = false;
                        countFor = 0;
                        controler.Play("ControlerFadeOut");
                        cinematicView.Play("fadeIn");
                        onetime = false;
                        te = 1;
                    }
                    Dialog_on_first_stage();
                    break;
                case Testing.change_interact_001:

                    change_interact_001();
                    break;
                case Testing.Dialog_on_zeus_01:
                    if (onetime)
                    {
                        done = false; textFill = false;
                        countFor = 0;
                        controler.Play("ControlerFadeOut");
                        cinematicView.Play("fadeIn");
                        onetime = false;
                        te = 1;
                    }
                    Dialog_on_zeus_01();
                    break;
                default:
                    break;
            }
        }
    }

    void Dialog_on_zeus_01()
    {
        if (!done)
        {
            float distance = Vector3.Distance(new Vector3(cameraz.position.x, cameraz.position.y, cameraz.position.z), new Vector3(pivot[0].position.x, pivot[0].position.y, cameraz.position.z));
            if (distance > 0.2f)
            {
                cameraz.position = Vector3.Lerp(new Vector3(cameraz.position.x, cameraz.position.y, cameraz.position.z), new Vector3(pivot[0].position.x, pivot[0].position.y, cameraz.position.z), 1f * Time.deltaTime);
            }
            else
            {
                if (te == 1)
                {
                    dialog.SetActive(true);
                    te--;
                }
                if (countFor < text.Length)
                {
                    if (!textFill)
                    {
                        counterTime += Time.deltaTime;
                        if (counterTime >= m_characterInterval[countFor] && nowLetsTextItOut.Length < text[countFor].Length)
                        {
                            nowLetsTextItOut += text[countFor][nowLetsTextItOut.Length];
                            counterTime -= m_characterInterval[countFor];
                        }
                        T_Name.text = name[countFor];
                        T_chat.text = nowLetsTextItOut;
                        if (T_chat.text == text[countFor])
                        {
                            textFill = true;
                        }
                    }
                    else
                    {
                        nowLetsTextItOut = "";
                        counterTime = 0;
                    }

                }
                if (countFor >= text.Length)
                {
                    done = true;

                }

            }
        }
        else
        {
            
        }
    }

    void Dialog_on_first_stage()
    {
        if (!done)
        {
            float distance = Vector3.Distance(new Vector3(cameraz.position.x, cameraz.position.y, cameraz.position.z), new Vector3(pivot[0].position.x, pivot[0].position.y, cameraz.position.z));
            if (distance > 0.2f)
            {
                cameraz.position = Vector3.Lerp(new Vector3(cameraz.position.x, cameraz.position.y, cameraz.position.z), new Vector3(pivot[0].position.x, pivot[0].position.y, cameraz.position.z), 1f * Time.deltaTime);
            }
            else
            {
                if (te == 1)
                {
                    dialog.SetActive(true);
                    te--;
                }
                if(countFor < text.Length)
                {
                    if (!textFill)
                    {
                        counterTime += Time.deltaTime;
                        if(counterTime >= m_characterInterval[countFor] && nowLetsTextItOut.Length < text[countFor].Length)
                        {
                            nowLetsTextItOut += text[countFor][nowLetsTextItOut.Length];
                            counterTime -= m_characterInterval[countFor];
                        }
                        T_Name.text = name[countFor];
                        T_chat.text = nowLetsTextItOut;
                        if (T_chat.text == text[countFor])
                        {
                            textFill = true;
                        }
                    }
                    else
                    {
                        nowLetsTextItOut = "";
                        counterTime = 0;
                    }

                }
                if(countFor >= text.Length)
                {
                    done = true;

                }
                
            }
        }
        else
        {
            SceneManager.LoadScene("Stage02");
        }
    }

    void change_interact_001()
    {
        if (letInteract)
        {
            player_move_Test001.cinematic = true;
            Time.timeScale = 0;
            dialog.SetActive(true);
        }
        else
        {
            player_move_Test001.cinematic = false;
            player_move_Test001.interact = true;
            dialog.SetActive(false);
        }
    }

    public void zeusPlace()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Zeus01");
        audio.Play();
        //Debug.Log("lets go to zeus place");
        letInteract = false;
    }
    public void cancelRight()
    {
        audio.Play(0);
        Time.timeScale = 1;
        letInteract = false;
    }

    public void nextText()
    {
        if(textFill && !done)
        {
            nowLetsTextItOut = "";
            T_chat.text = "";
            counterTime = 0;
            countFor++;
            if(this.countFor >= this.text.Length)
            {
                done = true;
            }
            else
            {
                textFill = false;
            }

        }else if(!textFill)
        {
            this.textFill = true;
            this.counterTime = 0;
            this.nowLetsTextItOut = "";
            this.T_chat.text = this.text[countFor];
        }
        if (done && textFill)
        {
            this.counterTime = 0;
            dialog.SetActive(false);
            controler.Play("ControlerFadeIn");
            cinematicView.Play("fadeOut");
            col.enabled = false;
            player_move_Test001.cinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hit = true;
            onetime = true;
            player_move_Test001.cinematic = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(testing != Testing.Dialog_on_first_stage)
            {
                onetime = true;
                hit = false;
                player_move_Test001.interact = false;
                letInteract = false;
            }
        }
    }
}
