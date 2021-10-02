using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackDaño : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject feedbackDaño;
    public Color filtro;
    public Color sinFiltro;
    public float tiempoFiltro;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Inicia()
    {
        StartCoroutine(CambioColor());
    }

    public IEnumerator CambioColor()
    {
        feedbackDaño.GetComponent<Image>().color = filtro;

        yield return new WaitForSeconds(tiempoFiltro);

        feedbackDaño.GetComponent<Image>().color = sinFiltro;
    }
}
