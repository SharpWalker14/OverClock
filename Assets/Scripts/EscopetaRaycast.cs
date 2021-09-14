using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscopetaRaycast : MonoBehaviour
{
    private RaycastHit golpe;
    private Ray linea;
    public GameObject impactoDeBala;
    public float espera;
    private float esperaTiempo = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        linea = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Input.GetButtonDown("Fire1") && esperaTiempo >= espera)
        {
            if (Physics.Raycast(linea, out golpe, Mathf.Infinity))
            {
                GameObject efectoDeBala = Instantiate(impactoDeBala, golpe.point, Quaternion.identity) as GameObject;
                Destroy(efectoDeBala, 1);
            }
            esperaTiempo = 0;
        }
           else if (esperaTiempo >= 0 && esperaTiempo <= espera)
        {
            esperaTiempo += 1 * Time.deltaTime;
        }
    }
}
