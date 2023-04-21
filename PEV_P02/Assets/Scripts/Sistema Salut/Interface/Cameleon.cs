using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameleon : MonoBehaviour , IChangeColor
{

    Color _currentColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetColor()
    {
        return _currentColor;
    }

    public void SetColor(Color color)
    {
        _currentColor = color;
        GetComponent<Renderer>().material.color = _currentColor;
    }
}
