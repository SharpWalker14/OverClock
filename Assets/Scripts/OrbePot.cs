using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbePot : MonoBehaviour
{
    public enum Potenciador { tiempo, frenesi, oportunidad };
    public Potenciador tipoPotenciador;

    public void Asignacion(int numero)
    {
        switch (numero)
        {
            case 1:
                tipoPotenciador = Potenciador.tiempo;
                break;
            case 2:
                tipoPotenciador = Potenciador.frenesi;
                break;
            case 3:
                tipoPotenciador = Potenciador.oportunidad;
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (tipoPotenciador)
            {
                case Potenciador.tiempo:
                    other.GetComponent<TiempoJugador>().Paciente();
                    other.GetComponent<FeedbackDaño>().FeedbackPotencia(1);
                    Debug.Log("A");
                    break;
                case Potenciador.frenesi:
                    other.GetComponent<TiempoJugador>().Frenetico();
                    other.GetComponent<FeedbackDaño>().FeedbackPotencia(2);
                    Debug.Log("A");
                    break;
                case Potenciador.oportunidad:
                    other.GetComponent<TiempoJugador>().Oportuno();
                    other.GetComponent<FeedbackDaño>().FeedbackPotencia(3);
                    Debug.Log("A");
                    break;
            }
            Destroy(gameObject);
        }
    }
}
