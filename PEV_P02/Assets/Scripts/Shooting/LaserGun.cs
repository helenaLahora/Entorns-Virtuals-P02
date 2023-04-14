using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField]
    private Transform LaserPoint;

    public Transform EndLaser;

    [SerializeField]
    private LayerMask WhatIsShootable;

    private LineRenderer _lineRenderer;
    private Vector3 lastHit;

    [SerializeField]
    private LayerMask Shootable; // Define the Shootable layer mask

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L)) // getkey --> metralleta // getkeydown --> cada clic
        {
            TryShoot();
        }
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
        RaycastHit hit;
        if (Physics.Raycast(LaserPoint.position, LaserPoint.forward, out hit, 10, WhatIsShootable)) // si troba alguna cosa dira que ha trobat
                                                                                                    // que transforma, cap a on, on es guarda, quants metres te de llarg, què pot interactuar amb raycast
        {
            Debug.Log(hit.transform.name);
            lastHit = hit.point;

            if (WhatIsShootable == Shootable)
            {
                var damageReceiver = hit.transform.GetComponent<ITakeDamage>();
                if (damageReceiver != null)
                {
                    damageReceiver.TakeDamage(42);
                }
                lastHit = hit.point;
            }
            else
            {
                lastHit = hit.point;
            }
        }
        SetLaser();
    }

    private bool CanShoot()
    {
        return true;
    }

    void SetLaser()
    {
        _lineRenderer.SetPosition(0, LaserPoint.position);
        _lineRenderer.SetPosition(1, lastHit);
        EndLaser.position = lastHit;
    }
}