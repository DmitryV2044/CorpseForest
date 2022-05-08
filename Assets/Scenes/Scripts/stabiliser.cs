using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * 
 * 
 *  LEGACY CODE / УСТАРЕВШИЙ КОД (НЕ ИСПОЛЬЗУЕТСЯ)
 * 
 * 
 */

public class stabiliser : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    private void FixedUpdate()
    {
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

}
