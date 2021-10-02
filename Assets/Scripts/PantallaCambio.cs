using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaCambio : MonoBehaviour
{
   private bool pantallaCompleta=true;

   public void Cambiador()
   {
      if(pantallaCompleta)
      {
      Screen.fullScreenMode = FullScreenMode.Windowed;
      }
      else
      { 
      Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
      }
   }

}
