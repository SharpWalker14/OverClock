using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSentidos : MonoBehaviour
{
    public Transform origenRotatorio;
    public float alcance;
    public float angulo;

    private RaycastHit pared, piso;
    public float rotacionY, rotacionX, comienzoMirador, intentaMuro, intentaObjetivo, alcanceTotal;
    [HideInInspector]
    public GameObject objetivo;

    public GameObject[] puntosRango;
    [HideInInspector]
    public bool muerto, detectar;

    // Start is called before the first frame update
    void Start()
    {
        alcanceTotal = alcance;
        comienzoMirador = origenRotatorio.eulerAngles.y;
        objetivo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivo != null)
        {
            Mirar();
            Sentidos();
            Lados();
        }
    }
    void Mirar()
    {
        transform.LookAt(objetivo.transform);
    }
    void Sentidos()
    {
        intentaObjetivo = Vector3.Distance(transform.position, objetivo.transform.position);
        if (Physics.Linecast(transform.position, objetivo.transform.position, out pared, (1 << 7)))
        {
            intentaMuro = Vector3.Distance(transform.position, pared.point);
        }
        else if (Physics.Linecast(transform.position, objetivo.transform.position, out piso, (1 << 6)))
        {
            intentaMuro = Vector3.Distance(transform.position, piso.point);
        }
        else
        {
            intentaMuro = alcanceTotal;
        }

        if (intentaMuro <= intentaObjetivo)
        {
            detectar = false;
        }
        else if (intentaMuro > intentaObjetivo)
        {
            detectar = true;
        }
    }
    void Lados()
    {
        angulo = transform.localEulerAngles.y;
        if (angulo > 180)
        {
            angulo -= 360;
        }
        if (angulo <= 90&& angulo >= -90)
        {
            alcanceTotal = alcance / 1;
        }
        else
        {
            alcanceTotal = alcance / 4;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 dibujo;

        dibujo = transform.position;
        for (int i = 0; i < puntosRango.Length; i++)
        {
            puntosRango[i].transform.position = dibujo;
        }
        Vector3[] dibujante = new Vector3[puntosRango.Length];
        dibujante[0].z += alcance;
        dibujante[1].x += alcance;
        dibujante[2].x -= alcance;
        dibujante[3].y += alcance;
        dibujante[4].y -= alcance;

        for (int i = 0; i < puntosRango.Length; i++)
        {
            puntosRango[i].transform.localPosition += dibujante[i];
        }
        for (int i = 0; i < puntosRango.Length; i++)
        {
            Gizmos.DrawLine(dibujo, puntosRango[i].transform.position);
        }
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, alcance/4);

    }
}
