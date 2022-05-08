using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] InventoryForGuns = new GameObject[2];

    private int Slot = 0;

    //заносим в массив объекты
    private void Start()
    {
        InventoryForGuns[0] = GameObject.FindGameObjectWithTag("FirstSlot");
        InventoryForGuns[1] = GameObject.FindGameObjectWithTag("SecondSlot");
        InventoryForGuns[2] = GameObject.FindGameObjectWithTag("ThirdSlot");

        //дделаем активным только первый слот(дефолтный)
        InventoryForGuns[1].SetActive(false);
        InventoryForGuns[2].SetActive(false);
    }

    //по нажатии кнопки смены оружиия
    public void ChangeWeapon()
    {
        //выбираем сл слот
        if (Slot < 2) Slot++;

        else if (Slot == 2) Slot = 0;

        //выключаем все слоты
        InventoryForGuns[0].SetActive(false);
        InventoryForGuns[1].SetActive(false);
        InventoryForGuns[2].SetActive(false);
        //включаем нужный
        InventoryForGuns[Slot].SetActive(true);
    }
}
