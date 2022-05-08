using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomiser : MonoBehaviour
{
    //fire buttons
    public GameObject FireButton1;
    public GameObject FireButton2;
    private int fbType;

    private void Awake()
    {
        FireButton1.SetActive(false);
        FireButton2.SetActive(false);
    }

    private void Update()
    {
        fbType = PlayerPrefs.GetInt("FireButtType");
        if (fbType == 0)
        {
            FireButton1.SetActive(true);
            FireButton2.SetActive(false);
        }

        else
        {
            FireButton2.SetActive(true);
            FireButton1.SetActive(false);
        }
    }
}
