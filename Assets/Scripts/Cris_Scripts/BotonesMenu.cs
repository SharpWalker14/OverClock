using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesMenu : MonoBehaviour
{
    public Animator menuAnim;


    public GameObject IntroCanvas;
    public GameObject MenuCanvas;
    public GameObject CreditosCanvas;

    public void IrMenuPrincipal()
    {
        menuAnim.SetBool("IrMenu", true);
        menuAnim.SetBool("IrCreditos", false);

        IntroCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        CreditosCanvas.SetActive(false);
    }

    public void IrCreditos()
    {

        menuAnim.SetBool("IrMenu", false);
        menuAnim.SetBool("IrCreditos", true);

        IntroCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        CreditosCanvas.SetActive(true);
    }
}
