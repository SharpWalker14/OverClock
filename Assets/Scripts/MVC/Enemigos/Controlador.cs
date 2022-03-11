using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public Modelo m;
    void Awake()
    {
        m.objetivoJugador = GameObject.FindGameObjectWithTag("Player");

        if (m != null)
        {
            m.guardarVida = m.vida;
        }

        m.fijador = 0;

        if (m.puntoPatrulla.Length != 0)
        {
            ControlPatrullas();
        }

        // m.tocado = false;
        m.calmado = true;
        m.candadoDraw = true;
        m.numeroPatrulla = 0;
        m.guardarVelocidad = m.inteligencia.speed;
        m.guardarAceleracion = m.inteligencia.acceleration;
        m.patrullero.transform.parent = null;
        m.candado = true;

        m.dañoVida = m.vida;
        if (m.sonidoMuerte.Length != 0)
        {
            m.numeroSonido = Random.Range(0, m.sonidoMuerte.Length);
        }
        m.maxVida = m.vida;
        m.intentos = 0;
        m.charcos = 0;

        m.animacionAtaque = false;
        m.preparaAtaque = false;
        m.conteoAtaque = 0;
        m.tiempoAtaque = 0;
        m.tiempoAnimacion = 0;
        m.tiempoAturdidor = 0;
        m.contadorMuerte = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m.objetivoJugador != null)
        {
            if (m.vida <= 0)
            {
                VidaPersonaje();
            }
            else
            {
                Movimiento();
                RecibirDaño();
                Ataque();
            }
        }
    }

    public void Ataque()
    {
        m.conteoAtaque += Time.deltaTime;
        if (m.conteoAtaque >= m.frecuencia)
        {
            m.preparaAtaque = true;
        }
        if (m.aturdidor)
        {
            m.tiempoAturdidor += Time.deltaTime;
        }
        if (m.deteccionAtaque.tocado && m.preparaAtaque)
        {
            m.deteccionAtaque.objetoRegistrado.GetComponent<ValorSalud>().CambioDeVida(-m.daño);

            m.escogerSonidoAtaque = Random.Range(0, m.sonidoAtaque.Length);

            m.golpe.GetComponent<AudioSource>().PlayOneShot(m.sonidoAtaque[m.escogerSonidoAtaque]);

            if (m.aturdidor && m.tiempoAturdidor >= 5)
            {
                m.deteccionAtaque.objetoRegistrado.GetComponent<MovimientoJugador>().tiempoInmovilizado = 1;
                m.deteccionAtaque.objetoRegistrado.GetComponent<MovimientoJugador>().inmovilizado = true;
                m.tiempoAturdidor = 0;
            }
            m.conteoAtaque = 0;
            m.preparaAtaque = false;
            m.animacionAtaque = true;
        }
        if (m.deteccionAtaque.tocado)
        {
            m.tiempoAtaque = 0.5f;
            if (m.inteligencia.speed >= 0)
            {
                m.inteligencia.acceleration = 100;
                m.inteligencia.speed = 0;
            }
        }
        else if (m.tiempoAtaque > 0)
        {
            m.tiempoAtaque -= Time.deltaTime;
            m.animacionAtaque = false;
        }
        if (m.tiempoAtaque > 0)
        {
            if (m.inteligencia.speed >= 0)
            {
                m.inteligencia.acceleration = 100;
                m.inteligencia.speed = 0;
            }
        }
        else
        {
            m.tiempoAtaque = 0;
            m.inteligencia.speed = m.guardarVelocidad;
            m.inteligencia.acceleration = m.guardarAceleracion;
        }
    }

    public void VidaPersonaje()
    {
        if (m.vida <= 0 && m.contadorMuerte == 0)
        {
            m.inteligencia.speed = 0;

            m.escogerSonidoMuerte = Random.Range(0, m.sonidoMuerte.Length);

            m.muerte.GetComponent<AudioSource>().PlayOneShot(m.sonidoMuerte[m.escogerSonidoMuerte]);

            if (m.intentos == 0)
            {
                m.intentos++;
                if (m.estadoHorda == false)
                {
                    m.objetivoJugador.GetComponent<TiempoJugador>().ObtenerTiempo(m.valor);
                }
            }

            if (m.objetivoJugador.GetComponent<TiempoJugador>().cambioFrenesi && m.estadoHorda == false)
            {
              Instantiate(m.x2Letra, transform.position, transform.rotation);
            }
                
            if (m.Enemigos == Modelo.Especie.Meloso && m.charcos == 0)
            {
                m.charcos += 1;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out m.hit, 10, ~(2 << 6)))
                {
                    Instantiate(m.charcoAcido, m.hit.point, transform.rotation);
                }
            }

            if (m.Enemigos == Modelo.Especie.Cegador == true && m.charcos == 0)
            {
                m.charcos += 1;
                Vector3 Humo = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Instantiate(m.cortinaHumo, Humo, transform.rotation);
            }
            m.contadorMuerte += 1;
        }
    }
    public void Inmunencia()
    {
        if (m.inmunidadSonar.Length != 0)
        {
            GetComponent<Vista>().InmunidadEmpiezo();
            m.numerador = Random.Range(0, m.inmunidadSonar.Length);
            m.inmuneSonido.GetComponent<AudioSource>().PlayOneShot(m.inmunidadSonar[m.numerador]);
        }
    }
    public void RecibirDaño()
    {
        if (m.ataqueCaC == true)
        {
            m.vida -= 120;
        }

        if (m.vida < m.dañoVida)
        {
            m.espera = true;
        }
        else
        {
            m.espera = false;
        }

        if (m.espera)
        {
            if (m.detente == 0)
            {
                GetComponent<Vista>().Inicia();

                m.escogerSonidoRecibirDaño = Random.Range(0, m.sonidoRecibirDaño.Length);

                m.recibirDaño.GetComponent<AudioSource>().PlayOneShot(m.sonidoRecibirDaño[m.escogerSonidoRecibirDaño]);
                m.detente++;
            }

            m.tiempoAnimacion += Time.deltaTime;
            if (m.tiempoAnimacion >= 0.5f)
            {
                m.dañoVida = m.vida;
            }
        }
        else
        {
            m.tiempoAnimacion = 0;
            m.detente = 0;
        }
    }

    public void CambioVida(int valor)
    {
        if (m.contadorMuerte < 1)
        {
            m.vida += valor;

            GetComponent<Vista>().Inicia();
        }
    }

    public void Movimiento()
    {
        if (m.calmado)
        {
            if (m.numeroPatrulla > m.puntoPatrulla.Length - 1)
            {
                m.numeroPatrulla = 0;
                m.proximidad = m.numeroPatrulla + 1;
                if (m.proximidad > m.puntoPatrulla.Length - 1)
                {
                    m.proximidad = 0;
                }
            }
            if (m.puntoPatrulla.Length != 0)
            {
                m.inteligencia.SetDestination(m.puntoPatrulla[m.numeroPatrulla].transform.position);
                if (m.puntoPatrulla[m.numeroPatrulla] == m.deteccionPatrulla.objetoRegistrado)
                {
                    m.numeroPatrulla += 1;
                }
            }
            if (m.radar.detectar || m.guardarVida != m.vida)
            {
                m.pesada = false;
                Mirar();
                m.calmado = false;
            }

        }
        else
        {
            m.inteligencia.SetDestination(m.radar.objetivo.transform.position);
            if (m.guardarVelocidad == 0)
            {
                Mirar();
            }
        }
    }

    public void Mirar()
    {
        if (m.fijador == 0 || (m.guardarVelocidad == 0 && m.calmado == false))
        {
            m.fijador++;

            Vector3 objetivoO = m.radar.objetivo.transform.position;
            objetivoO.y = 0;
            Vector3 vistaO = transform.position;
            vistaO.y = 0;
            Vector3 mira = (objetivoO - vistaO).normalized;
            float rotacion = Mathf.Atan2(mira.x, mira.z);
            rotacion = rotacion * (180 / Mathf.PI);
            transform.localEulerAngles = new Vector3(0, rotacion, 0);
        }
    }
   

    #region GizmoNoTocar
    void OnDrawGizmos()
    {
         if (m.candadoDraw == false)
        {
            if (m.candado)
            {
                m.patrullajePasado = m.puntoPatrulla.Length;
                m.candado = false;
            }
            ControlarPuntos();
            if (m.puntoPatrulla.Length != 0)
            {
                ControlPatrullas();
            }
            for (int i = 0; i < m.puntoPatrulla.Length; i++)
            {
                if (m.puntoPatrulla[i] != null)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(m.puntoPatrulla[i].transform.position, 0.5f);
                    Gizmos.color = Color.red;
                    Vector3 tamañoAltura = new Vector3(0.1f, 1, 0.1f), precaucion = new Vector3(0, -0.5f, 0);
                    Gizmos.DrawWireCube(m.puntoPatrulla[i].transform.position + precaucion, tamañoAltura);
                }
            }

            for (int i = 1; i < m.puntoPatrulla.Length; i++)
            {
                Gizmos.DrawLine(m.puntoPatrulla[i].transform.position, m.puntoPatrulla[i - 1].transform.position);
            }
            if (m.puntoPatrulla.Length > 1)
            {
                Gizmos.DrawLine(m.puntoPatrulla[m.puntoPatrulla.Length - 1].transform.position, m.puntoPatrulla[0].transform.position);
            }
         }
    }

    void ControlarPuntos()
    {
        if (m.patrullajePasado != m.puntoPatrulla.Length)
        {
            if (m.patrullajePasado > m.puntoPatrulla.Length)
            {
                Debug.Log("t");
                for (int i = 0; i < m.patrullajePasado; i++)
                {
                    if (i > m.puntoPatrulla.Length - 1)
                    {
                        DestruirPuntos(i);
                        Debug.Log("u");
                    }
                }
                Debug.Log("l");
                NuevosPuntos();
                GuardaPuntos();
            }
            else if (m.patrullajePasado < m.puntoPatrulla.Length)
            {
                for (int i = 0; i < m.puntoPatrulla.Length; i++)
                {
                    if (i > m.patrullajePasado - 1)
                    {
                        AnadirPuntos(i);
                        Debug.Log("a");
                        GuardaPuntos();
                    }
                }
            }
            m.patrullajePasado = m.puntoPatrulla.Length;
        }
    }
    public void ControlPatrullas()
    {
        for (int i = 0; i < m.guardarPatrulla.Length; i++)
        {
            m.puntoPatrulla[i] = GameObject.Find(gameObject.name + "/" + m.patrullero.name + "/Punto de Patrulla " + i);
            m.guardarPatrulla[i] = GameObject.Find(gameObject.name + "/" + m.patrullero.name + "/Punto de Patrulla " + i);
        }
    }
    public void AnadirPuntos(int numero)
    {
        NuevosPuntos();
        GameObject nuevoGO = new GameObject();
        nuevoGO.name = "Punto de Patrulla " + numero;
        nuevoGO.tag = "Punto de patrulla";
        nuevoGO.transform.parent = m.patrullero.transform;
        nuevoGO.transform.position = m.patrullero.transform.position;
        CapsuleCollider colision = nuevoGO.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        colision.isTrigger = true;
        colision.radius = 0.1f;
        colision.height = 0.75f;

        m.puntoPatrulla[numero] = nuevoGO;
    }

    public void DestruirPuntos(int numero)
    {
       DestroyImmediate(m.guardarPatrulla[numero]);
       Debug.Log("s");
    }

    public void NuevosPuntos()
    {
        m.guardarPatrulla = new GameObject[m.puntoPatrulla.Length];
    }
    public void GuardaPuntos()
    {
        for (int i = 0; i < m.guardarPatrulla.Length; i++)
        {
            m.guardarPatrulla[i] = m.puntoPatrulla[i];
        }
    }

    #endregion
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArmaAtaque" && m.pesada == false)
        {
            m.ataqueCaC = true;
        }
        else if (other.gameObject.tag == "ArmaAtaque" && m.pesada == true)
        {
            Inmunencia();
        }
    }
   
}
