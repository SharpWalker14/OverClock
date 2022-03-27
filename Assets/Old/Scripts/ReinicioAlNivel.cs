using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReinicioAlNivel : MonoBehaviour
{
    private GameObject nucleo;
    private NoDestruir datos;

    // Start is called before the first frame update
    void Start()
    {
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
    }

    public void ReiniciarEnNivel()
    {
        SceneManager.LoadScene(datos.ultimaEscena);
    }
}
