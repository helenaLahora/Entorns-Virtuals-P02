using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    Transform _Player;

    [SerializeField]
    [Range(0,10)]
    float DetectionRage = 10;

    [SerializeField]
    [Range(0, 120)]
    float FOV = 90;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRage);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange())
        {
            Debug.Log("Detected Range");
            if (IsInFOV())
            {
                Debug.Log("IN FOV");
                  if (!IsBlocked())
                 {

                 }
            }
        }
    }

    private bool IsBlocked()
    {

    }

    private bool IsInFOV()
    {
        float halfFOV = FOV/2;
        Vector3 a = transform.forward;
        Vector3 b = _Player.position;
        float playerAngle = Vector3.Angle(a,b);

        return playerAngle <= halfFOV;
    }

    private bool IsInRange()
    {
        return Vector3.Distance(transform.position, _Player.position) < DetectionRage;
    }
}
