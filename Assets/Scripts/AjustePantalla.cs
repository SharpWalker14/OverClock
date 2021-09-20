using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustePantalla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tamanos(16, 9);
    }
    void Tamanos(float ancho, float altura)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > ancho / altura)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (ancho / altura)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (altura / ancho)), true);
        }
    }
}
