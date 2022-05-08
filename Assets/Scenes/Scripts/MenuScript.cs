using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    public GameObject pauseButt;
    public GameObject MenuPan;
    public Text FireButtTypeTXT;

    private void Start()
    {
       // Debug.Log(Time.timeScale);
        if (PlayerPrefs.GetInt("FireButtType") == 0) FireButtTypeTXT.text = "Стандартная";
        else FireButtTypeTXT.text = "Альтернативная"; 
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseButt.SetActive(false);
        MenuPan.SetActive(true);
    }
    public void ChangeTheFireButtType()
    {
        if(PlayerPrefs.GetInt("FireButtType") == 0)
        {
            PlayerPrefs.SetInt("FireButtType", 1);
            FireButtTypeTXT.text = "Альтернативная";
        }
        else if (PlayerPrefs.GetInt("FireButtType") == 1)
        {
            PlayerPrefs.SetInt("FireButtType", 0);
            FireButtTypeTXT.text = "Стандартная";
        }
        Debug.Log(Time.timeScale);
    }
    public void Exit()
    {
        Time.timeScale = 1;
        pauseButt.SetActive(true);
        MenuPan.SetActive(false);
        Debug.Log(Time.timeScale);
    }
}
