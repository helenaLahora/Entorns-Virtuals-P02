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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRage);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange())
        {
            Debug.Log("Detected");
            //if (IsInFOV())
            //{
              //  if (!IsBlocked())
               // {

               // }
          //  }
        }
    }

    private bool IsInRange()
    {
        return Vector3.Distance(transform.position, _Player.position) < DetectionRage;
    }
}
