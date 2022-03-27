using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortinaHumo : MonoBehaviour
{
    private float tiempo;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        Destroy(explosion, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }

    void Temporizador()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 10f)
        {
            Destroy(gameObject);
        }
    }
}
