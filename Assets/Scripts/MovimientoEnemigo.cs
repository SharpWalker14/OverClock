using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoEnemigo : MonoBehaviour
{
    private NavMeshAgent ia;
    public Detecting deteccion;




    public GameObject[] puntoPatrulla;
    public GameObject patrullero;
    private int patrullajePasado, numeroPatrulla, proximidad;
    private GameObject[] guardarPatrulla;
    private bool candado=true;
    // Start is called before the first frame update
    void Start()
    {
        numeroPatrulla = 0;
        ia = GetComponent<NavMeshAgent>();
        patrullero.transform.parent = null;
        candado = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        
    }

    void Movimiento()
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
            ia.SetDestination(puntoPatrulla[numeroPatrulla].transform.position);
            if (puntoPatrulla[numeroPatrulla] == deteccion.objetoRegistrado)
            {
                numeroPatrulla += 1;
            }
        }
    }

    #region GizmosNoTocar

    void OnDrawGizmos()
    {
        if (candado)
        {
            patrullajePasado = puntoPatrulla.Length;
            candado = false;
        }
        ControlarPuntos();
        for (int i = 0; i < puntoPatrulla.Length; i++)
        {
            if (puntoPatrulla[i] != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(puntoPatrulla[i].transform.position, 0.5f);
                Gizmos.color = Color.red;
                Vector3 tamañoAltura = new Vector3(0.1f, 1, 0.1f), precaucion = new Vector3(0, -0.5f, 0);
                Gizmos.DrawWireCube(puntoPatrulla[i].transform.position+precaucion, tamañoAltura);
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
