using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hazzard : MonoBehaviour
{
    public MovimientoJugador jugadorM;
    public float da�o=1;
    public GameObject jugadorObj;
    private RaycastHit pared, piso, jugadorRay;
    private float intentaMuro, intentaObjetivo, tiempo;
    public float rangoDeteccion;
    public bool enRangoVision, linea;

    void Start()
    {
        jugadorObj = GameObject.FindGameObjectWithTag("Player");
        jugadorM = jugadorObj.GetComponent<MovimientoJugador>();
    }

    void Update()
    {
        Vision();
        Atracci�n();
        Ataque();
        //Muerte();
    }

    void Vision()
    {
        /*float dist = Vector3.Distance(jugadorObj.transform.position, transform.position);
        if (dist < rangoDeteccion)
        {
            enRangoVision = true;
        }
        else
        {
            enRangoVision = false;
        }*/
        LayerMask mascaraA = LayerMask.GetMask("Piso");
        LayerMask mascaraB = LayerMask.GetMask("Pared");
        LayerMask mirarObjetivo = LayerMask.GetMask("Jugador");
        Vector3 limite = new Vector3(transform.position.x, transform.position.y, jugadorObj.transform.position.z);
        intentaObjetivo = Vector3.Distance(transform.position, limite);

        if (Physics.Linecast(transform.position, limite, out pared, mascaraB))
        {
            intentaMuro = Vector3.Distance(transform.position, pared.point);
        }
        else if (Physics.Linecast(transform.position, limite, out piso, mascaraA))
        {
            intentaMuro = Vector3.Distance(transform.position, piso.point);
        }
        else
        {
            intentaMuro = rangoDeteccion;

        }
        if (Physics.Linecast(transform.position, limite, out jugadorRay, mirarObjetivo))
        {
            linea = true;
        }
        else
        {
            linea = false;
        }

        if (intentaMuro <= intentaObjetivo || linea == false)
        {
            enRangoVision = false;
        }
        else if (intentaMuro > intentaObjetivo&&linea==true)
        {
            enRangoVision = true;
        }
    }

    void Atracci�n()
    {
        /*if(enRangoVision)
        {
            jugadorObj.GetComponent<MovimientoJugador>().enabled = false;
            jugadorObj.GetComponent<NavMeshAgent>().destination = new Vector3 (transform.position.x, jugadorObj.transform.position.y, transform.position.z + 2);
        }*/
        if (enRangoVision)
        {
            jugadorM.eden = gameObject;
        }
    }

    void Ataque()
    {
        if (enRangoVision)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 1)
            {
                jugadorObj.GetComponent<ValorSalud>().CambioDeVida(-da�o);
                tiempo = 0;
            }
        }
    }

    void Muerte()
    {
        if(Input.GetKey(KeyCode.F))
        {
            jugadorObj.GetComponent<MovimientoJugador>().enabled = true;
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        Vector3 visionGizmo = new Vector3(0.25f, 0.25f, rangoDeteccion);
        Vector3 verRango = new Vector3(0, 0, rangoDeteccion / 2);
        Gizmos.DrawWireCube(transform.position + verRango, visionGizmo);
        Gizmos.color = Color.blue;

    }
}