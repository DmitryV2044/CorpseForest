using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject Weapon;      //оружие, которыое мы нашли(если не нашли, то Null)
    public Player WeaponInventory; //берем скрипт, привязанного к игроку
    public Searcher Search;        // еще один скрипт, но уже который совершает поиск предметов
    public GameObject NotEnoughSpace;
    private GameObject[] localInventoryForGuns = new GameObject[2];
    private int which_slot_is_active = 0;

    private void Awake()
    {
        // ищем нужные скрипты по тегам
        WeaponInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Search = GameObject.FindGameObjectWithTag("Searcher").GetComponent<Searcher>();
    }
    private void Update()
    {
        //проверяем, что нашли
        Weapon = Search.Weapon;
    }

    public void GrabIt()
    {
        //проверяем, нашли ли мы оружие
        if (Weapon != null)
        {
            //меняем тег, что бы Searcher его случайно не подобрал(проще говоря, что бы не дюпнулось)
            Weapon.tag = "Weapon";
            //вектор (0 0 0)
            Vector3 SetPos = WeaponInventory.InventoryForGuns[0].transform.position;

            Weapon.transform.localScale = Weapon.transform.localScale * 10;
            //распредление в первую свободную ячейку
            if (WeaponInventory.InventoryForGuns[0].transform.childCount == 0)
            {
                Instantiate(Weapon, SetPos, WeaponInventory.InventoryForGuns[0].transform.rotation, WeaponInventory.InventoryForGuns[0].transform);
            }
            else if (WeaponInventory.InventoryForGuns[1].transform.childCount == 0)
            {
                Instantiate(Weapon, SetPos, WeaponInventory.InventoryForGuns[1].transform.rotation, WeaponInventory.InventoryForGuns[1].transform);
            }
            else if (WeaponInventory.InventoryForGuns[2].transform.childCount == 0)
            {
                Instantiate(Weapon, SetPos, WeaponInventory.InventoryForGuns[2].transform.rotation, WeaponInventory.InventoryForGuns[2].transform);
            }
            else {
                while (which_slot_is_active < 3)
                {
                    if (WeaponInventory.InventoryForGuns[which_slot_is_active].activeSelf) break;
                    else which_slot_is_active++;
                }
                WeaponInventory.InventoryForGuns[which_slot_is_active].transform.GetChild(0).gameObject.tag = "Item_Weapon";
                Instantiate(WeaponInventory.InventoryForGuns[which_slot_is_active].transform.GetChild(0).gameObject, WeaponInventory.thisPlayer.transform.position, WeaponInventory.InventoryForGuns[which_slot_is_active].transform.rotation);
                Destroy(WeaponInventory.InventoryForGuns[which_slot_is_active].transform.GetChild(0).gameObject);
                Instantiate(Weapon, SetPos, WeaponInventory.InventoryForGuns[which_slot_is_active].transform.rotation, WeaponInventory.InventoryForGuns[which_slot_is_active].transform);
            }
            //уничтожаем объект, валяющийся на землеы
            Destroy(Weapon);
        }

        //проверка на находку патронов
        else if (Search.WhatIFind.CompareTag("Ammo"))
        {
            //прибавляем в инвентрарь опредеенное кол-во патронов нужного типа
            switch (Search.WhatIFind.GetComponent<ItemDescription>().type)
            {
                case 1:
                    WeaponInventory.ammoType1Inventory += Search.WhatIFind.GetComponent<ItemDescription>().quantity;
                    break;
                case 2:
                    WeaponInventory.ammoType2Inventory += Search.WhatIFind.GetComponent<ItemDescription>().quantity;
                    break;
                case 3:
                    WeaponInventory.ammoType3Inventory += Search.WhatIFind.GetComponent<ItemDescription>().quantity;
                    break;
                case 4:
                    WeaponInventory.ammoType4Inventory += Search.WhatIFind.GetComponent<ItemDescription>().quantity;
                    break;
                case 5:
                    WeaponInventory.ammoType5Inventory += Search.WhatIFind.GetComponent<ItemDescription>().quantity;
                    break;
            }
            //уничтожаем объект, лежащий на земле
            Destroy(Search.WhatIFind);
        }
        else if (Search.WhatIFind.CompareTag("Money"))
        {
            WeaponInventory.money += Search.WhatIFind.GetComponent<ItemDescription>().quantity;
            Destroy(Search.WhatIFind);
        }
    }
}
