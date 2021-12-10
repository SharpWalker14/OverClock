using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAscensor : MonoBehaviour
{
    public Detector interruptor;
    public GameObject objeto, dialogo, destructorObjeto;
    public Material objetoEncendido, objetoApagado;
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
        if (interruptor.tocado && encendido == false)
        {
            dialogo.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(destructorObjeto);
                encendido = true;
            }
        }
        else if (interruptor.tocado == false && encendido == false)
        {
            dialogo.SetActive(false);
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
