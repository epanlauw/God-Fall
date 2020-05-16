using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_test : MonoBehaviour
{
    private Image me;
    public float health = 100f;
    public float regenSpeed = 1;
    private bool refresh = false;
    private float timer = 0;
    public float limit;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        me.fillAmount = health / 100;
        if (Input.GetMouseButtonDown(0))
        {
            timer = 0;
            health -= 20;
            refresh = true;
        }
        if (refresh)
        {
            if(timer < limit)
            {
                timer += Time.deltaTime;
            }
            if(timer >= limit)
            {
                health += regenSpeed;
            }
            if(health >= 100)
            {
                refresh = false;
            }
        }
    }
}
