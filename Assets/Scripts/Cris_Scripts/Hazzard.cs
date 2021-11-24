using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hazzard : MonoBehaviour
{
    public MovimientoJugador jugadorM;
    public Detector ataqueCerca;
    public float daño=1;
    public ValorSalud cambiante;
    public GameObject jugadorObj, areaObj;
    private RaycastHit pared, piso, jugadorRay;
    public float intentaMuro, intentaObjetivo, tiempo;
    public float rangoDeteccion;
    public bool enRangoVision, linea;
    public MeshFilter vista;
    public Mesh ataque;

    public Detector deteccion;
    public BoxCollider colision;

    void Start()
    {
        jugadorObj = GameObject.FindGameObjectWithTag("Player");
        jugadorM = jugadorObj.GetComponent<MovimientoJugador>();
    }

    void Update()
    {
        if (jugadorObj != null)
        {
            Vision();
            Atracción();
            Ataque();
        }

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
        Vector3 limite = new Vector3(jugadorObj.transform.position.x, transform.position.y, jugadorObj.transform.position.z);
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
        if (Physics.Linecast(transform.position, limite, out jugadorRay, mirarObjetivo) && deteccion.tocado)
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

    void Atracción()
    {
        /*if(enRangoVision)
        {
            jugadorObj.GetComponent<MovimientoJugador>().enabled = false;
            jugadorObj.GetComponent<NavMeshAgent>().destination = new Vector3 (transform.position.x, jugadorObj.transform.position.y, transform.position.z + 2);
        }*/
        if (enRangoVision)
        {
            jugadorM.eden = gameObject;
            vista.mesh = ataque;
            cambiante.liviana = false;
        }
    }

    void Ataque()
    {
        if (ataqueCerca.tocado)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 1)
            {
                jugadorObj.GetComponent<ValorSalud>().CambioDeVida(-daño);
                tiempo = 0;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rangoGizmo = new Vector3(0, 0, 0);
        rangoGizmo.z += rangoDeteccion;
        areaObj.transform.localPosition = rangoGizmo;
        Gizmos.DrawLine(transform.position, areaObj.transform.position);
        Gizmos.color = Color.blue;
        colision.size = new Vector3(0.1f, 0.1f, rangoDeteccion);
        colision.center = new Vector3(0, 0, rangoDeteccion / 2);


    }
}
