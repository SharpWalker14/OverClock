using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaCambio : MonoBehaviour
{
    private GameObject nucleo;
    private NoDestruir datos;

    void Start()
    {
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
    }

    public void Cambiador()
    {
        if (datos.ventana)
        {
            datos.ventana = false;
        }
        else
        {
            datos.ventana = true;
        }
    }

}
