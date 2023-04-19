using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    public GameObject Target;

    public void OnClicked()
    {
        Target.GetComponent<IChangeColor>().SetColor(Color.blue);
    }
}
