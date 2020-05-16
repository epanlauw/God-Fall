using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Jump_Show : MonoBehaviour
{
    public GameObject ui;
    private void Awake()
    {
        ui.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ui.SetActive(false);
        }
    }
}
