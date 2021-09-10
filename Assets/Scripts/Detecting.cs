using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    public bool tocado;
    public GameObject objetoRegistrado;
    public string nombreTag;
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
        if (col.gameObject.tag == nombreTag)
        {
            tocado = true;
            objetoRegistrado = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == nombreTag)
        {
            tocado = false;
            objetoRegistrado = null;
        }
    }
}
