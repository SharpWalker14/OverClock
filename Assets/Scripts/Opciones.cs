using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Opciones : MonoBehaviour
{
    public Text sensibilidadTexto;
    public Text volumenTexto;
    public Slider sensibilidadSlider;
    public Slider volumenSlider;
    private GameObject nucleo;
    private NoDestruir datos;

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        //
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                resolutionDropdown.RefreshShownValue();
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        //


        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
        sensibilidadSlider.value = datos.sensibilidadMouse;
        //volumenSlider.value = datos.volumen;
        
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

    public void PantallaCompleta(bool isFull)
    {
        Screen.fullScreen = isFull;      
    }

    void AjustadorSensibilidad()
    {

        //sensibilidadSlider.maxValue = 150f;
        //sensibilidadSlider.minValue = 30f;
        //sensibilidadSlider.value = ControladorDeJuego.sensibilidadMouse;
        //datos.sensibilidadMouse = sensibilidadSlider.value;
        //datos.volumen = volumenSlider.value;
        sensibilidadTexto.text = "" + (sensibilidadSlider.value - (sensibilidadSlider.value % 1));
        //volumenTexto.text = "" + (((volumenSlider.value+0.001) - ((volumenSlider.value+0.001) % 0.01)) * 100)+"%";
    }

    public void ConfiguracionVolumen(float volumen)
    {
        audioMixer.SetFloat("VolumenGeneral", volumen);

        int enterovolumen = (int)volumen;

        volumenTexto.text = "" + enterovolumen;
    }

    public void CambiarResolucion(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }






}
