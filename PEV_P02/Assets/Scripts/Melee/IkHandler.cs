using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkHandler : MonoBehaviour
{

    private Animator _animator;

    [SerializeField]
    Transform RightHandTarget;

    [SerializeField]
    [Range(0, 1)]
    float Weight = 1;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, Weight);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandTarget.position);
    }
}
