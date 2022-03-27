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
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        objetivo =GameObject.FindGameObjectWithTag("Datos");
        if (objetivo == null)
        {
            Instantiate(noDestruible);
        }
    }

}
