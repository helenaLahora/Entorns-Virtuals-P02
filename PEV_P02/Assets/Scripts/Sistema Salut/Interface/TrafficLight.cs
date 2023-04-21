using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour , IChangeColor
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
        if(color == Color.blue)
        {
            Debug.LogError("No hi ha semàfors blaus, merluzo");
            return;
        }
        _currentColor = color;
        GetComponent<Renderer>().material.color = _currentColor;
    }
}

