using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModeMng : MonoBehaviour
{
    public bool activeView;
    public GameObject dsctObj;
    public GameObject objCam;

    public KeyCode tabKey;
    // Start is called before the first frame update
    void Start()
    {
        activeView = true;
    }

    // Update is called once per frame
    void Update()
    {
        TabDetect();
    }

    public void Visualizer()
    {
        if (activeView == true)
        {
            dsctObj.SetActive(true);
            objCam.GetComponent<ObjCamera>().autoMode = true;
        }
        else
        {
            dsctObj.SetActive(false);
            objCam.GetComponent<ObjCamera>().autoMode = false;
        }
    }

    public void TabDetect()
    {
        if (Input.GetKeyDown(tabKey))
        {
            if(activeView == true)
            {
                activeView = false;
            }
            else
            {
                activeView = true;
            }
            Visualizer();
        }
    }
}
