using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionalVictoria : MonoBehaviour
{
    public GameObject legionario, puerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Condicion();
    }

    void Condicion()
    {
        if (legionario == null)
        {
            puerta.SetActive(true);
        }
        else
        {
            puerta.SetActive(false);
        }
    }
}
