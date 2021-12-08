using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public int daño;
    public float frecuencia;
    public bool aturdidor;
    private float conteoAtaque, tiempoAtaque, tiempoAnimacion, tiempoAturdidor, escogerSonidoAtaque;
    public bool preparaAtaque, animacion;
    public Detector deteccionAtaque;
    public MovimientoEnemigo movimiento;
    //public MeshFilter vista;
    public Mesh normal, ataque;
    private int detente = 0;
    public GameObject sonidoAtaqueUno, sonidoAtaqueDos, sonidoAtaqueTres;

    // Start is called before the first frame update
    void Start()
    {
        animacion = false;
        preparaAtaque = false;
        conteoAtaque = 0;
        tiempoAtaque = 0;
        tiempoAnimacion = 0;
        tiempoAturdidor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (movimiento.radar.objetivo != null)
        {
            Ataque();
            Animar();
        }
    }

    void Ataque()
    {
        conteoAtaque += Time.deltaTime;
        if (conteoAtaque >= frecuencia)
        {
            preparaAtaque = true;
        }
        if (aturdidor)
        {
            tiempoAturdidor += Time.deltaTime;
        }
        if (deteccionAtaque.tocado&&preparaAtaque)
        {
            deteccionAtaque.objetoRegistrado.GetComponent<ValorSalud>().CambioDeVida(-daño);
            if (aturdidor && tiempoAturdidor >= 5)
            {
                deteccionAtaque.objetoRegistrado.GetComponent<MovimientoJugador>().tiempoInmovilizado = 1;
                deteccionAtaque.objetoRegistrado.GetComponent<MovimientoJugador>().inmovilizado = true;
                tiempoAturdidor = 0;
            }
            conteoAtaque = 0;
            preparaAtaque = false;
            animacion = true;
        }
        if (deteccionAtaque.tocado)
        {
            tiempoAtaque = 0.5f;
            if (movimiento.inteligencia.speed >= 0)
            {
                movimiento.inteligencia.acceleration = 100;
                movimiento.inteligencia.speed = 0;
            }
        }
        else if (tiempoAtaque > 0)
        {
            tiempoAtaque -= Time.deltaTime;
        }
        if (tiempoAtaque > 0)
        {
            if (movimiento.inteligencia.speed >= 0)
            {
                movimiento.inteligencia.acceleration = 100;
                movimiento.inteligencia.speed = 0;
            }
        }
        else
        {
            tiempoAtaque = 0;
            movimiento.inteligencia.speed = movimiento.guardarVelocidad;
            movimiento.inteligencia.acceleration = movimiento.guardarAceleracion;
        }
    }

    void Animar()
    {
        if (animacion)
        {
            if (detente == 0)
            {
                escogerSonidoAtaque = Random.Range(1, 3);
                detente++;
                switch (escogerSonidoAtaque)
                {
                    case 1:
                        sonidoAtaqueUno.SetActive(true);
                        break;
                    case 2:
                        sonidoAtaqueDos.SetActive(true);
                        break;
                    case 3:
                        sonidoAtaqueTres.SetActive(true);
                        break;
                }
            }
            //vista.mesh = ataque;
            tiempoAnimacion += Time.deltaTime;
            if (tiempoAnimacion >= 1)
            {
                animacion = false;
            }
        }
        else
        {
            switch (escogerSonidoAtaque)
            {
                case 1:
                    sonidoAtaqueUno.SetActive(false);
                    break;
                case 2:
                    sonidoAtaqueDos.SetActive(false);
                    break;
                case 3:
                    sonidoAtaqueTres.SetActive(false);
                    break;
            }
            //vista.mesh = normal;
            tiempoAnimacion = 0;
            detente = 0;
        }
    }
}
