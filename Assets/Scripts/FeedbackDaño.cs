using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackDaño : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject feedbackDaño;
    public GameObject feedbackCharco;
    public GameObject feedDaño, feedHumo, feedAtrapado, feedAturdido;
    public MovimientoJugador jugador;
    private bool daño;
    private bool charco;
    public Color filtroCharco, sinFiltroCharco;
    public Color filtroDaño, sinFiltro, filtroEden;

    public float tiempoFiltro;
    private float tiempo;


    void Start()
    {
        daño = false;
        charco = false;
        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FeedbackRecibirDaño();
        charco = GetComponent<MovimientoJugador>().charco;
        FeedBackCharco();
        FeedbackEden();
    }

    public void IniciaDaño()
    {
        tiempo = 0;
        daño = true;
    }

    public void FeedBackCharco()
    {
        if (charco)
        {
            feedbackCharco.GetComponent<RawImage>().color = filtroCharco;
        }

        else
        {
            feedbackCharco.GetComponent<RawImage>().color = sinFiltroCharco;
        }
        charco = false;
    }

    void FeedbackRecibirDaño()
    {
        if (daño)
        {
            tiempo += Time.deltaTime;
            //feedbackDaño.GetComponent<Image>().color = filtroDaño;
            feedDaño.SetActive(true);
            if (tiempo >= tiempoFiltro)
            {
                daño = false;
            }
        }
        else
        {
            //feedbackDaño.GetComponent<Image>().color = sinFiltro;
            feedDaño.SetActive(false);
        }
    }

    void FeedbackEden()
    {
        if (jugador.poseido)
        {
            feedAtrapado.SetActive(true);
        }
        else
        {
            feedAtrapado.SetActive(false);
        }
    }

}
