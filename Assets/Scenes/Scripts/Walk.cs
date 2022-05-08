using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public RectTransform handle;        //кружок, за который ты тянешь, что бы ходить
    public GameObject player;           //Объект игрока
        
    public SpriteRenderer playerimg;    //спрайт, который мы будеим двигать
    public GameObject playerPic;        //хз зачем
    public Rigidbody PlayerRB;          //тоже в помойку

    public int speedModifier = 10;      //скорее не модифаер, а наоборот(чем меньше модифаер, тем быстрее игрок)
    public float speed;

    public bool isRunning = false;      //проверка на бег
    public bool isResting = false;      //проверка на отдых
    public Player Playerscript;         //скрипт игрока

    public Joystick MainJoystick;       //джойтик(скрипт для получения вектора движения)
    public Joystick RotationJoystick;   //джойтик(скрипт для получения вектора поворота)

    public FloatingJoystick isJoystickInUse; //проверяем, хотим ли мы повернутся

    void FixedUpdate()
    {
        //Debug.Log(handle.localPosition.magnitude);
        //если не ходим - значит отджыхаем
        if (handle.localPosition.magnitude == 0 && isRunning == false)
        {
            isResting = true;
            //Debug.Log("HAVING A REST(just staying)");
        }
        //в противном случае - не отдыхаем
        else//123
        {
            isResting = false;
        }

        //walk dir and speed //направление движения и скорость
        player.transform.Translate(MainJoystick.Direction / speedModifier);

        //rotation BUGREPORT: after joystick.Vector2(0,0), player direction == 0 deg //fixed
        //если касаемся дожойстика поворотоа, то можем вращатся, если нет, то созраняется последнее значение поворота
        if(isJoystickInUse.isTapped)
        {
            //тут думаю все понятно
            Vector2 direct = Vector3.RotateTowards(playerimg.transform.forward, RotationJoystick.Direction, 10, 0.0f);
            playerimg.transform.rotation = Quaternion.LookRotation(playerimg.transform.forward, direct);

        }
        //Debug.Log(MainJoystick.Direction); //DEBUG
    }
    //активируется по нажатию кнопки бега
    public void Running()
    {
        //проверяем, хватает ли стамины и не бежим ли мы уже
        if (Playerscript.stamina > 0 && isRunning == false)
        {
            isRunning = true;   //сообщаем, что бежим
            speedModifier = 5;  //ускоряемся
        }
        else if (isRunning)     //если уже бежим и нажали кнопку бега или кончилась стамина и первый if не выполнился
        {
            isRunning = false;  //сообщаем, что уже не бежим
            speedModifier = 10; //возвращаем скорость на норм
        }
        else //если нажали но не бежим и нет стамины => стамины нет (нужно только для теста)
        {
            print("NOT ENOUGH STAMINA!");
        }
    }
}
