using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    //описание предмета (должно быть нацепленно на все предметы, которые можно выбросить и(или) подобрать)
    public GameObject ThisObject;       //ссылка на этот объект
    public Sprite DroppedItem;          //спрайт, когда выброшено
    public Sprite WearedItem;           //спрайт, когда в руках(в инвентаре)
    public Sprite InIventory;
    public int quantity;                //кол-во предмета (пока что нужно только для патрон)
    public int type;                    //тип (касается только патрон)
    public int id;
    private SpriteRenderer sprites;     //спрайт, нацепленный в момент старта
    private Vector3 zeroPos;            //нудевые координаты(нужны для проверки на подобранность)
    public bool isDropped = true;
    
    //заносим нужные значения
    private void Start()
    {
        ThisObject = gameObject;
        zeroPos = new Vector3(0, 0, 0);
        sprites = GetComponent<SpriteRenderer>();
    }

    //проверяем брошениы или нет
    private void Update()
    {
        if (gameObject.transform.localPosition == zeroPos)
        {
            sprites.sprite = WearedItem;
            isDropped = false;

        }
        else
        {
            sprites.sprite = DroppedItem;
            isDropped = true;
        }
    }
}
