using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesMenu : MonoBehaviour
{
    public GameObject IntroCam;
    public GameObject MenuCam;
    public GameObject CreditosCam;

    public GameObject IntroCanvas;
    public GameObject MenuCanvas;
    public GameObject CreditosCanvas;

    public void IrMenuPrincipal()
    {
        IntroCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        MenuCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 1;
        CreditosCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        IntroCam.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        StartCoroutine(TransiciónBotones());
    }

    public void IrCreditos()
    {
        IntroCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        MenuCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        CreditosCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 1;
        StartCoroutine(TransiciónBotones());
    }
    IEnumerator TransiciónBotones()
    {
        if (MenuCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority == 1)
        {
            IntroCanvas.SetActive(false);
            CreditosCanvas.SetActive(false);
            yield return new WaitForSeconds(2);
            MenuCanvas.SetActive(true);
            StopCoroutine(TransiciónBotones());
        }
        else if (CreditosCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority == 1)
        {
            IntroCanvas.SetActive(false);
            MenuCanvas.SetActive(false);
            yield return new WaitForSeconds(2);
            CreditosCanvas.SetActive(true);
            StopCoroutine(TransiciónBotones());
        }
    }
}
