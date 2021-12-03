using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionEnemigos : MonoBehaviour
{
    public Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animacion.SetBool("Atraer", true);
        }
    }
}
