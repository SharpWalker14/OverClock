using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public static bool juegoPausado = false;
    [HideInInspector]
    public bool pausar;
    public GameObject pausaMenu;

    void Start()
    {
        juegoPausado = false;
        Cursor.visible = false;
        pausar = juegoPausado;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (juegoPausado)
            {
                
            }
            else
            {
                Pausar();
            }
        }

    }
    void Pausar()
    {
        pausaMenu.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
        pausar = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Reanudar()
    {
        pausaMenu.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
        pausar = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
