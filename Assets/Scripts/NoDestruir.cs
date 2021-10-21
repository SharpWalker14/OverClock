using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDestruir : MonoBehaviour
{
    [HideInInspector]
    public float sensibilidadMouse, volumen;
    [HideInInspector]
    public bool pantallaCompleta;
    [HideInInspector]
    public int numeroCalidad, numeroResolucion, anchoDatos, alturaDatos;
    private Scene escenaActual;
    public GameObject objetoMusica;
    private GameObject objetivoMusica;
    public AudioSource musicos;
    public string nombreDeEscena, ultimaEscena;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        objetivoMusica = GameObject.FindGameObjectWithTag("Música");
        objetoMusica.transform.position = objetivoMusica.transform.position;
        //Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Calidades(0);
        pantallaCompleta = false;
        sensibilidadMouse = 70;
        volumen = 0.5f;
        anchoDatos = 640;
        alturaDatos = 400;
        Screen.SetResolution(anchoDatos, alturaDatos, pantallaCompleta);
        escenaActual = SceneManager.GetActiveScene();
        nombreDeEscena = escenaActual.name;
    }

    // Update is called once per frame
    void Update()
    {
        Ajustador();
        Escenas();
    }

    void Escenas()
    {
        escenaActual = SceneManager.GetActiveScene();
        if (nombreDeEscena != escenaActual.name)
        {
            objetivoMusica = null;
            objetivoMusica = GameObject.FindGameObjectWithTag("Música");
            objetoMusica.transform.position = objetivoMusica.transform.position;
            ultimaEscena = nombreDeEscena;
            nombreDeEscena = escenaActual.name;
        }
    }

    void Ajustador()
    {
        if (pantallaCompleta)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
        musicos.volume = volumen;
    }

    public void Calidades(int calidad)
    {
        numeroCalidad = calidad;
        QualitySettings.SetQualityLevel(numeroCalidad);
    }
    public void Resoluciones(int ancho, int altura)
    {
        anchoDatos = ancho;
        alturaDatos = altura;
    }
    public void Pantalla(bool activar)
    {
        pantallaCompleta = activar;
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
