using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   // public GameObject player;
    public GameObject bullet;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject whoShootedIn;
    public float speed = 0.5f;
    private bool shoot = false;

   // private float flightDist = 1;

    private void Awake()
    {
        gun = GameObject.FindGameObjectWithTag("gunEnd");
        Debug.Log(gun.name);
    }

    private void Start()
    {
        StartCoroutine(FlightTime());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed);
    }

    IEnumerator FlightTime()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(bullet);
    }

    public void TestTheShoot()
    {
        shoot = !shoot;
        StartCoroutine(FlightTime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        whoShootedIn = collision.gameObject;
        if (whoShootedIn.CompareTag("Zombie"))
        {
           whoShootedIn.GetComponent<ZombieAI>().health -= 4;
           Destroy(gameObject);
        }
        else if (whoShootedIn.CompareTag("Player"))
        {
            whoShootedIn.GetComponent<Player>().health -= 30;
        }
        Destroy(gameObject);
    }
}
