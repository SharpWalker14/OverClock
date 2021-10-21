using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesPrueba : MonoBehaviour
{
    private GameObject jugador, mostrandoDios;
    private TiempoJugador temporizador;
    private ValorSalud valores;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        temporizador = jugador.GetComponent<TiempoJugador>();
        valores = jugador.GetComponent<ValorSalud>();
        mostrandoDios = GameObject.FindGameObjectWithTag("PuntoDios");
        mostrandoDios.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        Teclas();
    }

    void Teclas()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (valores.armadura)
            {
                valores.armadura = false;
                mostrandoDios.SetActive(false);
            }
            else
            {
                valores.armadura = true;
                mostrandoDios.SetActive(true);


            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            temporizador.tiempo = temporizador.tiempoMaximo;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (temporizador.congelado)
            {
                temporizador.congelado = false;
            }
            else
            {
                temporizador.congelado = true;
            }
        }
    }
}
