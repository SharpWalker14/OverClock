using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard : MonoBehaviour
{
    public MovimientoJugador jugadorM;
    public GameObject jugadorObj;

    public float rangoDeteccion;
    public bool enRangoVisíon;

    void Start()
    {
        jugadorM = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoJugador>();
        jugadorObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vision();
        Atracción();
    }

    void Vision()
    {
        float dist = Vector3.Distance(jugadorObj.transform.position, transform.position);
        if (dist < rangoDeteccion)
        {
            enRangoVisíon = true;
        }
        else
        {
            enRangoVisíon = false;
        }
    }

    void Atracción()
    {
        if(enRangoVisíon)
        {
            jugadorM.inmovilizado = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
