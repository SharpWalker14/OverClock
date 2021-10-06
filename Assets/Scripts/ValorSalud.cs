using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorSalud : MonoBehaviour
{
    // En el HUD tiene que mostrar lo que es la variable vida (Si es jugador).
    public float vida;
    public bool jugador;
    private GameObject objetivo;
    public GameObject charcoAcido;
    public bool enemigodSuicida;
    public ValorTiempoEnemigo regalo;
    public bool explosionAcido, explosionHumo;

    private int intentos, charcos;
    void Start()
    {
        intentos = 0;
        charcos = 0;
        if (jugador == false)
        {
            objetivo = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        DañoExplosion();
    }
    public void CambioDeVida(float valor)
    {
        vida += valor;
        if (vida <= 0)
        {
            if (jugador == false && intentos == 0)
            {
                intentos++;
                objetivo.GetComponent<TiempoJugador>().ObtenerTiempo(regalo.valor);
            }

            if (enemigodSuicida == true && charcos == 0)
            {
                charcos += 1;
                Vector3 Acido = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);

                Instantiate(charcoAcido, Acido, transform.rotation);
            }
            Destroy(gameObject);
        }
        if (jugador == true)
        {
            GetComponent<FeedbackDaño>().Inicia();
        }
    }

    public void DañoExplosion()
    {
        if (explosionAcido == true)
        {
            vida -= 16;
            explosionAcido = false;
        }
        if (explosionHumo == true)
        {
            vida -= 16;
            explosionHumo = false;
        }

    }

    void OnTriggerStay(Collider col)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (jugador == true && other.gameObject.tag == "Explosion" && explosionAcido == false)
        {
            explosionAcido = true;
        }
        if (jugador == true && other.gameObject.tag == "Explosion" && explosionHumo == false)
        {
            explosionHumo = true;
        }
    }
}
