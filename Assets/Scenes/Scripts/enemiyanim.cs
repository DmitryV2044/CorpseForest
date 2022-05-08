using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 
 
    LEGACY CODE / НЕ ИСПОЛЬЗУЕМЫЙ КОД

 
 */

public class enemiyanim : MonoBehaviour
{
    public GameObject[] animpic = new GameObject[5];
    int i = 0;

    private void Start()
    {
        StartCoroutine(Animka());
    }
    
   

    IEnumerator Animka()
    {

        while (true)
        {
            animpic[5].SetActive(false);
            animpic[0].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            animpic[0].SetActive(false);
            animpic[1].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            animpic[1].SetActive(false);
            animpic[2].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            animpic[2].SetActive(false);
            animpic[3].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            animpic[3].SetActive(false);
            animpic[4].SetActive(true);

            yield return new WaitForSeconds(0.2f);

            animpic[4].SetActive(false);
            animpic[5].SetActive(true);
            i++;
        }
    }
}
