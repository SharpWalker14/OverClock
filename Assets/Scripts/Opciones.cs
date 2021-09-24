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
    private GameObject nucleo;
    private NoDestruir datos;

    void Start()
    {
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
    }

    // Update is called once per frame
    void Update()
    {
        AjustadorSensibilidad();
    }
    /*public static void CambiarSensibilidad(float nuevaSensibilidad)
    {
        ControladorDeJuego.sensibilidadMouse = nuevaSensibilidad;
    }*/

    void AjustadorSensibilidad()
    {

        //sensibilidadSlider.maxValue = 150f;
        //sensibilidadSlider.minValue = 30f;
        //sensibilidadSlider.value = ControladorDeJuego.sensibilidadMouse;
        datos.sensibilidadMouse = sensibilidadSlider.value;
        datos.volumen = volumenSlider.value;
        sensibilidadTexto.text = "" + sensibilidadSlider.value;
    }




}
