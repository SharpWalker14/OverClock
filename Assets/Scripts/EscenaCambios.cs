using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCambios : MonoBehaviour
{

    //Esto es para ir a cualquier escena, solo se debe cambiar el texto por 
    //el nombre de la escena donde se desea ir
    private void Update() //Este Update solo sirve para ejecutar el reinicio de escena
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            ReiniciarEscena();
        }
    }
    public void CambioEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    //Esto es para salir aunque no pasa nada por que estamos en unity,pero en el compilado si funciona
    public void Salir()
    {
        Application.Quit();
    }
    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

