using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    private HordaHueco[] huecos;
    public bool especial;
    private bool primero, segundo;
    private float tiempo;
    public GameObject meta, dialogo;
    private GameObject hordas;
    // Start is called before the first frame update
    void Start()
    {
        primero = false;
        segundo = false;
        huecos = FindObjectsOfType(typeof(HordaHueco)) as HordaHueco[];
    }

    // Update is called once per frame
    void Update()
    {
        if (especial)
        {
            ColisionArea();
        }
        else
        {
            ConteoHuecos();
        }
    }

    void ConteoHuecos()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 60)
        {
            int contador = 0;
            for(int i = 0; i < huecos.Length; i++)
            {
                if (huecos[i].resuelto == true)
                {
                    contador++;
                }
            }
            HordaHueco[] lugarAparicion = new HordaHueco[contador];
            contador = 0;

            for (int i = 0; i < huecos.Length; i++)
            {
                if (huecos[i].resuelto == true)
                {
                    lugarAparicion[contador] = huecos[i];
                    contador++;
                }
            }

            if (contador != 0)
            {
                contador = Random.Range(0, lugarAparicion.Length);

                lugarAparicion[contador].Invocacion();
                tiempo = 0;
            }
        }
    }

    void ColisionArea()
    {
        int contador = 0;
        hordas = GameObject.FindGameObjectWithTag("Horda");
        for (int i = 0; i < huecos.Length; i++)
        {
            if (huecos[i].resuelto == true)
            {
                huecos[i].Invocacion();
                huecos[i].obsoleto = true;
            }
            if (huecos[i].obsoleto)
            {
                contador++;
            }
            if (contador == huecos.Length)
            {
                primero = true;
            }
            else
            {
                primero = false;
            }
        }
        if (hordas == null)
        {
            segundo = true;
        }
        else
        {
            segundo = false;
        }
        if (primero && segundo)
        {
            meta.SetActive(true);
            if (dialogo != null)
            {
                dialogo.SetActive(true);
            }
        }
        else
        {
            meta.SetActive(false);
            if (dialogo != null)
            {
                dialogo.SetActive(false);
            }
        }
    }
}
