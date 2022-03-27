using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAscensor : MonoBehaviour
{
    public Detector interruptor, cercaniaJugador;
    public GameObject objeto, dialogo, destructorObjeto;
    public Material objetoEncendido, objetoApagado;
    public TutorialTeclas ver;
    private bool encendido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerInterruptor();
    }

    void VerInterruptor()
    {
        if (cercaniaJugador.tocado && encendido == false)
        {
            dialogo.SetActive(true);
            if (ver.contador == 6)
            {
                ver.tiempo = 0;
            }
        }
        else
        {
            dialogo.SetActive(false);
        }
        if (interruptor.tocado && encendido == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(destructorObjeto);
                encendido = true;
            }
        }
        if (encendido)
        {
            objeto.GetComponent<MeshRenderer>().material = objetoEncendido;
            dialogo.SetActive(false);
        }
        else
        {
            objeto.GetComponent<MeshRenderer>().material = objetoApagado;
        }
    }

}
