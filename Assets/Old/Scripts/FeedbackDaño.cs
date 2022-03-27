using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackDaño : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject feedPot , feedDaño, feedHumo, feedAtrapado, feedAturdido, feedCharco;
    public MovimientoJugador jugador;
    public bool daño, potencia, humo;
    private bool charco;
    public Color filtroCharco, sinFiltroCharco;
    public Color filtroDaño, sinFiltro;
    public Color potTiempo, potFrenesi, potOportunidad;
    public float tiempoFiltro;
    private float tiempo, tiempoPot, tiempoHumo;
    private int numeroPot;


    void Start()
    {
        daño = false;
        charco = false;
        potencia = false;
        humo = false;
        tiempo = 0;
        tiempoHumo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FeedbackRecibirDaño();
        FeedBackCharco();
        FeedbackAturdido();
        FeedbackEden();
        FeedBackPot();
        FeedBackHumo();
    }

    public void IniciaDaño()
    {
        tiempo = 0;
        daño = true;
    }

    void FeedBackCharco()
    {
        charco = GetComponent<MovimientoJugador>().charco;
        if (charco)
        {
            //feedbackCharco.GetComponent<RawImage>().color = filtroCharco;
            feedCharco.SetActive(true);
        }
        else
        {
            //feedbackCharco.GetComponent<RawImage>().color = sinFiltroCharco;
            feedCharco.SetActive(false);
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

    void FeedbackAturdido()
    {
        if (jugador.inmovilizado)
        {
            feedAturdido.SetActive(true);
        }
        else
        {
            feedAturdido.SetActive(false);
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

    void FeedBackPot()
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

    void FeedBackHumo()
    {
        if (humo)
        {
            tiempoHumo += Time.deltaTime;
            //feedPot.GetComponent<Image>().color = filtroDaño;
            feedHumo.SetActive(true);
            if (tiempoHumo >= 3)
            {
                humo = false;
            }
        }
        else
        {
            tiempoHumo = 0;
            feedHumo.SetActive(false);
        }
    }
}
