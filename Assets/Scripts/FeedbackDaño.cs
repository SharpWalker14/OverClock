using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackDaño : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject feedbackDaño;
    public GameObject feedbackCharco;
    private bool daño;
    private bool charco;
    public Color filtroCharco;
    public Color sinFiltroCharco;
    public Color filtroDaño;
    public Color sinFiltroDaño;
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
            feedbackDaño.GetComponent<Image>().color = filtroDaño;
            if (tiempo >= tiempoFiltro)
            {
                daño = false;
            }
        }
        else
        {
            feedbackDaño.GetComponent<Image>().color = sinFiltroDaño;
        }
    }

}
