using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huevo : MonoBehaviour
{

    public enum Tipo { normal, sanador, potenciador };
    public Tipo tipoHuevo;
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Toque()
    {
        if (tipoHuevo == Tipo.sanador || tipoHuevo == Tipo.potenciador)
        {

        }
        Destroy(gameObject);
    }
}
