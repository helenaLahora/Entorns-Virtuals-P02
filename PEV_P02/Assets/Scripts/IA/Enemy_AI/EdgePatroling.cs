using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgePatroling : MonoBehaviour
{

    [SerializeField]
    Transform CastPoint;

    [SerializeField]
    private LayerMask WhatIsGround;

    [SerializeField]
    float Speed = 3f;

    private float maxDistToGround = 2f;

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
        {
            Rotate();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float rot = UnityEngine.Random.Range(90,270);
        transform.Rotate(new Vector3(0, rot, 0));
    }

    private bool EdgeDetected()
    {
        if (Physics.Raycast(CastPoint.position, Vector3.down, maxDistToGround, WhatIsGround))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
