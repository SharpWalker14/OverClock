using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Opciones : MonoBehaviour
{
    public Text sensibilidadTexto, volumenTexto, sonidoTexto;
    public Slider sensibilidadSlider, volumenSlider, sonidoSlider;
    public GameObject nucleo;
    public NoDestruir datos;
    public Toggle modificadorPantalla;

    public AudioMixer audioMixer;

    public Dropdown resolucionDropdown;
    Resolution[] resoluciones;
    public Dropdown calidadDropdown;

    void Start()
    {
        //resoluciones = Screen.resolutions;
        
        resoluciones = new Resolution[3];
        int dividor = 1;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            resoluciones[i].width = 1920 / dividor;
            resoluciones[i].height = 1080 / dividor;
            dividor += 1;
        }
        
        resolucionDropdown.ClearOptions();
        //volumenSlider.value = datos.volumen;
    }

    // Update is called once per frame
    void Update()
    {
        Activador();
    }
    /*public static void CambiarSensibilidad(float nuevaSensibilidad)
    {
        ControladorDeJuego.sensibilidadMouse = nuevaSensibilidad;
    }*/

    void Activador()
    {
        if (datos == null)
        {
            Cargando();
        }
        else if (datos != null)
        {
            AjustadorSlider();
        }
    }

    void Cargando()
    {
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
        sensibilidadSlider.value = datos.sensibilidadMouse;
        volumenSlider.value = datos.volumen;
        calidadDropdown.value = datos.numeroCalidad;
        sonidoSlider.value = datos.volumenSonido;
        modificadorPantalla.isOn = datos.pantallaCompleta;
        List<string> options = new List<string>();

        int resolucionActualIndex = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string option = resoluciones[i].width + "x" + resoluciones[i].height;
            options.Add(option);

            if (resoluciones[i].width == datos.anchoDatos && resoluciones[i].height == datos.alturaDatos)
            {
                resolucionDropdown.RefreshShownValue();
                resolucionActualIndex = i;
            }
        }
        resolucionDropdown.AddOptions(options);
        resolucionDropdown.value = resolucionActualIndex;
    }

    public void PantallaCompleta(bool estaCompleto)
    {
        //Screen.fullScreen = estaCompleto;
        datos.Pantalla(estaCompleto);
    }

    void AjustadorSlider()
    {

        //sensibilidadSlider.maxValue = 150f;
        //sensibilidadSlider.minValue = 30f;
        //sensibilidadSlider.value = ControladorDeJuego.sensibilidadMouse;
        sensibilidadTexto.text = "" + (sensibilidadSlider.value - (sensibilidadSlider.value % 1));
        datos.sensibilidadMouse = sensibilidadSlider.value;

        volumenTexto.text = "" + (((volumenSlider.value+0.001) - ((volumenSlider.value + 0.001) % 0.01)) * 100)+"%";
        datos.volumen = volumenSlider.value;

        sonidoTexto.text = "" + (((sonidoSlider.value+0.001) - ((sonidoSlider.value + 0.001) % 0.01)) * 100)+"%";
        datos.volumenSonido = sonidoSlider.value;
    }

    public void ConfiguracionVolumen(float volumen)
    {
        /*audioMixer.SetFloat("VolumenGeneral", volumen);

        int enterovolumen = (int)volumen;

        volumenTexto.text = "" + enterovolumen;*/
    }

    public void CambiarResolucion(int resolucionIndex)
    {
        Resolution resolucionMedida = resoluciones[resolucionIndex];
        Screen.SetResolution(resolucionMedida.width, resolucionMedida.height, Screen.fullScreen);
        datos.Resoluciones(resolucionMedida.width,resolucionMedida.height);
    }

    public void Calidades(int calidadesIndex)
    {
        datos.Calidades(calidadesIndex);
    }






}
