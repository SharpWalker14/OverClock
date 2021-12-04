using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJefe : MonoBehaviour
{
    public Detector atacante, limitador, empezar;
    public GameObject[] patrullajes;
    private ValorSalud armadura;
    public Rigidbody cuerpo;
    public GameObject marca, puntero, empujador;
    private GameObject jugador;
    public float distanciero, tiempoCorrer, tiempoReposo, tiempoAtaque;
    public float velocidad, velEmbestida;
    public int ataque, empuje, moverPat, numeroPat, descansoFijar;
    private Vector3 posicionActual, posJugador, posActual;
    private Vector3[] posPat;
    public enum Estado { esperar, correr, atacar, cansancio };
    public Estado patrones;
    private float distanciaMax, frenar;
    // Start is called before the first frame update
    void Start()
    {
        armadura = GetComponent<ValorSalud>();
        tiempoCorrer = 0;
        tiempoReposo = 0;
        numeroPat = 0;
        ataque = 0;
        moverPat = 0;
        descansoFijar = 0;
        cuerpo = GetComponent<Rigidbody>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        posicionActual = transform.position;
        posicionActual.y = 0;
        posPat = new Vector3[patrullajes.Length];
        for(int i = 0; i < posPat.Length; i++)
        {
            posPat[i].x = patrullajes[i].transform.position.x;
            posPat[i].z = patrullajes[i].transform.position.z;
            posPat[i].y = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null)
        {
            Estados();
            Rango();
            AuraAtaque();
        }
        else
        {
            patrones = Estado.cansancio;
        }
    }
    void Estados()
    {
        switch (patrones)
        {
            case Estado.esperar:
                gameObject.layer = 10;
                armadura.pesada = true;
                break;
            case Estado.correr:
                gameObject.layer = 14;
                armadura.pesada = true;
                Movimiento();
                break;
            case Estado.atacar:
                gameObject.layer = 14;
                armadura.pesada = true;
                Ataque();
                break;
            case Estado.cansancio:
                gameObject.layer = 10;
                armadura.pesada = false;
                Descanso();
                break;
        }

    }

    void Rango()
    {
        //Distancia entre jugador y el centro, tambien el ángulo
        posJugador = new Vector3(jugador.transform.position.x, 0, jugador.transform.position.z);
        //Distancia entre el jefe y el centro, tambien el ángulo
        posActual = new Vector3(transform.position.x, 0, transform.position.z);

        if (patrones == Estado.esperar && empezar.tocado)
        {
            patrones = Estado.correr;
        }
    }

    void AuraAtaque()
    {
        if (atacante.tocado && patrones != Estado.cansancio)
        {
            if (empuje == 0)
            {
                jugador.GetComponent<ValorSalud>().CambioDeVida(-10);
                jugador.GetComponent<MovimientoJugador>().tiempoInmovilizado = 2.5f;
                jugador.GetComponent<MovimientoJugador>().empujado = true;
                Vector3 empujeRonda = (empujador.transform.position - posActual);
                jugador.GetComponent<MovimientoJugador>().Empuje(empujeRonda);
                empuje++;
            }

        }
        else if(!atacante.tocado && patrones != Estado.cansancio)
        {
            empuje = 0;
        }
    }

    void Movimiento()
    {
        descansoFijar = 0;
        tiempoReposo = 0;
        tiempoCorrer += Time.deltaTime;
        if (moverPat == 0)
        {
            puntero.transform.position = posPat[numeroPat];
            moverPat++;
        }
        Vector3 fijador = (puntero.transform.position - posActual).normalized;
        float rotacion = Mathf.Atan2(fijador.x, fijador.z);
        rotacion = rotacion * (180 / Mathf.PI);
        transform.eulerAngles = new Vector3(0, rotacion, 0);
        if (moverPat == 1)
        {
            puntero.transform.position = new Vector3(0, 0, 0);
            puntero.transform.localPosition = new Vector3(0, 0, 10);
        }
        fijador.y = cuerpo.velocity.y;
        cuerpo.velocity = fijador * velocidad;
        if (limitador.tocado && limitador.objetoRegistrado == patrullajes[numeroPat])
        {
            numeroPat++;
            moverPat = 0;
            if (numeroPat >= patrullajes.Length)
            {
                numeroPat = 0;
            }
        }
        if (tiempoCorrer >= 10)
        {
            posicionActual.x = transform.position.x;
            posicionActual.z = transform.position.z;
            patrones = Estado.atacar;
            puntero.transform.position = posJugador;
        }
    }

    void Ataque()
    {
        tiempoAtaque += Time.deltaTime;
        Vector3 fijador = (puntero.transform.position - posActual).normalized;
        float rotacion = Mathf.Atan2(fijador.x, fijador.z);
        distanciero = Vector3.Distance(posicionActual, posActual);
        rotacion = rotacion * (180 / Mathf.PI);
        transform.eulerAngles = new Vector3(0, rotacion, 0);
        if (ataque == 0)
        {
            distanciaMax = Vector3.Distance(puntero.transform.position,posActual);
            puntero.transform.position = new Vector3(0, 0, 0);
            puntero.transform.localPosition = new Vector3(0, 0, 10);
            tiempoCorrer = 0;
            ataque++;
        }
        fijador.y = cuerpo.velocity.y;

        cuerpo.velocity = fijador * velEmbestida;

        if (distanciero>distanciaMax-1)
        {
            frenar += Time.deltaTime;
            if (frenar >= 1f)
            {
                patrones = Estado.cansancio;
            }
        }
        

    }

    void Descanso()
    {
        if (descansoFijar == 0)
        {
            frenar = 0;
            distanciaMax = 100000000;
            for (int i = 0; i < posPat.Length; i++)
            {
                distanciero = Vector3.Distance(posActual, posPat[i]);
                if (distanciero < distanciaMax)
                {
                    distanciaMax = distanciero;
                    numeroPat = i;
                }
            }
            descansoFijar++;
        }
        tiempoAtaque = 0;
        Vector3 descansar = cuerpo.velocity;
        descansar.x = 0;
        descansar.z = 0;
        cuerpo.velocity = descansar;
        ataque = 0;
        moverPat = 0;
        tiempoReposo += Time.deltaTime;
        if (tiempoReposo >= 3)
        {
            patrones = Estado.correr;
        }
    }

}
