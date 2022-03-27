using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJefe : MonoBehaviour
{
    public float vida;
    private bool armadura;
    [HideInInspector]
    public bool volando, cansancio;
    // Start is called before the first frame update
    void Start()
    {
        armadura = true;
        cansancio = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fases();
    }
    public void CambioDeVida(float valor)
    {
        if (armadura == false && valor < 0)
        {
            vida += valor;
        }
        if (vida <= 0)
        {
            cansancio = true;
            vida = 0;
        }
    }
    void Fases()
    {
        if (cansancio || volando)
        {
            armadura = true;
        }
    }
}
