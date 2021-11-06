using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humo : MonoBehaviour
{
    public bool tocado;
    // Start is called before the first frame update
    void Start()
    {
        tocado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && tocado == false)
        {
            other.GetComponent<FeedbackDaño>().humo = true;
        }
    }
}
