using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    //работает
    [SerializeField] private GameObject Player;
    [SerializeField] private bool isAPlayerInSight = false;
    public int health = 8;
    private int speed = 3;
    private bool isDelauKycb = false;
    private bool walkAbility = true;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (health < 1) Destroy(gameObject);

        if(isAPlayerInSight)
        {
        var dir = Player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (walkAbility) 
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        var distacecalc = transform.position - Player.transform.position;
        var distance = distacecalc.magnitude;
        //Debug.Log(distance);
        if (distance < 1.25f) speed = 0;
        else speed = 3;

        if (distance < 1.35f)
        {
            if (isDelauKycb == false)
                StartCoroutine(Kycb());
            else return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isAPlayerInSight = true;
        //Debug.Log("МОЗГИИИ");
    }

    IEnumerator Kycb()
    {
        isDelauKycb = true;
        walkAbility = false;

        Player.GetComponent<Player>().health -= 10;
        yield return new WaitForSeconds(0.5f);
        walkAbility = true;
        yield return new WaitForSeconds(1.5f);
        isDelauKycb = false;
    }
}﻿
