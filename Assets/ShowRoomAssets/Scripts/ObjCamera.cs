using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCamera : SampleCamera
{
    public bool autoMode;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //objMng = manager.GetComponent<ObjManagement>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (objMng.actualObj)
        {
            target = objMng.actualObj;
        }

        if (autoMode == false)
        {
            Zoom2();
            RoteAround();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            ConsRotate();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
