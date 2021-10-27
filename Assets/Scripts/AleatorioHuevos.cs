using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorioHuevos : MonoBehaviour
{
    public bool oportunidad;
    private int probabilidad;
    public Huevo[] huevos;
    public GameObject[] verHuevos, huevosPot;
    // Start is called before the first frame update
    void Start()
    {
        ContadorHuevos();
    }

    void ContadorHuevos()
    {
        huevos = FindObjectsOfType(typeof(Huevo)) as Huevo[];
        verHuevos = new GameObject[huevos.Length];
        int contador = 0;
        for (int i = 0; i < huevos.Length; i++)
        {
            verHuevos[i] = huevos[i].gameObject;
            if (huevos[i].HuevoVerdad() == true)
            {
                contador++;
            }
        }
        huevosPot = new GameObject[contador];
        SeparadorHuevos();
    }
    void SeparadorHuevos()
    {
        int contador = 0;
        for (int i = 0; i < huevos.Length; i++)
        {
            if (huevos[i].HuevoVerdad() == true)
            {
                huevosPot[contador] = verHuevos[i];
                contador++;
            }

        }
        AsignadorHuevos();
    }
    void AsignadorHuevos()
    {
        int contador = 0;
        probabilidad = Random.Range(1, 6);
        int bloqueo;

        if (probabilidad == 1)
            oportunidad = true;
        else
            oportunidad = false;

        if (oportunidad)
        {
            probabilidad = Random.Range(0, huevosPot.Length);
            bloqueo = probabilidad;
            huevosPot[bloqueo].GetComponent<Huevo>().PotenciadorEscoger(true, false);
        }
        else
            bloqueo = -1;

        for (int i = 0; i < huevosPot.Length; i++)
        {
            if (bloqueo != i)
            {
                contador++;
                probabilidad = Random.Range(1, 3);
                if (probabilidad == 1)
                    huevosPot[i].GetComponent<Huevo>().PotenciadorEscoger(false, true);
                else
                    huevosPot[i].GetComponent<Huevo>().PotenciadorEscoger(false, false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
