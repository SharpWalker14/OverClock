using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controlador;
    public Rigidbody cuerpo;

    public float velocidadMovimiento, gravedad, saltoAltura;
    [HideInInspector]
    public float acido, normal, tiempoInmovilizado;
    public DetectarSuelo controlarSuelo, controlarSalto;
    private float alturaJugador = 1.7f, tiempoSalto, tiempoEmpuje;
    private Transform controlSuelo;
    public LayerMask sueloFiltro;
    [HideInInspector]
    public GameObject eden;
    public bool estacionario, saltando;
    private Vector3 velocidad, movimientoTotal;
    [HideInInspector]
    public bool enSuelo, poseido, charco, tiempo, frenesi, oportunidad, inmovilizado, moviendo, empujado;
    public GameObject pies;

    public Vector3 escalerasVector, escalera;
    private RaycastHit limiteEscalera;
    private Vector2 cero = new Vector2(0, 0);

    private int movPal;

    private bool OnSlope()
    {
        movPal = 0;
        LayerMask mascara = 1 << 6;


        bool revision = Physics.Raycast(transform.position, Vector3.down, out limiteEscalera, alturaJugador / 2 + 1f, mascara);
        if (revision == true) 
        {
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
        empujado = false;
        saltando = false;
        inmovilizado = false;
        poseido = false;
        gameObject.transform.parent = null;
        acido = velocidadMovimiento / 2;
        normal = velocidadMovimiento;
        tiempoSalto = 0;
        
    }

    void Update()
    {
        // Por si el edén lo atrapa
        if (poseido)
        {
            Posesion();
        }
        else if(empujado)
        {
            Empujon();
        }
        else
        {
            MovimientoCuerpo();
        }
        Condicion();
        Estados();
    }

    void MovimientoCuerpo()
    {
        //Comprobar si estás en el suelo
        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);
        /*int contador = 0;
          if (contador == 0)
          {
              if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
              {
                  FindObjectOfType<AudioCerebro>().Play("Movimiento");
                  contador++;
                  Debug.Log("Suena");
              }
          }
          if (contador == 1)
          {
              Debug.Log("Suma");  
              contador = 0;
          }
        */

        if((xMov != cero ||zMov != cero)&&!inmovilizado)
        {
            moviendo = true;
        }
        else
        {
            moviendo = false;
        }


        Vector2 velocidad = (xMov + zMov).normalized * velocidadMovimiento;
        float graviton = cuerpo.velocity.y + gravedad * Time.deltaTime;
        Vector3 gravedadTotal = new Vector3(0, graviton, 0);
        //movimientoTotal.x = new Vector3(velocidad.x, graviton, velocidad.y);
        movimientoTotal.x = velocidad.x;
        movimientoTotal.z = velocidad.y;
        escalerasVector = Vector3.ProjectOnPlane(movimientoTotal, limiteEscalera.normal);


        if (!inmovilizado && !empujado)
        {
            if (Input.GetKeyDown(KeyCode.Space) && controlarSalto.tocado)
            {
                cuerpo.AddForce(new Vector3(0, saltoAltura * 10f * -2f * gravedad));
                saltando = true;
                tiempoSalto = 0;
            }
            if (saltando)
            {
                tiempoSalto += Time.deltaTime;
                cuerpo.velocity = movimientoTotal + gravedadTotal;
                if (controlarSalto.tocado && tiempoSalto >= 0.1f)
                {
                    saltando = false;
                }
            }
            else
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

            }
        }
        else if (inmovilizado && !empujado)
        {
            cuerpo.velocity = gravedadTotal;
        }
    }

    public void Empuje(Vector3 empujeTotal)
    {
        cuerpo.velocity = empujeTotal * 2;
    }

    void Empujon()
    {
        tiempoEmpuje += Time.deltaTime;
        if (tiempoEmpuje>=0.5f)
        {
            tiempoEmpuje = 0;
            empujado = false;
            inmovilizado = true;
        }
    }

    void Posesion()
    {
        if (eden != null)
        {
            Vector3 posesor = (eden.transform.position - transform.position).normalized;
            cuerpo.velocity = posesor * 5;
            moviendo = false;
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

    void Estados()
    {
        if (moviendo)
        {
            if (saltando == false)
            {
                if (movPal == 0)
                {
                    pies.SetActive(true);
                    movPal++;
                    Debug.Log("Suena");
                }
            }
            else
            {
                pies.SetActive(false);
            }
        }
        else
        {
            pies.SetActive(false);
            movPal = 0;
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
