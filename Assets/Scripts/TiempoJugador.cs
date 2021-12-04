using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiempoJugador : MonoBehaviour
{
    public float tiempoMaximo;
    // En el HUD mostrar la variable tiempo.
    [HideInInspector]
    public float tiempo, tiempoCongelar, tiempoFrenesi, congelarMaximo;
    public ValorSalud salud;
    public bool tutorial;
    public Color estado1;
    public Color estado2;
    public Color estado3;
    public Image reloj;
    public float etapa1, etapa2, etapa3;
    [HideInInspector]
    public bool congelado, muerte, cambioOportunidad, cambioFrenesi, cambioCongelar, tutorialTiempo;
    public FeedbackDaño feedback;
    public GameObject objOportunidad, objFrenesi, objCongelar, tiempoHUD;
    // Start is called before the first frame update
    void Start()
    {
        if (tutorial)
        {
            tutorialTiempo = true;
        }
        else
        {
            tutorialTiempo = false;
        }
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
        Temporizador();

        ListaPotenciadores();
    }

    void Temporizador()
    {
        if (tutorialTiempo == false)
        {
            tiempoHUD.SetActive(true);
            if (congelado == false && cambioCongelar == false)
            {
                CuentaRegresiva();
            }
            Etapas();
        }
        else
        {
            tiempoHUD.SetActive(false);
        }
    }

    void Etapas()
    {
        if (tiempo <= etapa1 && tiempo > etapa2)
        {
            reloj.color = estado1;
        }
        else if (tiempo <= etapa2 && tiempo >= etapa3)
        {
            reloj.color = estado2;
        }
        else if (tiempo <= etapa3)
        {
            reloj.color = estado3;
        }
    }
    void CuentaRegresiva()
    {
        if (muerte == false)
        {
            tiempo -= Time.deltaTime * 1.1f;
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
            objCongelar.SetActive(true);
            tiempoCongelar -= Time.deltaTime;
            if (tiempoCongelar <= 0)
            {
                tiempoCongelar = 0;
                cambioCongelar = false;

            }
        }
        else
        {
            objCongelar.SetActive(false);
        }
        if (cambioFrenesi)
        {
            objFrenesi.SetActive(true);

            tiempoFrenesi -= Time.deltaTime;
            if (tiempoFrenesi <= 0)
            {
                tiempoFrenesi = 0;
                cambioFrenesi = false;
            }
        }
        else
        {
            objFrenesi.SetActive(false);
        }
        if (cambioOportunidad)
        {
            objOportunidad.SetActive(true);
            if (tiempo <= 1)
            {
                tiempo += 20;
                cambioOportunidad = false;
            }
        }
        else
        {
            objOportunidad.SetActive(false);
        }
    }
}
