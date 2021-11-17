using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialColision : MonoBehaviour
{
    public GameObject tutImagen, arma;
    public TiempoJugador temporizado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tocador();
    }

    void Tocador()
    {
        if (temporizado.tutorial)
        {
            tutImagen.SetActive(false);

            arma.SetActive(false);
        }
        else
        {
            tutImagen.SetActive(true);

            arma.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinTutorial")
        {
            temporizado.tutorial = false;
        }

    }
}
