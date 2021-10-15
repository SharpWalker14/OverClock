using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jefe : MonoBehaviour
{
    public NavMeshAgent inteligencia;
    public VidaJefe valores;
    private float velocidad, tiempoCiclo;
    // Start is called before the first frame update
    void Start()
    {
        inteligencia = GetComponent<NavMeshAgent>();
        velocidad = inteligencia.speed*2;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Ataque();
    }

    void Movimiento()
    {
        if (valores.cansancio)
        {

        }
        else
        {
            if (valores.volando)
            {
                tiempoCiclo += Time.deltaTime;
            }
            else
            {

            }
        }
    }

    void Ataque()
    {
        if (valores.cansancio)
        {

        }
        else
        {

        }
    }
}
