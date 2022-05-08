using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    public Walk walk;
    //проверка состояний
    private bool isRunning;                                                                                             //проверка на бег
    private bool isStartedToRun;                                                                                        //контрольная проверка на бег
    private bool isResting;                                                                                             //проверка на отдых
    public bool isStartedToRest;                                                                                        // контрольная проверка на отдых

    public GameObject bullet;                                                                                           //не помню зачем, но оно скорее всего нужно для работы Shoot.cs
    public GameObject thisPlayer;                                                                                       //ссылка на объект "игрок"
    public GameObject[] InventoryForGuns = new GameObject[2];                                                           //инвентарь для оружий (3 слота)
    public int ammoType1Inventory, ammoType2Inventory, ammoType3Inventory, ammoType4Inventory, ammoType5Inventory;      // инвентарь для патрон (5 слотов) 

    public float stamina = 100f;                                                                                        // тут думаю понятно
    public float health = 100f;
    public int money;

    [SerializeField]private GameObject FireButton;                                                                      //кнопка стерльбы
    private GameObject gun;                                                                                             //оружие, которое находится в руках

    private GameObject VisibilityForEnemies;

    public UnityEngine.UI.Image StaminaImg;                                                                             //изображение стамины(для визуализации уменьшения, увеличения)
    public UnityEngine.UI.Image HealthIMG;                                                                              //изображение здоровья(для визуализации уменьшения, увеличения)


    private void Awake()
    {
        //восстанавливаем последние сохраненные значения хп и стамины
        //stamina = PlayerPrefs.GetFloat("Stamina");
        //Debug.Log(stamina);
        //health = PlayerPrefs.GetFloat("Health");
        //Debug.Log(health);
        // сохранять каждую секнуду и вручную (НЕ РЕАЛИЗОВАННО)
    }

    //получаем все нужные компоненты
    private void Start()
    {
        thisPlayer = gameObject;

        StaminaImg = GameObject.Find("Stamina(filled)").GetComponent<UnityEngine.UI.Image>();

        HealthIMG = GameObject.Find("Health(filled)").GetComponent<UnityEngine.UI.Image>();

        VisibilityForEnemies = GameObject.FindGameObjectWithTag("Visibility For Enemies");
    }
    private void Update()
    {
        GameObject.Find("Money amount").GetComponent<Text>().text = Convert.ToString(money) + "$";
    }
    private void FixedUpdate()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //в настройках ее можно менять, поэтому надо регулярно ее получать заново
        FireButton = GameObject.FindGameObjectWithTag("FireButton");

        //заметность для зомбаков
        VisibilityForEnemies.transform.Rotate(new Vector3(0, 0, 150) * Time.deltaTime);

        // visual indicating of main stats визуальное отображение статов
        StaminaImg.fillAmount = stamina / 100;
        HealthIMG.fillAmount = health / 100;

        //проверка на наличие оружия в руках у игрока
        gun = GameObject.FindGameObjectWithTag("Weapon");

        //проверка на наличие пушки в руке
        if (gun == null)
            FireButton.SetActive(false);
        else
            FireButton.SetActive(true); 

        isResting = walk.isResting;

        //проверка на бег игрока
        isRunning = walk.isRunning;

        //запуск, когда не бежит игрок для проверки на бег, если игрок побежит, то корутина не будет запускатся много раз(возможно)
        if(isRunning)
        {
            if(isStartedToRun == false)
            {
                StartCoroutine(StaminaDecrease());
                isStartedToRun = true;
            }
        }
        // тута баг, корутна одноразовая UPD: bug fixed UPD: ломается после нескольких пробежек (FIXED!)
        if (stamina < 100 && isResting)
        {
            if (isStartedToRest == false)
            {
                StartCoroutine(StaminaFill());
                isStartedToRest = true;
            }
        }
    }

    //заполение стамины
    IEnumerator StaminaFill()
    {
        while(isResting && isRunning == false)
        {
            Debug.Log("refiling");
            if(stamina < 100)
            {
                //Debug.Log("refiling2");
                yield return new WaitForSeconds(0.3f);
                stamina++;
            }
            else
                break;     
        }
        isStartedToRest = false;
        //Debug.Log("Stamina Filled");
    }

    //уменьшение стамины 
    IEnumerator StaminaDecrease()
    {
        while (isRunning)
        {
            if (stamina > 0)
            {
                stamina--;
                yield return new WaitForSeconds(0.05f);
                //Debug.Log(stamina);
            }
            else
                break;
        }
        walk.isRunning = false;
        walk.speedModifier = 10;
        isStartedToRun = false;
    }
}
