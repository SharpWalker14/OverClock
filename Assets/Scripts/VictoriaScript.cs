using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoriaScript : MonoBehaviour
{
    public GameObject victoriaMenú, victoriaNoFinal, victoriaFinal;

    private void Start()
    {
        victoriaMenú.SetActive(false);
        victoriaFinal.SetActive(false);
        victoriaNoFinal.SetActive(false);
    }
}
