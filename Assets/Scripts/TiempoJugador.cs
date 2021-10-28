using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoJugador : MonoBehaviour
{
    public float tiempoMaximo;
    // En el HUD mostrar la variable tiempo.
    [HideInInspector]
    public float tiempo, tiempoCongelar, tiempoFrenesi, congelarMaximo;
    public ValorSalud salud;
    public bool muerte, cambioOportunidad, cambioFrenesi, cambioCongelar;
    [HideInInspector]
    public bool congelado;
    public FeedbackDaño feedback;
    // Start is called before the first frame update
    void Start()
    {
        cambioOportunidad = false;
        cambioFrenesi = false;
        cambioCongelar = false;
        congelado = false;
        muerte = false;
        tiempo = tiempoMaximo;
    }

    // Update is called once per frame
    void Update()
    {
        if (congelado == false && cambioCongelar == false)
        {
            CuentaRegresiva();
        }
        ListaPotenciadores();
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
        if (cambioFrenesi)
        {
            if (cambioCongelar)
            {
                if (congelarMaximo <= 5)
                {
                    tiempo += valor * 2;
                    congelarMaximo += valor * 2;
                }
            }
            else
            {
                tiempo += valor * 2;
            }
        }
        else
        {
            if (cambioCongelar)
            {
                if (congelarMaximo <= 5)
                {
                    tiempo += valor;
                    congelarMaximo += valor;
                }
            }
            else
            {
                tiempo += valor;
            }
        }

        if (tiempo > tiempoMaximo)
        {
            tiempo = tiempoMaximo;
        }
    }
    public void Paciente()
    {
        congelarMaximo = 0;
        tiempoCongelar = 20;
        cambioCongelar = true;

    }
    public void Frenetico()
    {
        tiempoFrenesi = 8;
        cambioFrenesi = true;

    }
    public void Oportuno()
    {
        cambioOportunidad = true;

    }


    void ListaPotenciadores()
    {
        if (cambioCongelar)
        {
            tiempoCongelar -= Time.deltaTime;
            if (tiempoCongelar <= 0)
            {
                tiempoCongelar = 0;
                cambioCongelar = false;
            }
        }
        if (cambioFrenesi)
        {
            tiempoFrenesi -= Time.deltaTime;
            if (tiempoFrenesi <= 0)
            {
                tiempoFrenesi = 0;
                cambioFrenesi = false;
            }
        }
        if (cambioOportunidad)
        {
            if (tiempo <= 1)
            {
                tiempo += 20;
            }
        }
    }
}
