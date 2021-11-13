using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTeclas : MonoBehaviour
{
    private int contador;
    public Text texto;
    public GameObject textoObj;
    private float tiempo;
    private bool temporizado;
    // Start is called before the first frame update
    void Start()
    {
        temporizado = false;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }

    public void ConteoTutorial()
    {
        switch (contador)
        {
            case 0:
                textoObj.SetActive(true);
                texto.text = "Presiona WASD para moverte y usa el Mouse para mirar hacia los lados";
                break;
            case 1:
                textoObj.SetActive(true);
                texto.text = "Presiona Space para saltar";
                break;
            case 2:
                textoObj.SetActive(true);
                texto.text = "Presiona click izquierdo para disparar";
                break;
        }
        tiempo = 10;
        temporizado = true;
        contador++;
    }
    
    void Temporizador()
    {
        if (temporizado)
        {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                tiempo = 0;
                textoObj.SetActive(false);
                temporizado = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TutorialTeclas")
        {
            ConteoTutorial();
        }
    }
}
