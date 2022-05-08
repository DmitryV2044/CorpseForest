using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Searcher : MonoBehaviour
{
    public GameObject WhatIFind;    //любой другой предмет, который попал в наше поле зрения(если не сортировать то там будут и стены)
    public GameObject Weapon;       //оружие, которое можно подобрать

    private Button GrabButt;        //кнопка "подобрать"
    private Player player;          //скрипт на игроке

    //получаем нужные компоненты
    private void Awake()
    {
        GrabButt = GameObject.FindGameObjectWithTag("GrabButton").GetComponent<Button>();
        GrabButt.interactable = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //скрипт, выполняемый при соприкосновении с триггером (предметом)
    private void OnTriggerStay2D(Collider2D collision)
    {
        //узнаем, что это за объъект
        WhatIFind = collision.GetComponent<ItemDescription>().ThisObject;

        if (WhatIFind.CompareTag("Item_Weapon") || WhatIFind.CompareTag("Ammo") || WhatIFind.CompareTag("Money"))
        {
            //включаем кнопку, если мы нашли оружие или патроны
            GrabButt.interactable = true;
            //можно раскомментировать 2 строки ниже что бы провести мини DEBUG
            //Debug.Log("I've found s-th!");
            //Debug.Log(collision.GetComponent<Collider2D>().name);

            //узнаем, что именно мы нашли(фильтруем)
            if (WhatIFind.CompareTag("Item_Weapon"))
            {
                //Debug.Log("It's a weapon!");
                Weapon = WhatIFind;
            }
            else if (WhatIFind.CompareTag("Ammo"))
            {
               // Debug.Log("It's an Ammo!");
            }
        }
        else if (WhatIFind.CompareTag("resource"))
        {
            GrabButt.interactable = true;
            switch (WhatIFind.GetComponent<ItemDescription>().id)
            {
                case 6:
                    Debug.Log("IRON!!!");
                    break;
                case 7:
                    Debug.Log("NOT IRON!!!");
                    break;
            }

        }
        else return; //если это нельзя подобрать, то по новой, пока чето не найдем
    }
    //когда отходим от предмета ,что бы кнопка выключалась 
    private void OnTriggerExit2D(Collider2D collision)
    {
        GrabButt.interactable = false;
    }
}
