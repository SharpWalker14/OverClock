using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaHueco : MonoBehaviour
{
    public bool visto;
    public GameObject[] lugares;
    public GameObject enemigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameVisible()
    {
        visto = true;
    }

    void OnBecameInvisible()
    {
        visto = false;
    }

    public void Invocacion()
    {
        for(int i=0; i <= lugares.Length; i++)
        {
            enemigo.transform.position = lugares[i].transform.position;
            enemigo.GetComponent<MovimientoEnemigo>().tranquilo = false;
            enemigo.GetComponent<ValorTiempoEnemigo>().estadoHorda = true;
            Instantiate(enemigo);
            enemigo.GetComponent<MovimientoEnemigo>().tranquilo = true;
            enemigo.GetComponent<ValorTiempoEnemigo>().estadoHorda = false;
        }
    }
}
