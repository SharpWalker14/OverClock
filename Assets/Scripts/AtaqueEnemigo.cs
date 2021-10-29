using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public int da�o;
    public float frecuencia;
    public bool aturdidor;
    private float conteoAtaque, tiempoAtaque, tiempoAnimacion, tiempoAturdidor;
    private bool preparaAtaque, animacion;
    public Detector deteccionAtaque;
    public MovimientoEnemigo movimiento;
    public MeshFilter vista;
    public Mesh normal, ataque;
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
        Ataque();
        Animar();
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
            deteccionAtaque.objetoRegistrado.GetComponent<ValorSalud>().CambioDeVida(-da�o);
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
            vista.mesh = ataque;
            tiempoAnimacion += Time.deltaTime;
            if (tiempoAnimacion >= 1)
            {
                animacion = false;
            }
        }
        else
        {
            vista.mesh = normal;
            tiempoAnimacion = 0;
        }
    }
}
