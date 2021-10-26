using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscopetaRaycast : MonoBehaviour
{
    private RaycastHit golpe;
    private Ray linea;
    Transform camara;
    public float rangoDisparo;
    public GameObject impactoBala, laser, camaraRotacion;
    public Transform cañon;
    public float espera;
    public int daño;
    public int disparos;
    public float dispersionBalas;
    private float esperaTiempo = 100;
    public float duracionLaser = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        camara = camaraRotacion.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Disparo();
    }
    void Disparo()
    {
        if (Input.GetMouseButtonDown(0) && esperaTiempo >= espera && Time.timeScale != 0f)
        {
            for (int i = 0; i < disparos; i++)
            {

                if (Physics.Raycast(camara.position, DireccionDeBalas(), out golpe, rangoDisparo, ~(1 << 9)))
                {
                    if (golpe.collider.GetComponent<ValorSalud>() != null)
                    {
                        golpe.collider.GetComponent<ValorSalud>().CambioDeVida(-daño);
                    }

                    GameObject efectoDeBala = Instantiate(impactoBala, golpe.point, Quaternion.identity) as GameObject;
                    Destroy(efectoDeBala, 1);

                    CrearLaser(golpe.point);
                }


                else
                {
                    CrearLaser(camara.position + DireccionDeBalas() * rangoDisparo);
                }
                esperaTiempo = 0;
            }
        }
        else if (esperaTiempo >= 0 && esperaTiempo <= espera)
        {
            esperaTiempo += 1 * Time.deltaTime;
        }
    }

    Vector3 DireccionDeBalas()
    {
        Vector3 Objetivo = camara.position + camara.forward * rangoDisparo;
        Objetivo = new Vector3(
            Objetivo.x + Random.Range(-dispersionBalas, dispersionBalas),
            Objetivo.y + Random.Range(-dispersionBalas, dispersionBalas),
            Objetivo.z + Random.Range(-dispersionBalas, dispersionBalas)
            );

        Vector3 direccion = Objetivo - camara.position;
        return direccion.normalized;
    }

    void CrearLaser(Vector3 fin)
    {
        GameObject nuevoLaser = Instantiate(laser);
        LineRenderer lr = nuevoLaser.GetComponent<LineRenderer>();
        lr.SetPositions(new Vector3[2] { cañon.position, fin });
        StartCoroutine(DesaparecerLaser(lr));
        Destroy(nuevoLaser, 0.3f);
    }

    IEnumerator DesaparecerLaser(LineRenderer lr)
    {
        float tiempoLaser = 1;

        for (int i = 0; 0 < tiempoLaser; i++)
        {
            tiempoLaser -= Time.deltaTime / duracionLaser;
            lr.startColor = new Color(lr.startColor.r, lr.startColor.g, lr.startColor.b, tiempoLaser);
            lr.endColor = new Color(lr.endColor.r, lr.endColor.g, lr.endColor.b, tiempoLaser);
          
            yield return null;
        }
    }
}
