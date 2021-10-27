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

}
