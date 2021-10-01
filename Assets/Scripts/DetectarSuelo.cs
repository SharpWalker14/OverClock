using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarSuelo : MonoBehaviour
{
    public bool tocado;
    public GameObject objetoRegistrado;
    // Start is called before the first frame update
    void Start()
    {
        tocado = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {

    }
    void OnTriggerStay(Collider col)
    {
        LayerMask mascaraSuelo = LayerMask.GetMask("Suelo");
        LayerMask mascaraEnemigo = LayerMask.GetMask("Enemigo");
        if (col.gameObject.layer == 6 || col.gameObject.layer == 10)
        {
            tocado = true;
            objetoRegistrado = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        LayerMask mascaraSuelo = LayerMask.GetMask("Suelo");
        LayerMask mascaraEnemigo = LayerMask.GetMask("Enemigo");
        if (col.gameObject.layer == 6 || col.gameObject.layer == 10)
        {
            tocado = false;
            objetoRegistrado = null;
        }
    }
}