using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIDscript : MonoBehaviour
{

    //тут занесена информация о пушке и небольшая защита от стрельбы из не подобранного оружия, а так же проверка на тип пуль, которыми стреляет оружие
    public GameObject bullet;
    public int ID;
    public int ammo;
    public int maxShoots;
    public int shoots;
    public int reloadTime;
    public bool isAbleToShoot = true;
    public bool isEnoughAmmo;
    public GameObject[] endings = new GameObject[1];
    public int typeOfAmmo;

    private Player playerScr;
    private void Start()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        playerScr = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {

        //выключем "конец ствола" что  бы он не детектился скриптом Shoot.cs
        if (gameObject.GetComponent<ItemDescription>().isDropped)
        {
            endings[0].SetActive(false);
            endings[1].SetActive(false);
        }
        else
        {
            endings[0].SetActive(true);
            endings[1].SetActive(true);
        }

        //выбор, какими патронами стрелять (всего 5 типов)
        switch (typeOfAmmo)
        {
            case 1: ammo = playerScr.ammoType1Inventory;
                break;
            case 2: ammo = playerScr.ammoType2Inventory;
                break;
            case 3: ammo = playerScr.ammoType3Inventory;
                break;
            case 4: ammo = playerScr.ammoType4Inventory;
                break;
            case 5: ammo = playerScr.ammoType5Inventory;
                break;
        }
    }

}
