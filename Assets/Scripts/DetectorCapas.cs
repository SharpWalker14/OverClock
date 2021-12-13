using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCapas : MonoBehaviour
{
    public bool tocado;
    public GameObject objetoRegistrado;
    public int numeroCapa;
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
        if (col.gameObject.layer == numeroCapa)
        {
            tocado = true;
            objetoRegistrado = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == numeroCapa)
        {
            tocado = false;
            objetoRegistrado = null;
        }
    }
}
