using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentPuddle : MonoBehaviour
{
    public SpriteRenderer puddle;
    private EnviromentScript EnviromentScript;

    private bool RainStarted = false;
    private bool RainEnded = true;

    private void Start()
    {
        EnviromentScript = GetComponentInParent<EnviromentScript>();    //ищем нужный скрипт с показаниями о дожде
        puddle = GetComponent<SpriteRenderer>();                        //ищем спрайт рендерер
        puddle.color = new Color(1, 1, 1, 0);                           //задаем изначальные значениея
    }
    private void Update()
    {

        //проверка на дождь
        if (EnviromentScript.isRainy)
        {
            if (RainStarted == false)
            {
                StartCoroutine(RainStart());
            }
        }
        else
        {
            RainStarted = false;
        }
        //проверка на его отсутсвие
        if (EnviromentScript.isRainy == false)
        {
            if (RainEnded)
            {
                StartCoroutine(RainEnd());
            }
        }
        else
        {
            RainEnded = true;
        }

    }

    //корутина, включающая лужи
    IEnumerator RainStart()
    {
        RainStarted = true;
        for(float i = 0f; i <= 1; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            puddle.color = new Color(1, 1, 1, i);
        }
    }

    //соотвественно выключающая их
    IEnumerator RainEnd()
    {
        RainEnded = false;
        for (float i = 1f; i >= 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.5f);
            puddle.color = new Color(1, 1, 1, i);
        }
    }
}
