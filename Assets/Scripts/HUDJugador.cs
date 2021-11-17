using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDJugador : MonoBehaviour
{
    public ValorSalud vidaJugador;
    public TiempoJugador tiempoJugador;
    public Image vidaHUD;
    public Image tiempoHUD;
    public Text tiempoTexto;

    public GameObject armaSecundariaHUD;

    private GameObject armaMeleeExistente;
    // Start is called before the first frame update
    void Start()
    {
        if (armaMeleeExistente == null)
        {
            armaSecundariaHUD.SetActive(false);
            armaMeleeExistente = GameObject.FindWithTag("Arma melee");
            if (armaMeleeExistente != null)
            {
                armaSecundariaHUD.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        vidaHUD.fillAmount = vidaJugador.vida / 100;
        tiempoHUD.fillAmount = tiempoJugador.tiempo / tiempoJugador.tiempoMaximo;
        tiempoTexto.text = "" + (tiempoJugador.tiempo - (tiempoJugador.tiempo % 1));
    }
}
