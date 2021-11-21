using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    public NavMeshAgent inteligencia;
    public ValorSalud valores;
    public bool tranquilo;
    [HideInInspector]
    public float guardarVelocidad, guardarAceleracion, guardarVida;
    public EnemigoSentidos radar;
    private int fijador;

    public GameObject[] puntoPatrulla;


    public GameObject patrullero;
    private int patrullajePasado, numeroPatrulla, proximidad;
    [HideInInspector]
    public GameObject[] guardarPatrulla;
    public Detector deteccionPatrulla;
    private bool candado = true, candadoDraw = false;
    // Start is called before the first frame update
    void Start()
    {
        if (valores != null)
        {
            guardarVida = valores.vida;
        }
        fijador = 0;
        if (puntoPatrulla.Length != 0)
        {
            ControlPatrullas();
        }
        candadoDraw = true;
        numeroPatrulla = 0;
        guardarVelocidad = inteligencia.speed;
        guardarAceleracion = inteligencia.acceleration;
        patrullero.transform.parent = null;
        candado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (radar != null)
        {
            if (radar.objetivo != null)
            {
                Movimiento();
            }
        }
    }

    void Movimiento()
    {
        if (tranquilo)
        {
            if (numeroPatrulla > puntoPatrulla.Length - 1)
            {
                numeroPatrulla = 0;
                proximidad = numeroPatrulla + 1;
                if (proximidad > puntoPatrulla.Length - 1)
                {
                    proximidad = 0;
                }
            }
            if (puntoPatrulla.Length != 0)
            {
                inteligencia.SetDestination(puntoPatrulla[numeroPatrulla].transform.position);
                if (puntoPatrulla[numeroPatrulla] == deteccionPatrulla.objetoRegistrado)
                {
                    numeroPatrulla += 1;
                }
            }
            if (radar.detectar || guardarVida != valores.vida)
            {
                valores.pesada = false;
                Mirar();
                tranquilo = false;
            }

        }
        else
        {
            inteligencia.SetDestination(radar.objetivo.transform.position);
            if (guardarVelocidad == 0)
            {
                Mirar();
            }
        }

    }

    void Mirar()
    {
        if (fijador == 0 || (guardarVelocidad == 0 && tranquilo == false))
        {
            fijador++;

            Vector3 objetivoO = radar.objetivo.transform.position;
            objetivoO.y = 0;
            Vector3 vistaO = transform.position;
            vistaO.y = 0;
            Vector3 mira = (objetivoO - vistaO).normalized;
            float rotacion = Mathf.Atan2(mira.x, mira.z);
            rotacion = rotacion * (180 / Mathf.PI);
            transform.localEulerAngles = new Vector3(0, rotacion, 0);
        }
    }



    #region GizmosNoTocar

    void OnDrawGizmos()
    {
        if (candadoDraw == false)
        {
            if (candado)
            {
                patrullajePasado = puntoPatrulla.Length;
                candado = false;
            }
            ControlarPuntos();
            if (puntoPatrulla.Length != 0)
            {
                ControlPatrullas();
            }
            for (int i = 0; i < puntoPatrulla.Length; i++)
            {
                if (puntoPatrulla[i] != null)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(puntoPatrulla[i].transform.position, 0.5f);
                    Gizmos.color = Color.red;
                    Vector3 tamañoAltura = new Vector3(0.1f, 1, 0.1f), precaucion = new Vector3(0, -0.5f, 0);
                    Gizmos.DrawWireCube(puntoPatrulla[i].transform.position + precaucion, tamañoAltura);
                }
            }

            for (int i = 1; i < puntoPatrulla.Length; i++)
            {
                Gizmos.DrawLine(puntoPatrulla[i].transform.position, puntoPatrulla[i - 1].transform.position);
            }
            if (puntoPatrulla.Length > 1)
            {
                Gizmos.DrawLine(puntoPatrulla[puntoPatrulla.Length - 1].transform.position, puntoPatrulla[0].transform.position);
            }
        }
    }

    void ControlarPuntos()
    {
        if (patrullajePasado != puntoPatrulla.Length)
        {
            if (patrullajePasado > puntoPatrulla.Length)
            {
                for (int i = 0; i < patrullajePasado; i++)
                {
                    if (i > puntoPatrulla.Length - 1)
                    {
                        DestruirPuntos(i);
                    }
                }
                NuevosPuntos();
                GuardaPuntos();
            }
            else if (patrullajePasado < puntoPatrulla.Length)
            {
                for (int i = 0; i < puntoPatrulla.Length; i++)
                {
                    if (i > patrullajePasado - 1)
                    {
                        AnadirPuntos(i);
                        GuardaPuntos();
                    }
                }
            }
            patrullajePasado = puntoPatrulla.Length;
        }
    }

    void ControlPatrullas()
    {
        for (int i = 0; i < guardarPatrulla.Length; i++)
        {
            puntoPatrulla[i] = GameObject.Find(gameObject.name + "/" + patrullero.name + "/Punto de Patrulla " + i);
            guardarPatrulla[i] = GameObject.Find(gameObject.name + "/" + patrullero.name + "/Punto de Patrulla " + i);
        }
    }

    void AnadirPuntos(int numero)
    {
        NuevosPuntos();
        GameObject nuevoGO = new GameObject();
        nuevoGO.name = "Punto de Patrulla " + numero;
        nuevoGO.tag = "Punto de patrulla";
        nuevoGO.transform.parent = patrullero.transform;
        nuevoGO.transform.position = patrullero.transform.position;
        CapsuleCollider colision = nuevoGO.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        colision.isTrigger = true;
        colision.radius = 0.1f;
        colision.height = 0.75f;

        puntoPatrulla[numero] = nuevoGO;
    }
    void DestruirPuntos(int numero)
    {
        DestroyImmediate(guardarPatrulla[numero]);
    }
    
    void NuevosPuntos()
    {
        guardarPatrulla = new GameObject[puntoPatrulla.Length];
    }
    void GuardaPuntos()
    {
        for (int i = 0; i < guardarPatrulla.Length; i++)
        {
            guardarPatrulla[i] = puntoPatrulla[i];
        }
    }
    #endregion


}
