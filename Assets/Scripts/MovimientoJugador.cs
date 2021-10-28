using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controlador;
    public Rigidbody cuerpo;

    public float velocidadMovimiento, gravedad, saltoAltura;
    [HideInInspector]
    public float tiempoInmovilizado;
    public DetectarSuelo controlarSuelo;
    private float acido, normal;
    private Transform controlSuelo;
    public LayerMask sueloFiltro;
    [HideInInspector]
    public GameObject eden;
    private Vector3 velocidad;
    [HideInInspector]
    public bool enSuelo, poseido, charco, tiempo, frenesi, oportunidad, inmovilizado;
    void Start()
    {
        inmovilizado = false;
        poseido = false;
        gameObject.transform.parent = null;
        acido = velocidadMovimiento / 2;
        normal = velocidadMovimiento;
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
        Vector2 velocidad = (xMov + zMov).normalized * velocidadMovimiento;

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
        if (charco)
        {
            velocidadMovimiento = acido;
        }
        else
        {
            velocidadMovimiento = normal;
        }
        if (inmovilizado)
        {
            tiempoInmovilizado -= Time.deltaTime;
            if (tiempoInmovilizado <= 0)
            {
                inmovilizado = false;
                tiempoInmovilizado = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharcoAcido")
        {
            charco = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CharcoAcido")
        {
            charco = false;
        }
    }
}
