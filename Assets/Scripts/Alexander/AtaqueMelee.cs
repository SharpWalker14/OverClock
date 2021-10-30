using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{

    float velocidad = 30;
    public bool ouch; //comprobar la estela
    public int usos;

    TrailRenderer estela;

    public GameObject golpeArma;
    public GameObject areaAtaque;
    public GameObject pos1;
    public GameObject pos2;
    void Start()
    {
        estela = golpeArma.GetComponent<TrailRenderer>();
        estela.enabled = false;
        areaAtaque.SetActive(false);
    }

    void Update()
    {
        Golpe();
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
}
