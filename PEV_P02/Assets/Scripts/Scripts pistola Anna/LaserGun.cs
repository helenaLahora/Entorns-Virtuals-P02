//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LaserGun : MonoBehaviour
//{
//    [SerializeField]
//    Transform LaserPoint;

//    public Transform EndLaser;

//    [SerializeField]
//    LayerMask WhatIsShootable;

//    LineRenderer _lineRenderer;

//    Vector3 lasthit;

//    private void Start()
//    {
//        _lineRenderer = GetComponent<LineRenderer>();
//    }    

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKey(KeyCode.L)) //getkey --> metralleta //getkeydown --> cada clic
//        {
//            TryShoot();
//        }
//    }

//    void TryShoot()
//    {
//        if (CanShoot())
//        {
//            Shoot();
//        }
//    }
//    private void Shoot()
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(LaserPoint.position, LaserPoint.forward, out hit, 10, WhatIsShootable)) //si troba alguna cosa dira que ha trobat
//                            //que transforma, cap a on, on es guarda, quants metres té de llarg, què pot interactuar amb raycast
//        {
//            Debug.Log(hit.transform.name);
//            lasthit = hit.point;

//            if(WhatIsShootable = Shootable)
//            {
//                var damageReciever = hit.transform.GetComponent<ITakeDamage>();
//                if(damageReciever != null)
//                {
//                    damageReciever.TakeDamage(42);
//                }
//                lasthit = hit.point;
//            }
//            else
//            {
//                lasthit = hit.point;
//            }
//        }        
//        SetLaser();
//    }

//    private bool CanShoot() 
//    {
//        return true; 
//    }

//    void SetLaser() //
//    {
//        _lineRenderer.SetPosition(0, LaserPoint.position);
//        _lineRenderer.SetPosition(1, lasthit);
//        EndLaser.position = lasthit;
//    }
//}