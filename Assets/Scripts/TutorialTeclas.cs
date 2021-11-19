using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTeclas : MonoBehaviour
{
    private int contador;
    public GameObject controlesObj, saltoObj, disparoObj;
    public GameObject puntero;
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
                controlesObj.SetActive(true);
                saltoObj.SetActive(false);
                disparoObj.SetActive(false);
                //"Presiona W, A, S y D para moverte y usa el Mouse para mirar hacia los lados"
                break;
            case 1:
                saltoObj.SetActive(true);
                controlesObj.SetActive(false);
                disparoObj.SetActive(false);
                //"Presiona Space para saltar"
                break;
            case 2:
                disparoObj.SetActive(true);
                controlesObj.SetActive(false);
                saltoObj.SetActive(false);

                puntero.SetActive(true);
                //"Presiona click izquierdo para disparar"
                break;
        }
        tiempo = 5;
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
                controlesObj.SetActive(false);
                saltoObj.SetActive(false);
                disparoObj.SetActive(false);
                temporizado = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TutorialTeclas")
        {
            ConteoTutorial();
            other.gameObject.SetActive(false);
        }
    }
}
