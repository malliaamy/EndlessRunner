using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleScript : MonoBehaviour
{
    public Toggle toggler;
    // Start is called before the first frame update
    void Start()
    {
        toggler = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicToggle()
    {
        if (toggler.isOn)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 2);
        }
    }
}
