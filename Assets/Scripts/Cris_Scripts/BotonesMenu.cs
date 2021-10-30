using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesMenu : MonoBehaviour
{
    public GameObject IntroCam;
    public GameObject MenuCam;
    public GameObject CreditosCam;

    public Canvas IntroCanvas;
    public Canvas MenuCanvas;
    public Canvas CreditosCanvas;

    public void IrMenuPrincipal()
    {
        IntroCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        MenuCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 1;
        CreditosCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;

        IntroCanvas.enabled = false;
        MenuCanvas.enabled = true;
        CreditosCanvas.enabled = false;
    }

    public void IrCreditos()
    {
        IntroCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        MenuCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        CreditosCam.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 1;

        IntroCanvas.enabled = false;
        MenuCanvas.enabled = false;
        CreditosCanvas.enabled = true;
    }
}
