using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : MonoBehaviour
{
    public int perdigonContador;
    public float anguloPropagacion;
    public float cartuchoDispVelocidad = 1;
    public float espera;
    private float esperaTiempo = 100;
    public GameObject cartucho;
    public Transform cañon;
    List<Quaternion> perdigones;

    // Start is called before the first frame update
    void Awake()
    {
        perdigones = new List<Quaternion>(perdigonContador);

        for (int i = 0; i < perdigonContador; i++)
        {
            perdigones.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && esperaTiempo >= espera)
        {
            for (int i = 0; i < perdigonContador; i++)
            {
                perdigones[i] = Random.rotation;
                GameObject c = Instantiate(cartucho, cañon.position, cañon.rotation);
                Destroy(c, 2);
                c.transform.rotation = Quaternion.RotateTowards(c.transform.rotation, perdigones[i], anguloPropagacion);
                c.GetComponent<Rigidbody>().AddForce(-c.transform.right * cartuchoDispVelocidad);
            }
            esperaTiempo = 0;
        }
        else if (esperaTiempo >= 0 && esperaTiempo <= espera) 
        {
            esperaTiempo += 1 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
