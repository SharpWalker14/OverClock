using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmarTutorial : MonoBehaviour
{
    private GameObject nucleo;
    private NoDestruir datos;
    // Start is called before the first frame update
    void Start()
    {
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Novato()
    {
        datos.tutorial = true;
        SceneManager.LoadScene("Nivel1");
    }

    public void Veterano()
    {
        datos.tutorial = false;
        SceneManager.LoadScene("Nivel1");
    }
}
