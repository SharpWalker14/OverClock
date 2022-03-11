using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista : MonoBehaviour
{
    public Modelo m;
    public Controlador c;

    void Update()
    {
        Animar();
        Feedbacks();
    }

    public void Inicia()
    {
        m.tiempo = 0;
        m.filtroTiro = true;
    }
    public void InmunidadEmpiezo()
    {
        m.tiempo = 0;
        m.filtroInmune = true;
    }

    void Feedbacks()
    {
        if (m.filtroTiro)
        {
            m.tiempo += Time.deltaTime;
            m.modelado.GetComponent<SkinnedMeshRenderer>().material = m.feedbackDaño;
            if (m.tiempo >= m.tiempoFiltro)
            {
                m.filtroTiro = false;
                m.modelado.GetComponent<SkinnedMeshRenderer>().material = m.original;
            }
        }
        else if (m.filtroInmune)
        {
            m.tiempo += Time.deltaTime;
            m.modelado.GetComponent<SkinnedMeshRenderer>().material = m.feedbackImmune;
            if (m.tiempo >= m.tiempoFiltro)
            {
                m.filtroTiro = false;
                m.modelado.GetComponent<SkinnedMeshRenderer>().material = m.original;
            }
        }
        else
        {
            m.modelado.GetComponent<SkinnedMeshRenderer>().material = m.original;
        }
    }
    void Animar()
    {
        if (m.inteligencia.speed > 0 && m.contadorMuerte == 0)
        {
           // m.animator.SetBool("SeMueve", true);
            m.animator.SetFloat("Movimiento", m.inteligencia.speed);
        }
        else if (m.inteligencia.speed == 0 && m.contadorMuerte == 0)
        {
            // m.animator.SetBool("SeMueve", false);
            m.animator.SetFloat("Movimiento", m.inteligencia.speed);
        }

        if (m.animacionAtaque)
        {
            m.animator.SetTrigger("Ataca");
        }

        if (m.filtroTiro)
        {
            if (m.animator != null)
            {
                m.animator.SetTrigger("Dañado");
                m.filtroTiro = false;
            }
        }
        if (m.vida <= 0 && m.contadorMuerte == 1)
        {
            m.animator.SetFloat("Muerte", m.vida);

            m.inteligencia.speed = 0;

            gameObject.GetComponent<Collider>().enabled = false;

            m.inteligencia.enabled = false;

            m.contadorMuerte += 1;

        }

        if (m.contadorMuerte == 2)
        {
            m.animator.SetBool("Stop", true);
        }
        
    }
}
