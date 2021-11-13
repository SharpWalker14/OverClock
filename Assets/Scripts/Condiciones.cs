using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Condiciones : MonoBehaviour
{
    private GameObject jugador;
    public string nivel;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
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
            SceneManager.LoadScene(nivel);
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
