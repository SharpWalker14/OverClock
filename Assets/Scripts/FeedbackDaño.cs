using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackDaño : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject feedbackDaño;
    private bool filtrado;
    public Color filtro;
    public Color sinFiltro;
    public float tiempoFiltro;
    private float tiempo;

    void Start()
    {
        filtrado = false;
        tiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CambioColor();
    }

    public void Inicia()
    {
        tiempo = 0;
        filtrado = true;
    }

    void CambioColor()
    {
        if (filtrado)
        {
            tiempo += Time.deltaTime;
            feedbackDaño.GetComponent<Image>().color = filtro;
            if (tiempo >= tiempoFiltro)
            {
                filtrado = false;
                feedbackDaño.GetComponent<Image>().color = sinFiltro;
            }
        }
        else
        {
            feedbackDaño.GetComponent<Image>().color = sinFiltro;
        }
    }
}
