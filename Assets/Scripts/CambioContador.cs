using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioContador : MonoBehaviour
{
    private GameObject jugador;
    private TiempoJugador temporizador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        temporizador = jugador.GetComponent<TiempoJugador>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (temporizador.tutorialTiempo)
            {
                temporizador.tutorialTiempo = false;
            }
            else
            {
                temporizador.tutorialTiempo = true;
            }
            gameObject.SetActive(false);
        }
    }

}
