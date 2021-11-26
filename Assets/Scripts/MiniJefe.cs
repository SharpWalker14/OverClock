using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJefe : MonoBehaviour
{
    public float locacion;
    public float ancho, largo, velocidad;
    private Vector3 posicionActual;
    // Start is called before the first frame update
    void Start()
    {
        posicionActual = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        locacion += Time.deltaTime * velocidad;
        float x = Mathf.Cos(locacion) * ancho;
        float z = Mathf.Sin(locacion) * largo;

        transform.position = new Vector3(posicionActual.x+x, posicionActual.y+0, posicionActual.z+z);

    }

}
