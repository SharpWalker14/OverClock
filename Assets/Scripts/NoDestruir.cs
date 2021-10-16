using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    [HideInInspector]
    public float sensibilidadMouse, volumen;
    [HideInInspector]
    public bool ventana;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        ventana = false;
        sensibilidadMouse = 70;
        volumen = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Ajustador();
    }

    /*void Ajustador()
    {
        if (ventana)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
            TamanoVentana();
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            TamanoPantallaCompleta(16, 9);
        }
    }
    void TamanoPantallaCompleta(float ancho, float altura)
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
    void TamanoVentana()
    {
        Screen.SetResolution(1024, 576, false);
    }*/
}
