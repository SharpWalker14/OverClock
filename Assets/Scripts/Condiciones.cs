using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Condiciones : MonoBehaviour
{
    private GameObject nucleo;
    private NoDestruir datos;
    private GameObject jugador;
    public string nivel;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
        datos.siguienteEscena = nivel;
    }

    // Update is called once per frame
    void Update()
    {
        Derrota();
    }

    void Derrota()
    {
        if (jugador == null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("DerrotaProd");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == jugador)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("VictoriaProd");
        }
    }
}
