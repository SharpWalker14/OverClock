using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    public float tiempoDeRelentizar;
    private GameObject player;
    public float dañoExplosion;
    public GameObject explosion;
    public bool contacto;
    private float velocidadJugGuar;
    public Detector explosionDetectar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (explosionDetectar.tocado)
        {
            player.GetComponent<ValorSalud>().CambioDeVida(-dañoExplosion);
        }
        Destroy(explosion, 0.1f);

        velocidadJugGuar = player.GetComponent<MovimientoJugador>().velocidadMovimiento;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDeRelentizar += 1 * Time.deltaTime;

        RelentizadorCharco();
    }

    public void Destruccion()
    {
        player.GetComponent<MovimientoJugador>().charco = false;
        Destroy(gameObject);
    }

    public void RelentizadorCharco()
    {
        if (contacto == true && tiempoDeRelentizar < 8f)
        {
            player.GetComponent<MovimientoJugador>().charco = true;
        }
        else if(tiempoDeRelentizar >= 8f)
        {
            Destruccion();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            contacto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            contacto = false;
        }
    }
}
