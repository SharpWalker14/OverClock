using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackDaño : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject feedPot;
    public GameObject feedbackCharco;
    public GameObject feedDaño, feedHumo, feedAtrapado, feedAturdido;
    public MovimientoJugador jugador;
    public bool daño, potencia;
    private bool charco;
    public Color filtroCharco, sinFiltroCharco;
    public Color filtroDaño, sinFiltro;
    public Color potTiempo, potFrenesi, potOportunidad;
    public float tiempoFiltro;
    private float tiempo, tiempoPot;
    private int numeroPot;


    void Start()
    {
        daño = false;
        charco = false;
        potencia = false;
        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FeedbackRecibirDaño();
        charco = GetComponent<MovimientoJugador>().charco;
        FeedBackCharco();
        FeedbackEden();
        FeedbackPot();
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
            //feedPot.GetComponent<Image>().color = filtroDaño;
            feedDaño.SetActive(true);
            if (tiempo >= tiempoFiltro)
            {
                daño = false;
            }
        }
        else
        {
            feedDaño.SetActive(false);
        }
    }

    public void FeedbackPotencia(int numero)
    {
        tiempoPot = 0;
        numeroPot = numero;
        potencia = true;
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

    void FeedbackPot()
    {
        if (potencia)
        {
            switch (numeroPot)
            {
                case 1:
                    feedPot.GetComponent<Image>().color = potTiempo;
                    break;
                case 2:
                    feedPot.GetComponent<Image>().color = potFrenesi;
                    break;
                case 3:
                    feedPot.GetComponent<Image>().color = potOportunidad;
                    break;
            }
            tiempoPot += Time.deltaTime;
            if (tiempoPot >= tiempoFiltro)
            {
                potencia = false;
            }
        }
        else
        {
            feedPot.GetComponent<Image>().color = sinFiltro;
        }
    }
}
