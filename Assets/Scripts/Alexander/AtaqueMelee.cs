using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    float velocidad = 30; //velocidad de estela
    public bool ouch; //comprobar la estela
    public int usos; //cantidad de usos

    TrailRenderer estela;
    public GameObject golpeArma, areaAtaque, pos1, pos2;

    public GameObject palo1, palo2, palo3;

    void Start()
    {
        estela = golpeArma.GetComponent<TrailRenderer>();
        estela.enabled = false;
        areaAtaque.SetActive(false);
    }

    void Update()
    {
        Golpe();

        MostrarUsos();
    }
    void Golpe()
    {
        float ritmoGolpe = velocidad * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1) && usos > 0 && ouch == false)
        {
            usos--;
            ouch = true;
            StartCoroutine(Golpeando());
            estela.enabled = true;

        }
        if (ouch)
        {
            golpeArma.transform.localPosition = Vector3.MoveTowards(golpeArma.transform.localPosition, pos2.transform.localPosition, ritmoGolpe);
        }
        if (golpeArma.transform.localPosition == pos2.transform.localPosition)
        {
            StopCoroutine(Golpeando());
            golpeArma.transform.localPosition = pos1.transform.localPosition;
            ouch = false;
            estela.enabled = false;
        }
    }
    IEnumerator Golpeando()
    {
        areaAtaque.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        areaAtaque.SetActive(false);
    }
    void MostrarUsos()
    {
        if (usos >= 1)
        {
            palo1.SetActive(true);
        }
        else
        {
            palo1.SetActive(false);
        }
        if (usos >= 2)
        {
            palo2.SetActive(true);
        }
        else
        {
            palo2.SetActive(false);
        }
        if (usos == 3)
        {
            palo3.SetActive(true);
        }
        else
        {
            palo3.SetActive(false);
        }
    }
}
