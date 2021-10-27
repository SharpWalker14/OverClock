using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huevo : MonoBehaviour
{

    public enum Tipo { normal, sanador, potenciador };
    public Tipo tipoHuevo;
    public GameObject objeto;
    public int numeroPot;
    // Start is called before the first frame update
    void Start()
    {
        
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
        objeto.GetComponent<OrbePot>().Asignacion(numeroPot);
    }

    public void Toque()
    {
        if (tipoHuevo == Tipo.sanador || tipoHuevo == Tipo.potenciador)
        {
            Vector3 locacion = transform.position;
            locacion.y += 0.4f;
            objeto.transform.position = locacion;

            Instantiate(objeto);
        }
        Destroy(gameObject);
    }



}
