using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    //сериализация только для проверки, что все работает правильно
    [SerializeField] private GameObject[] gunEnd = new GameObject[1];   //окончания ствола(там спавнятся пули)
    [SerializeField] private GameObject gun;                            //сама пушка
    [SerializeField] private GunIDscript GunInfo;                       //инфо о пушке в руках(скрипт)
    [SerializeField] private GameObject bullet;                         //пуля, которой будет стрелять пушка
    [SerializeField] private Button ShootButton;                 //кнопка смены оружия
    public int shoots = 0;                                              //сколько выстрелов сделано (нужно для перезарядки)
    private Player playerAmmo;                                          //сколько пуль в инвентаре
    private int i = 0;                                                  //номер ствола, из которого выходит пуля
    //получаем, чего нет изначально
    private void Start()
    {
        ShootButton = gameObject.GetComponent<Button>();
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    //shoot button //выполняется по нажатии на кнопку выстрела
    public void Shoot()
    {
        //проверяем, что за пушка в руках
        gun = GameObject.FindGameObjectWithTag("Weapon");
        GunInfo = gun.GetComponent<GunIDscript>();
        //проверяем, в инвентаре ли она (вроде не нужно, но лучше оставить)
        if(gun.GetComponentInParent<Transform>() == null)
            return;
        //Debug.Log(gun.GetComponentInParent<Transform>().name);

        //проверяем кол-во патронов
        if (GunInfo.ammo == 0) GunInfo.isEnoughAmmo = false;
        else GunInfo.isEnoughAmmo = true;

        //берем модельку пули
        bullet = GunInfo.bullet;
        //заносим 2 окончания
        gunEnd[0] = GameObject.FindGameObjectWithTag("gunEnd");
        gunEnd[1] = GameObject.FindGameObjectWithTag("gunEnd2");
        //проверяем, можно ли стрелять
        if (GunInfo.isAbleToShoot && GunInfo.isEnoughAmmo)
        {
            //есть ли вообще у пушки окончания(если нету, то значит что она валяется)
            if (gunEnd[0] != null)
            {
                //проверяем на второе окончание(если есть, то из него будем стрелять тоже)
                if (gunEnd[1] != null)
                {
                    //создаем копию префаба патрона
                    Instantiate(bullet, gunEnd[i].transform.position, gunEnd[i].transform.rotation);
                    GunInfo.shoots++; //добавлем выстрелы
                    //выбираем, какие патроны тратятся, в соотсветсии с видом патрон, указаным в GunInfo
                    switch (GunInfo.typeOfAmmo)
                    {
                        case 1: playerAmmo.ammoType1Inventory--;
                            break;
                        case 2: playerAmmo.ammoType2Inventory--;
                            break;
                        case 3: playerAmmo.ammoType3Inventory--;
                            break;
                        case 4: playerAmmo.ammoType4Inventory--;
                            break;
                        case 5: playerAmmo.ammoType5Inventory--;
                            break;
                    }
                    //номер ствола, из которого стреляем
                    if (i < 1) i++;
                    else i--;
                }
                //если у пушки только 1 конец, то стреляем из одного
                else
                {
                    Instantiate(bullet, gunEnd[0].transform.position, gunEnd[0].transform.rotation);
                    GunInfo.shoots++;
                    switch (GunInfo.typeOfAmmo)
                    {
                        case 1:
                            playerAmmo.ammoType1Inventory--;
                            break;
                        case 2:
                            playerAmmo.ammoType2Inventory--;
                            break;
                        case 3:
                            playerAmmo.ammoType3Inventory--;
                            break;
                        case 4:
                            playerAmmo.ammoType4Inventory--;
                            break;
                        case 5:
                            playerAmmo.ammoType5Inventory--;
                            break;
                    }
                }
                //проверяем, не пора ли перезарядится
                if (GunInfo.shoots % GunInfo.maxShoots == 0)
                {
                    StartCoroutine(Reload());
                }
            }
            else return;
        }
        else StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        gun.GetComponent<GunIDscript>().isAbleToShoot = false;
        yield return new WaitForSeconds(gun.GetComponent<GunIDscript>().reloadTime);    //ждем, пока перезарядится оружие (скорость перезарядки настраивается в GunInfo)
        gun.GetComponent<GunIDscript>().isAbleToShoot = true;
        StopAllCoroutines();
    }
}
