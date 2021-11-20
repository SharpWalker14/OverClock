using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hordas : MonoBehaviour
{
    private HordaHueco[] huecos;
    private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        huecos = FindObjectsOfType(typeof(HordaHueco)) as HordaHueco[];
    }

    // Update is called once per frame
    void Update()
    {
        ConteoHuecos();
    }

    void ConteoHuecos()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 60)
        {
            int contador = 0;
            for(int i = 0; i < huecos.Length; i++)
            {
                if (huecos[i].confirmado == false)
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

            contador = Random.Range(0, lugarAparicion.Length);

            lugarAparicion[contador].Invocacion();


            tiempo = 0;
        }
    }
}
