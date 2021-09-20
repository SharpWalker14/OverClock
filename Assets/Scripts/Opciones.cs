using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    public Text sensibilidadTexto;
    public Text volumenTexto;

    public Slider sensibilidadSlider;
    public Slider volumenSlider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sensibilidadSlider.maxValue = 150f;
        sensibilidadSlider.minValue = 30f;
        sensibilidadSlider.value = ControladorDeJuego.sensibilidadMouse;
        sensibilidadTexto.text = "" + ControladorDeJuego.sensibilidadMouse;
    }
    public static void CambiarSensibilidad(float nuevaSensibilidad)
    {
        ControladorDeJuego.sensibilidadMouse = nuevaSensibilidad;
    }
}
