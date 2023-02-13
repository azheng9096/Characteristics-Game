using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform RANGEDPOINT;
    public GameObject bullet;

    public float bulletForce;

    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
       {
            Shoot();
       } 
    }

    void Shoot()
    {
        GameObject bullts = Instantiate(bullet, RANGEDPOINT.position, RANGEDPOINT.rotation);
        Rigidbody2D rb = bullts.GetComponent<Rigidbody2D>();
        rb.AddForce(RANGEDPOINT.up * bulletForce, ForceMode2D.Impulse);
    }

}
