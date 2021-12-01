using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackEnemigos : MonoBehaviour
{
    public Material original;
    public GameObject modelado;
    public Material feedbackDaño, feedbackImmune;
    public float tiempoFiltro;
    private float tiempo;
    private bool filtroTiro, filtroInmune;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Feedbacks();
    }

    public void Inicia()
    {
        tiempo = 0;
        filtroTiro = true;
    }
    public void InmunidadEmpiezo()
    {
        tiempo = 0;
        filtroInmune = true;
    }

    public void Feedbacks()
    {
        if (filtroTiro)
        {
            tiempo += Time.deltaTime;
            modelado.GetComponent<MeshRenderer>().material = feedbackDaño;
            if (tiempo >= tiempoFiltro)
            {
                filtroTiro = false;
                modelado.GetComponent<MeshRenderer>().material = original;
            }
        }
        else if(filtroInmune)
        {
            tiempo += Time.deltaTime;
            modelado.GetComponent<MeshRenderer>().material = feedbackImmune;
            if (tiempo >= tiempoFiltro)
            {
                filtroTiro = false;
                modelado.GetComponent<MeshRenderer>().material = original;
            }
        }
        else
        {
            modelado.GetComponent<MeshRenderer>().material = original;
        }

    }
}
