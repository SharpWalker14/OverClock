using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    [HideInInspector]
    public float sensibilidadMouse, volumen;
    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i < Object.FindObjectsOfType<NoDestruir>().Length; i++)
        {
            if (Object.FindObjectsOfType<NoDestruir>()[i] != this)
            {
                Destroy(gameObject);
            }
        }*/
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
