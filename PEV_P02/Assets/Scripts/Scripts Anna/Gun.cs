using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Bullet BulletPrefab;

    [SerializeField]
    Transform FirePoint;

    [SerializeField]
    float CoolDownTime;

    [SerializeField]
    float FireSpeed;

    float _lastShotTime;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //getkey --> metralleta //getkeydown --> cada clic
        {
            TryShoot();
        }
    }
    private void Start()
    {
        Invoke("DoAutoFire", 1); //algu ha de cridar que comenci el bucle del autofire
    }

    void DoAutoFire()
    {
        Shoot();
        Invoke("DoAutoFire", 1);
    }

    void TryShoot()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.Init(FireSpeed);
        _lastShotTime = Time.time; //guardem quan vam fer l'última bala
    }

    private bool CanShoot() //podra fer canShoot segons les condicions que li haguem dit de temps entre bales
    {
        return (_lastShotTime + CoolDownTime) <= Time.time; //a partir del lastShot, podrem tornar a disparar quan passi el cooldown
    }
}
