using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    public float tiempoDeDaño;
    public GameObject player;
    public int dañoCharcoAcido;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DañoCharco()
    {
        tiempoDeDaño += 1 * Time.deltaTime;

        if (tiempoDeDaño >= 2f)
        {
            player.GetComponent<ValorSalud>().CambioDeVida(dañoCharcoAcido);

            tiempoDeDaño = 0;
            Destroy(gameObject, 2);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            DañoCharco();
        }
    }
}
