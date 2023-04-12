using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgePatroling : MonoBehaviour
{

    [SerializeField]
    Transform CastPoint;

    [SerializeField]
    private LayerMask WhatIsGround;

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
            Rotate();

        Move();
    }

    private bool EdgeDetected()
    {
        if (Physics.Raycast(CastPoint.position, Vector3.down, 2, WhatIsGround))
        {
            return true; 
        }
        return false;
    }
}
