using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    Transform _Players;

    float DetectionRage = 10;

    // Update is called once per frame
    void Update()
    {
        if (IsInRange())
        {
            Debug.Log("Detected");
            if (IsInFOV())
            {
                if (!IsBlocked())
                {

                }
            }
        }
    }

    private bool IsInRange()
    {
        return Vector3.Distance(transform.position, _Players.position) < DetectionRage;
    }
}
