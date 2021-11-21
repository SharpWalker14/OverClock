using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CámaraPrimeraPersona : MonoBehaviour
{
    [HideInInspector]
    public float sensibilidad, multiX, multiY;
    public Transform jugadorGráficos;
    float rotaciónX = 0f;
    private GameObject nucleo;
    private NoDestruir datos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        nucleo = GameObject.FindGameObjectWithTag("Datos");
        datos = nucleo.GetComponent<NoDestruir>();
    }

    void Update()
    {
        Rotacion();
        FijarSensibilidad();
    }

    void Rotacion()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * 0.025f * multiX;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * 0.025f * multiY;
        rotaciónX -= mouseY;
        rotaciónX = Mathf.Clamp(rotaciónX, -90f, 90f);
        if (rotaciónX > 47.5f && mouseY < 0)
        {
            rotaciónX = 47.5f;
        }
        else if (rotaciónX < -60.5f && mouseY > 0)
        {
            rotaciónX = -60.5f;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(rotaciónX, 0f, 0f);
        }
        jugadorGráficos.Rotate(Vector3.up * mouseX);
    }

    void FijarSensibilidad()
    {
        sensibilidad = datos.sensibilidadMouse;
        multiX = datos.multAncho;
        multiY = datos.multAltura;
    }
}
