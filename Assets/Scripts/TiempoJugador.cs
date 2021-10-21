using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoJugador : MonoBehaviour
{
    public float tiempoMaximo;
    // En el HUD mostrar la variable tiempo.
    public float tiempo;
    public ValorSalud salud;
    private bool muerte;
    [HideInInspector]
    public bool congelado;
    // Start is called before the first frame update
    void Start()
    {
        congelado = false;
        muerte = false;
        tiempo = tiempoMaximo;
    }

    // Update is called once per frame
    void Update()
    {
        if (congelado==false)
        {
            CuentaRegresiva();
        }
    }

    void CuentaRegresiva()
    {
        if (muerte == false)
        {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                salud.CambioDeVida(-salud.vida);
                muerte = true;
            }
        }
    }

    public void ObtenerTiempo(float valor)
    {
        tiempo += valor;
        if (tiempo > tiempoMaximo)
        {
            tiempo = tiempoMaximo;
        }
    }
}
