using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJefe : MonoBehaviour
{
    public bool detectado, limite;
    public Detector atacante, limitadorCorrer, limitadorAtaque;
    private ValorSalud armadura;
    public Rigidbody cuerpo;
    public GameObject marca, puntero, empujador, limitrofe;
    public GameObject es1, es2, es3, es4;
    private GameObject jugador;
    public float tiempoCorrer, tiempoReposo, tiempoAtaque, hipotenusa, autoHipotenusa,
        locacion, disJugador, disActual,
        angulo, anguloRadian, proAngulo, proAnguloRadian, anguloContra, anguloJugador;
    public float ancho, largo, velocidad, velEmbestida;
    private int ataque, empuje;
    private Vector3 posicionActual, posJugador, posActual;

    public enum Estado { esperar, correr, atacar, cansancio };
    public Estado patrones;
    private bool candado = false;
    // Start is called before the first frame update
    void Start()
    {
        armadura = GetComponent<ValorSalud>();
        tiempoCorrer = 0;
        tiempoReposo = 0;
        ataque = 0;
        cuerpo = GetComponent<Rigidbody>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        candado = true;
        locacion = -1.5f;
        posicionActual = transform.localPosition;
        posicionActual.z += largo;
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
        posJugador = new Vector3(jugador.transform.position.x, marca.transform.position.y, jugador.transform.position.z);
        disJugador = Vector3.Distance(marca.transform.position, posJugador);
        Vector3 direccional = posJugador - marca.transform.position;
        angulo = Vector3.SignedAngle(direccional, marca.transform.right, Vector3.up);
        anguloRadian = angulo * Mathf.PI / 180;
        float xRango = Mathf.Cos(anguloRadian) * ancho;
        float zRango = Mathf.Sin(anguloRadian) * largo;
        if (xRango < 0)
        {
            xRango *= -1;
        }
        if (zRango < 0)
        {
            zRango *= -1;
        }
        hipotenusa = Mathf.Sqrt(xRango * xRango + zRango * zRango);
        //Distancia entre el jefe y el centro, tambien el ángulo
        posActual = new Vector3(transform.position.x, marca.transform.position.y, transform.position.z);
        disActual = Vector3.Distance(marca.transform.position, posActual);
        Vector3 recordatorio = posActual - marca.transform.position;
        proAngulo = Vector3.SignedAngle(recordatorio, marca.transform.right, Vector3.up);
        proAnguloRadian = proAngulo * Mathf.PI / 180;
        float xMismo = Mathf.Cos(proAnguloRadian) * ancho;
        float zMismo = Mathf.Sin(proAnguloRadian) * largo;

        if (xMismo < 0)
        {
            xMismo *= -1;
        }
        if (zMismo < 0)
        {
            zMismo *= -1;
        }
        autoHipotenusa = Mathf.Sqrt(xMismo * xMismo + zMismo * zMismo);

        //Angulo entre el jefe y el jugador
        Vector3 contra = posJugador - posActual;
        anguloContra = Vector3.SignedAngle(contra, transform.forward, Vector3.up);

        if (disJugador <= hipotenusa)
        {
            detectado = true;
        }
        else
        {
            detectado = false;
        }
        if ((limitadorCorrer.tocado == false && patrones == Estado.correr) || (limitadorAtaque.tocado == false && patrones == Estado.atacar))
        {
            if (tiempoAtaque >= 0.1f)
            {
                limite = true;
            }
        }
        else
        {
            limite = false;
        }
        /*
        if (disActual >= autoHipotenusa || !limitador.tocado)
        {
            limite = true;
        }
        else
        {
            limite = false;
        }
        */
        if (detectado && patrones == Estado.esperar)
        {
            patrones = Estado.correr;
        }
        if (anguloContra >= 0 && anguloContra <= 180)
        {
            empujador.transform.localPosition = new Vector3(-10, 0, 0);
        }
        else
        {
            empujador.transform.localPosition = new Vector3(10, 0, 0);
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
        tiempoReposo = 0;
        tiempoCorrer += Time.deltaTime;
        locacion -= Time.deltaTime * velocidad;
        float x = Mathf.Cos(locacion) * ancho;
        float z = Mathf.Sin(locacion) * largo;
        transform.localPosition = new Vector3(posicionActual.x + x, posicionActual.y + 0, posicionActual.z + z);

        Vector3 objetivoO = posicionActual;
        objetivoO.y = 0;
        Vector3 vistaO = transform.localPosition;
        vistaO.y = 0;
        Vector3 mira = (objetivoO - vistaO).normalized;
        float rotacion = Mathf.Atan2(-mira.z, mira.x);
        rotacion = rotacion * (180 / Mathf.PI);
        transform.localEulerAngles = new Vector3(0, rotacion, 0);
        if (tiempoCorrer >= 10 && detectado)
        {
            patrones = Estado.atacar;
            puntero.transform.position = posJugador;
        }
    }

    void Ataque()
    {
        tiempoAtaque += Time.deltaTime;
        Vector3 fijador = (puntero.transform.position - posActual).normalized;
        float rotacion = Mathf.Atan2(fijador.x, fijador.z);
        rotacion = rotacion * (180 / Mathf.PI);
        transform.eulerAngles = new Vector3(0, rotacion, 0);
        if (ataque == 0)
        {
            puntero.transform.position = new Vector3(0, 0, 0);
            puntero.transform.localPosition = new Vector3(0, 0, 10);
            tiempoCorrer = 0;
            ataque++;
        }
        fijador.y = cuerpo.velocity.y;

        cuerpo.velocity = fijador * velEmbestida;

        if (limite)
        {
            locacion=proAnguloRadian;
            patrones = Estado.cansancio;
        }
    }

    void Descanso()
    {
        tiempoAtaque = 0;
        Vector3 descansar = cuerpo.velocity;
        descansar.x = 0;
        descansar.z = 0;
        cuerpo.velocity = descansar;
        ataque = 0;
        tiempoReposo += Time.deltaTime;
        if (tiempoReposo >= 5)
        {
            patrones = Estado.correr;
        }
    }

    void OnDrawGizmos()
    {
        if (candado == false)
        {
            marca.transform.localPosition = new Vector3(0, 0, largo);
            limitrofe.transform.position = marca.transform.position;
            limitrofe.transform.localScale = new Vector3(ancho * 2, 1, largo * 2);
            es1.transform.localPosition = new Vector3(0, 2, largo);
            es2.transform.localPosition = new Vector3(0, 2, -largo);
            es3.transform.localPosition = new Vector3(ancho, 2, 0);
            es4.transform.localPosition = new Vector3(-ancho, 2, 0);
        }
        Gizmos.color = Color.white;
        Gizmos.DrawLine(marca.transform.position + new Vector3(0, 2, 0), es1.transform.position);
        Gizmos.DrawLine(marca.transform.position + new Vector3(0, 2, 0), es2.transform.position);
        Gizmos.DrawLine(marca.transform.position + new Vector3(0, 2, 0), es3.transform.position);
        Gizmos.DrawLine(marca.transform.position + new Vector3(0, 2, 0), es4.transform.position);

    }
}
