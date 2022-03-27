using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerTutorial : MonoBehaviour
{
    private GameObject nucleo, jugador;
    public GameObject tutorialObj, noTutorialObj;
    public Detector deteccion;
    public Transform posicionamiento;
    private NoDestruir datos;
    
    
    void Awake()
    {
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        if (datos.tutorial)
        {
            tutorialObj.SetActive(true);
            noTutorialObj.SetActive(false);
            jugador.GetComponent<TiempoJugador>().tutorial = true;
        }
        else
        {
            tutorialObj.SetActive(false);
            noTutorialObj.SetActive(true);
            jugador.GetComponent<TiempoJugador>().tutorial = false;
            jugador.transform.position = posicionamiento.position;
            jugador.transform.eulerAngles = posicionamiento.eulerAngles;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Detectando();
    }

    void Detectando()
    {
        if (deteccion.tocado)
        {
            datos.tutorial = false;
        }
    }
}
