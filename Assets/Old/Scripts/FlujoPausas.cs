using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlujoPausas : MonoBehaviour
{
    public void SiguientePantalla(GameObject pantalla)
    {
        pantalla.SetActive(true);
    }
    public void SalirPantalla(GameObject pantalla)
    {
        pantalla.SetActive(false);
    }
}