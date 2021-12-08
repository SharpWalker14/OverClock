using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorSalud : MonoBehaviour
{
    // En el HUD tiene que mostrar lo que es la variable vida (Si es jugador).
    public float vida;
    private float maxVida;
    public bool jugador;
    [HideInInspector]
    public bool armadura, muerto;
    public bool liviana, pesada;
    private GameObject objetivo, objetoMuerte;
    public GameObject charcoAcido, cortinaHumo, porDosObjecto, sonidoMuerte;
    public bool enemigodSuicida, enemigoHumo;
    public ValorTiempoEnemigo regalo;
    public bool explosionAcido, explosionHumo, ataqueMelee;
    public AudioClip[] sonido;

    private int intentos, charcos, numeroSonido;

    void Start()
    {
        muerto = false;
        if (sonido.Length != 0)
        {
            numeroSonido = Random.Range(0, sonido.Length);
        }
        sonidoMuerte.transform.position = transform.position;
        sonidoMuerte.tag = "Sonidos";
        objetoMuerte=Instantiate(sonidoMuerte);

        intentos = 0;
        charcos = 0;
        if (jugador == false)
        {
            objetivo = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            maxVida=vida;
        }
    }

    void Update()
    {
        DañoExplosion();
    }
    public void CambioDeVida(float valor)
    {
        if (armadura==false|| valor > 0)
        {
            vida += valor;
        }
        VidaPersonaje();
        if (jugador == true && valor < 0)
        {
            GetComponent<FeedbackDaño>().IniciaDaño();
        }
        if (jugador == false)
        {
            GetComponent<FeedbackEnemigos>().Inicia();
        }
    }

    public void DañoExplosion()
    {
        if (armadura == false)
        {
            if (explosionAcido == true)
            {
                vida -= 16;
                GetComponent<FeedbackDaño>().IniciaDaño();
            }
            if (explosionHumo == true)
            {
                vida -= 9;
                GetComponent<MovimientoJugador>().tiempoInmovilizado = 1.5f;
                GetComponent<MovimientoJugador>().inmovilizado = true;
                GetComponent<FeedbackDaño>().IniciaDaño();
            }
            explosionAcido = false;
            explosionHumo = false;
            VidaPersonaje();
        }
        objetoMuerte.transform.position = transform.position;

    }
    void VidaPersonaje()
    {
        if (vida <= 0 && muerto == false)
        {
            if (sonido.Length != 0)
            {
                objetoMuerte.GetComponent<AudioSource>().PlayOneShot(sonido[numeroSonido]);
            }
            if (jugador == false && intentos == 0)
            {
                intentos++;
                if (GetComponent<ValorTiempoEnemigo>().estadoHorda == false)
                {
                    objetivo.GetComponent<TiempoJugador>().ObtenerTiempo(regalo.valor);
                }
            }
            if (jugador == false)
            {
                if (objetivo.GetComponent<TiempoJugador>().cambioFrenesi && GetComponent<ValorTiempoEnemigo>().estadoHorda == false)
                {
                    Instantiate(porDosObjecto, transform.position, transform.rotation);
                }
            }
            if (enemigodSuicida == true && charcos == 0)
            {
                charcos += 1;
                Vector3 Acido = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Instantiate(charcoAcido, Acido, transform.rotation);
            }
            if (enemigoHumo == true && charcos == 0)
            {
                charcos += 1;
                Vector3 Humo = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Instantiate(cortinaHumo, Humo, transform.rotation);
            }
            muerto = true;
            Destroy(gameObject);
        }
        else if((vida>maxVida)&&jugador)
        {
            vida=maxVida;
        }
    }
    void DañoArma()
    {
        vida -= 120;
        GetComponent<FeedbackEnemigos>().Inicia();
        VidaPersonaje();
    }

    public void Inmunencia()
    {
        GetComponent<FeedbackEnemigos>().InmunidadEmpiezo();
    }

    void OnTriggerStay(Collider col)
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (jugador == true && other.gameObject.tag == "Explosion" && explosionAcido == false)
        {
            explosionAcido = true;
        }
        if (jugador == true && other.gameObject.tag == "Explosion2" && explosionHumo == false)
        {
            explosionHumo = true;
        }
        if (jugador == false && other.gameObject.tag == "ArmaAtaque" && pesada == false)
        {
            DañoArma();
        }
        else if (jugador == false && other.gameObject.tag == "ArmaAtaque" && pesada == true)
        {
            Inmunencia();
        }
    }
}
