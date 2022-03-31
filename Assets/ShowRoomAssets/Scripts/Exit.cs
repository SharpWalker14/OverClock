using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public KeyCode exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(exit))
        {
            //Borrar esto cuando hagamos el refactorizado :P
            SceneManager.LoadScene("MenúConjunto");
           
            //Application.Quit();
        }
    }
}
