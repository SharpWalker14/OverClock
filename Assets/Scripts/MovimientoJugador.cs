using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controlador;
    public Rigidbody cuerpo;

    public float velocidadMovimiento = 10f;
    public float gravedad = -15f;
    public float saltoAltura = 3f;
    public DetectarSuelo controlarSuelo;
    private Transform controlSuelo;
    public float distanciaSuelo = 0.4f;
    public LayerMask sueloFiltro;
    [HideInInspector]
    public GameObject eden;
    private Vector3 velocidad;
    public bool enSuelo, poseido;

    public bool inmovilizado = false;

    void Start()
    {
        poseido = false;
        gameObject.transform.parent = null;

    }

    void Update()
    {
        // Por si el edén lo atrapa
        if (poseido)
        {
            Posesion();
        }
        else
        {
            MovimientoCuerpo();
        }
        Condicion();
    }

    void MovimientoCuerpo()
    {
        //Comprobar si estás en el suelo

        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);
        Vector2 velocidad = (xMov + zMov).normalized * velocidadMovimiento * 100 * Time.deltaTime;

        float graviton = cuerpo.velocity.y + gravedad * Time.deltaTime;
        if (!inmovilizado)
        {
            cuerpo.velocity = new Vector3(velocidad.x, graviton, velocidad.y);
            if (Input.GetKeyDown(KeyCode.Space) && controlarSuelo.tocado)
            {
                cuerpo.AddForce(new Vector3(0, saltoAltura * 10f * -2f * gravedad));
            }
        }
        else
        {
            cuerpo.velocity = new Vector3(0, graviton, 0);
        }
    }

    void Posesion()
    {
        if (eden != null)
        {
            Vector3 posesor = (eden.transform.position - transform.position).normalized;
            cuerpo.velocity = posesor * 5;
        }
    }
    void Condicion()
    {
        if (eden == null)
        {
            poseido = false;
        }
        else
        {
            poseido = true;
        }
    }
}
