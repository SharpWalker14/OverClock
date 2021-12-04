using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTeclas : MonoBehaviour
{
    private int contador, conteoTecla;
    public GameObject mouseObj, controlesObj, saltoObj, disparoObj, tiempoObj, ascensorObj, combateObj;
    public GameObject puntero, tiempoHUD;
    public TiempoJugador tutoria;
    public MovimientoJugador movimiento;
    private string escena;
    private Scene escenaActual;
    private float tiempo;
    private bool temporizado, siguiente, espacio, disparo, ataque;
    // Start is called before the first frame update
    void Start()
    {
        temporizado = false;
        contador = 0;
        if (tutoria.tutorial)
        {
            puntero.SetActive(false);
            tiempoHUD.SetActive(false);
        }
        escenaActual = SceneManager.GetActiveScene();
        escena = escenaActual.name;
        if (escena == "Nivel2")
        {
            contador = 5;
        }
        if (escena == "Nivel3")
        {
            contador = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }

    public void ConteoTutorial()
    {
        switch (contador)
        {
            case 0:
                mouseObj.SetActive(true);
                tiempo = 3;
                siguiente = true;
                //"Presiona W, A, S y D para moverte y usa el Mouse para mirar hacia los lados"
                break;
            case 1:
                controlesObj.SetActive(true);
                mouseObj.SetActive(false);
                tiempo = 5;
                break;
            case 2:
                saltoObj.SetActive(true);
                controlesObj.SetActive(false);
                espacio = true;
                conteoTecla = 3;
                //"Presiona Space para saltar"
                break;
            case 3:
                disparoObj.SetActive(true);
                saltoObj.SetActive(false);
                puntero.SetActive(true);
                disparo = true;
                conteoTecla = 3;
                //"Presiona click izquierdo para disparar"
                break;
            case 4:
                tiempoObj.SetActive(true);
                disparoObj.SetActive(false);
                tiempoHUD.SetActive(true);
                tutoria.tutorialTiempo = false;
                tiempo = 3;
                break;
            case 5:
                ascensorObj.SetActive(true);
                tiempo = 4;
                break;
            case 6:
                combateObj.SetActive(true);
                ataque = true;
                conteoTecla = 3;
                break;
        }
        temporizado = true;
        contador++;
    }
    
    void Temporizador()
    {
        if (espacio || disparo || ataque)
        {
            if (espacio)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    conteoTecla--;
                }
            }
            else if (disparo)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    conteoTecla--;
                }
            }
            else if (ataque)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    conteoTecla--;
                }
            }
            if (conteoTecla == 0)
            {
                espacio = false;
                disparo = false;
                ataque = false;
            }
        }
        else if (temporizado)
        {
            tiempo -= Time.deltaTime;
            if (siguiente)
            {
                movimiento.velocidadMovimiento = 0;
            }
            if (tiempo <= 0)
            {
                tiempo = 0;
                controlesObj.SetActive(false);
                saltoObj.SetActive(false);
                disparoObj.SetActive(false);
                mouseObj.SetActive(false);
                tiempoObj.SetActive(false);
                ascensorObj.SetActive(false);
                combateObj.SetActive(false);
                temporizado = false;
                if (siguiente)
                {
                    movimiento.velocidadMovimiento = movimiento.normal;
                    siguiente = false;
                    ConteoTutorial();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TutorialTeclas")
        {
            ConteoTutorial();
            other.gameObject.SetActive(false);
        }
    }
}
