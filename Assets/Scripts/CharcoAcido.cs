using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    public float tiempoDeRelentizar;
    public GameObject player;
    public float dañoExplosion;
    public GameObject explosion;
    public bool contacto;
    private float velocidadJugGuar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(explosion,0.1f);

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
        player.GetComponent<MovimientoJugador>().velocidadMovimiento = velocidadJugGuar;
        Destroy(gameObject);
    }

    public void RelentizadorCharco()
    {
        if (contacto == true && tiempoDeRelentizar < 6f)
        {
            player.GetComponent<MovimientoJugador>().velocidadMovimiento = velocidadJugGuar / 2;
        }
        else if(tiempoDeRelentizar >= 6f)
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
