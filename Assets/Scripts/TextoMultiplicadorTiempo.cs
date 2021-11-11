using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoMultiplicadorTiempo : MonoBehaviour
{
    public float duración;
    void Start()
    {
        Destroy(gameObject, duración);
    }
}
