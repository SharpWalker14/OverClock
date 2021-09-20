using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorSalud : MonoBehaviour
{
    // Para tarea de HUD de tarea (Si es jugador), hacer que manipule el variable tarea para el UI
    public int vida;
    public bool jugador;
    private GameObject objetivo;
    public ValorTiempoEnemigo regalo;
    // Start is called before the first frame update
    void Start()
    {
        if (jugador == false)
        {
            objetivo = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioDeVida(int valor)
    {
        vida -= valor;
        if (vida <= 0)
        {
            if (jugador == false)
            {
                objetivo.GetComponent<TiempoJugador>().ObtenerTiempo(regalo.valor);
            }
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {

    }

}
