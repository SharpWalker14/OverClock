using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public int daño;
    public float frecuencia;
    public float conteoAtaque, tiempoAtaque;
    private bool preparaAtaque;
    public Detector deteccionAtaque;
    public MovimientoEnemigo movimiento;
    // Start is called before the first frame update
    void Start()
    {
        preparaAtaque = false;
        conteoAtaque = 0;
        tiempoAtaque = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }

    void Ataque()
    {
        conteoAtaque += Time.deltaTime;
        if (conteoAtaque >= frecuencia)
        {
            preparaAtaque = true;
        }
        if (deteccionAtaque.tocado&&preparaAtaque)
        {
            deteccionAtaque.objetoRegistrado.GetComponent<ValorSalud>().CambioDeVida(-daño);
            conteoAtaque = 0;
            preparaAtaque = false;
        }
        if (deteccionAtaque.tocado)
        {
            tiempoAtaque = 0.5f;
            if (movimiento.inteligencia.speed >= 0)
            {
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
                movimiento.inteligencia.speed = 0;
            }
        }
        else
        {
            tiempoAtaque = 0;
            movimiento.inteligencia.speed = movimiento.guardarVelocidad;
        }
    }
}
