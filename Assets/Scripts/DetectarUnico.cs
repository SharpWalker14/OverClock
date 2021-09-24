using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarUnico : MonoBehaviour
{
    public GameObject noDestruible;
    private GameObject objetivo;
    // Start is called before the first frame update
    void Awake()
    {
        objetivo=GameObject.FindGameObjectWithTag("Datos");
        if (objetivo == null)
        {
            Instantiate(noDestruible);
        }
    }

}
