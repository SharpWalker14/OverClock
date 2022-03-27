using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbeSana : MonoBehaviour
{
    public int valor;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ValorSalud>().CambioDeVida(valor);
            Destroy(gameObject);
        }
    }
}
