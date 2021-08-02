using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{


    public GameObject panel;
    public static bool escapeMenuEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);
                escapeMenuEnabled = false;
            }
            else
            {
                panel.SetActive(true);
                escapeMenuEnabled = true;
            }

        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
