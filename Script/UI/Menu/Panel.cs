using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Awake(){
        
    }
    void Start()
    {
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void game()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void muncul()
    {
        panel.SetActive(true);
    }
    public void hilang()
    {
        panel.SetActive(false);
    }

}
