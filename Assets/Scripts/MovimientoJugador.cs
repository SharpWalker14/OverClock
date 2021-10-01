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
    public GameObject colisionador;
    public DetectarSuelo controlarSuelo;
    public Vector3 ver;
    public Transform controlSuelo;
    public float distanciaSuelo = 0.4f;
    public LayerMask sueloFiltro;

    public Vector3 velocidad;
    public bool enSuelo;

    public bool inmovilizado = false;

    void Start()
    {
        gameObject.transform.parent = null;

    }

    void Update()
    {
        //MovimientoControl();
        MovimientoCuerpo();
    }
    void MovimientoControl()
    {
        colisionador.transform.position = transform.position;
        //Comprobar si estás en el suelo
        //enSuelo = Physics.CheckSphere(controlSuelo.position, distanciaSuelo, sueloFiltro);
        
        if (controlarSuelo.tocado && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movimiento = transform.right * x + transform.forward * z;
        if(!inmovilizado)
        {
            controlador.Move(movimiento * velocidadMovimiento * Time.deltaTime);

            if (Input.GetButton("Jump") && controlarSuelo.tocado)
            {
                velocidad.y = Mathf.Sqrt(saltoAltura * -2f * gravedad);
            }
        }
        
        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);
    }
    void MovimientoCuerpo()
    {
        //Comprobar si estás en el suelo
        //enSuelo = Physics.CheckSphere(controlSuelo.position, distanciaSuelo, sueloFiltro);



        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);
        Vector2 velocidad = (xMov + zMov).normalized * velocidadMovimiento * 100 * Time.deltaTime;
        /*if (controlarSuelo.tocado && cuerpo.velocity.y < 0)
        {
            cuerpo.velocity = new Vector3(cuerpo.velocity.x, -2f, cuerpo.velocity.z);
        }*/
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
}
