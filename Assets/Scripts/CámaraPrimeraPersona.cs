using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CámaraPrimeraPersona : MonoBehaviour
{
    public float sensibilidad = ControladorDeJuego.sensibilidadMouse;
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
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        rotaciónX -= mouseY;
        rotaciónX = Mathf.Clamp(rotaciónX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotaciónX, 0f, 0f);
        jugadorGráficos.Rotate(Vector3.up * mouseX);
    }

    void FijarSensibilidad()
    {
        sensibilidad = datos.sensibilidadMouse;
    }
}
