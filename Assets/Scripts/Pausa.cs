using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public static bool juegoPausado = false;
    public GameObject pausaMenu;

    void Start()
    {
        juegoPausado = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (juegoPausado)
            {
                Reanudar();
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Reanudar()
    {
        pausaMenu.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
