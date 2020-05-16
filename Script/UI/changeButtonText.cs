using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeButtonText : MonoBehaviour
{
    private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_move_Test001.interact)
        {
            txt.text = "Interact";
        }
        else
        {
            txt.text = "Attack";
        }
    }
}
