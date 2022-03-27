using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huevo : MonoBehaviour
{

    public enum Tipo { normal, sanador, potenciador };
    public Tipo tipoHuevo;
    public GameObject objeto, sonidoRomper;
    private GameObject objetoRomper;
    public int numeroPot;
    public AudioClip sonido;
    // Start is called before the first frame update
    void Start()
    {
        if (sonido != null)
        {
            sonidoRomper.transform.position = transform.position;
            sonidoRomper.tag = "Sonidos";
            objetoRomper = Instantiate(sonidoRomper);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PotenciadorEscoger(bool oportunidad, bool tiempo)
    {
        if (oportunidad)
        {
            numeroPot = 3;
        }
        else
        {
            if (tiempo)
            {
                numeroPot = 1;
            }
            else
            {
                numeroPot = 2;
            }
        }
    }

    public bool HuevoVerdad()
    {
        if (tipoHuevo == Tipo.potenciador)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Toque()
    {
        if (tipoHuevo == Tipo.sanador || tipoHuevo == Tipo.potenciador)
        {
            Vector3 locacion = transform.position;
            locacion.y += 0.4f;
            objeto.transform.position = locacion;
            if (objeto.GetComponent<OrbePot>() != null)
            {
                objeto.GetComponent<OrbePot>().Asignacion(numeroPot);
            }
            Instantiate(objeto);
        }
        if (sonido != null)
        {
            objetoRomper.GetComponent<AudioSource>().PlayOneShot(sonido);
        }
        Destroy(gameObject);
    }



}
