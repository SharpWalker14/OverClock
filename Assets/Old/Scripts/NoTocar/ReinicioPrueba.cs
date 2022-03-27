using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReinicioPrueba : MonoBehaviour
{
    private Scene currentScene;
    
    private string sceneName;

    private GameObject jugador;

    public GameObject textoLeido;
    
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        Configuraciones();
    }

    void Configuraciones()
    {
        jugador.GetComponent<TiempoJugador>().tiempo = jugador.GetComponent<TiempoJugador>().tiempoMaximo;
        if (Input.GetKey(KeyCode.O))
        {
            SceneManager.LoadScene(sceneName);
        }
        if (Input.GetKey(KeyCode.I))
        {
            Destroy(textoLeido);
        }
    }
}
