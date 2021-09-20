using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoJugador : MonoBehaviour
{
    public float tiempoMaximo;
    // Para tarea de HUD de tiempo, hacer que manipule el variable tiempo para el UI
    public float tiempo;
    public ValorSalud salud;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = tiempoMaximo;
    }

    // Update is called once per frame
    void Update()
    {
        CuentaRegresiva();
    }

    void CuentaRegresiva()
    {
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            salud.CambioDeVida(-salud.vida);
        }
        if (tiempo > tiempoMaximo)
        {
            tiempo = tiempoMaximo;
        }
    }

    public void ObtenerTiempo(int valor)
    {
        tiempo += valor;
    }
}
