using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCambios : MonoBehaviour
{
  
    //Esto es para ir a cualquier escena, solo se debe cambiar el texto por 
    //el nombre de la escena donde se desea ir
    public void CambioEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    //Esto es para salir aunque no pasa nada por que estamos en unity,pero en el compilado si funciona
    public void Salir()
    {
        Application.Quit();
    }
}

