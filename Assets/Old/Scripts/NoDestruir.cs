using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDestruir : MonoBehaviour
{
    [HideInInspector]
    public float sensibilidadMouse, volumen, volumenSonido, multiplicadorSensibilidad, multAncho, multAltura;
    [HideInInspector]
    public bool pantallaCompleta, tutorial;
    [HideInInspector]
    public int numeroCalidad, numeroResolucion, anchoDatos, alturaDatos, maxAncho, maxAltura, cantidadSonidos;
    private Scene escenaActual;
    public GameObject objetoMusica;
    private GameObject objetivoMusica;
    public GameObject[] objetivosSonidos;
    public AudioSource musicos;
    public AudioClip menu, niveles;
    public string nombreDeEscena, ultimaEscena, siguienteEscena;
    public Pausa tipoPausa;
    private int musicaCambiar;
    // Start is called before the first frame update
    void Start()
    {

        tipoPausa = (Pausa)FindObjectOfType(typeof(Pausa));
        DontDestroyOnLoad(gameObject);
        objetivoMusica = GameObject.FindGameObjectWithTag("Música");
        objetivosSonidos=GameObject.FindGameObjectsWithTag("Sonidos");
        objetoMusica.transform.position = objetivoMusica.transform.position;
        //Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Calidades(0);
        sensibilidadMouse = 70;
        pantallaCompleta = false;
        volumen = 0.7f;
        volumenSonido = 0.4f;
        maxAncho = 1920;
        maxAltura = 1080;
        escenaActual = SceneManager.GetActiveScene();
        nombreDeEscena = escenaActual.name;
        if (escenaActual.name == "MenúConjunto")
        {
            musicos.clip = menu;
            musicos.Play(0);
            musicaCambiar = 0;
        }
        else
        {
            musicos.clip = niveles;
            musicos.Play(0);
            musicaCambiar = 1;
        }
        anchoDatos = 1280;
        alturaDatos = 720;

        Screen.SetResolution(anchoDatos, alturaDatos, pantallaCompleta);


    }

    // Update is called once per frame
    void Update()
    {
        Ajustador();
        Escenas();
        MultiplicaSens();
    }

    void Escenas()
    {
        escenaActual = SceneManager.GetActiveScene();
        if (nombreDeEscena != escenaActual.name)
        {
            if (escenaActual.name == "MenúConjunto")
            {
                if (musicaCambiar != 0)
                {
                    musicos.clip = menu;
                    musicos.Play(0);
                    musicaCambiar = 0;
                }
            }
            else
            {
                if (musicaCambiar != 1)
                {
                    musicos.clip = niveles;
                    musicos.Play(0);
                    musicaCambiar = 1;
                }
            }
            objetivoMusica = null;
            objetivoMusica = GameObject.FindGameObjectWithTag("Música");
            objetoMusica.transform.position = objetivoMusica.transform.position;
            tipoPausa = null;
            objetivosSonidos = GameObject.FindGameObjectsWithTag("Sonidos");
            tipoPausa = (Pausa)FindObjectOfType(typeof(Pausa));

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
        objetivosSonidos = GameObject.FindGameObjectsWithTag("Sonidos");
        if (objetivosSonidos.Length != cantidadSonidos)
        {
            foreach (GameObject objetosonido in objetivosSonidos)
            {
                objetosonido.GetComponent<AudioSource>().volume = volumenSonido;
            }
            cantidadSonidos = objetivosSonidos.Length;
        }
        foreach (GameObject objetosonido in objetivosSonidos)
        {
            if (tipoPausa != null)
            {
                if (tipoPausa.pausar)
                {
                    objetosonido.GetComponent<AudioSource>().Pause();
                }
                else
                {
                    objetosonido.GetComponent<AudioSource>().UnPause();
                }
            }
        }
    }

    void MultiplicaSens()
    {
        multAncho = maxAncho / anchoDatos;
        multAltura = maxAltura / alturaDatos;
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
