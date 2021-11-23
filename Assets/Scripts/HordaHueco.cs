using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaHueco : MonoBehaviour
{
    private bool visto, enVacio;
    public Detector deteccion;
    [HideInInspector]
    public bool confirmado, resuelto, obsoleto;
    private bool suelo, pared;
    public GameObject[] lugares;
    public GameObject enemigo, vistaObjeto;
    private GameObject camara;
    private RaycastHit vista;

    // Start is called before the first frame update
    void Start()
    {
        obsoleto = false;
        camara = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (camara != null && !obsoleto)
        {
            VisionParedes();
            Comprobar();
            Resultado();
        }
    }

    void VisionParedes()
    {
        LayerMask mascaraA = LayerMask.GetMask("Piso");
        LayerMask mascaraB = LayerMask.GetMask("Pared");
        if (Physics.Linecast(vistaObjeto.transform.position, camara.transform.position, out vista, mascaraA))
        {
            suelo = true;
        }
        else
        {
            suelo = false;
        }
        if (Physics.Linecast(vistaObjeto.transform.position, camara.transform.position, out vista, mascaraB))
        {
            pared = true;
        }
        else
        {
            pared = false;
        }
        if (suelo == false && pared == false)
        {
            enVacio=true;
        }
        else
        {
            enVacio=false;
        }
    }

    void Comprobar()
    {
        if (enVacio && visto)
        {
            confirmado = true;
        }
        else
        {
            confirmado = false;
        }
    }

    void Resultado()
    {
        if (confirmado && deteccion.tocado == true)
        {
            resuelto = true;
        }
        else
        {
            resuelto = false;
        }
    }

    float Distancia()
    {
        float distancia;

        distancia = Vector3.Distance(vistaObjeto.transform.position, camara.transform.position);

        return distancia;
    }

    void OnBecameVisible()
    {
        visto = true;
    }

    void OnBecameInvisible()
    {
        visto = false;
    }

    public void Invocacion()
    {
        if (!obsoleto)
        {
            for (int i = 0; i < lugares.Length; i++)
            {
                enemigo.transform.position = lugares[i].transform.position;
                enemigo.GetComponent<MovimientoEnemigo>().tranquilo = false;
                enemigo.GetComponent<ValorTiempoEnemigo>().estadoHorda = true;
                Instantiate(enemigo);
                enemigo.GetComponent<MovimientoEnemigo>().tranquilo = true;
                enemigo.GetComponent<ValorTiempoEnemigo>().estadoHorda = false;
            }
        }
    }
}
