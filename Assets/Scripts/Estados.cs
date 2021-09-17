using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estados : MonoBehaviour
{
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioDeVida(int valor)
    {
        vida -= valor;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {

    }

}
