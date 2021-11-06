using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controlador;
    public Rigidbody cuerpo;

    public GameObject objeto;

    public float velocidadMovimiento, gravedad, saltoAltura;
    [HideInInspector]
    public float tiempoInmovilizado;
    public DetectarSuelo controlarSuelo;
    private float acido, normal, alturaJugador = 1.7f;
    private Transform controlSuelo;
    public LayerMask sueloFiltro;
    [HideInInspector]
    public GameObject eden;
    public bool estacionario;
    private Vector3 velocidad, movimientoTotal;
    [HideInInspector]
    public bool enSuelo, poseido, charco, tiempo, frenesi, oportunidad, inmovilizado;

    public Vector3 escalerasVector, escalera;
    private RaycastHit limiteEscalera;

    private bool OnSlope()
    {
        LayerMask mascara = 1 << 6;


        bool revision = Physics.Raycast(transform.position, Vector3.down, out limiteEscalera, alturaJugador / 2 + 1f, mascara);
        if (revision == true) 
        {
            objeto.transform.position = limiteEscalera.point;
            if (limiteEscalera.normal != Vector3.up)
            {
                escalera = limiteEscalera.normal;
                estacionario = true;
                return true;
            }
            else
            {
                escalera = limiteEscalera.normal;
                estacionario = false;
                return false;
            }
        }
        escalera = limiteEscalera.normal;
        estacionario = false;
        return false;
    }

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
        Vector3 gravedadTotal = new Vector3(0, graviton, 0);
        //movimientoTotal.x = new Vector3(velocidad.x, graviton, velocidad.y);
        movimientoTotal.x = velocidad.x;
        movimientoTotal.z = velocidad.y;
        escalerasVector = Vector3.ProjectOnPlane(movimientoTotal, limiteEscalera.normal);


        if (!inmovilizado)
        {
            if (controlarSuelo.tocado && !OnSlope())
            {
                cuerpo.velocity = movimientoTotal;
            }
            else if (controlarSuelo.tocado && OnSlope())
            {
                cuerpo.velocity = escalerasVector;
            }
            else if (!controlarSuelo.tocado)
            {
                cuerpo.velocity = movimientoTotal + gravedadTotal;
            }
            if (Input.GetKeyDown(KeyCode.Space) && controlarSuelo.tocado)
            {
                cuerpo.AddForce(new Vector3(0, saltoAltura * 10f * -2f * gravedad));
            }

        }
        else
        {
            cuerpo.velocity = gravedadTotal;
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
