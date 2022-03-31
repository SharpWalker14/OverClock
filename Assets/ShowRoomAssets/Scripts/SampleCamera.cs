using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCamera : MonoBehaviour
{
    public GameObject manager;
    [HideInInspector]
    public ObjManagement objMng;

    public float zoomSpeed;
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;
    private Camera myCamera;

    public float sensitivity;

    public GameObject target;//the target object

    public float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at


    public Vector3 offset = new Vector3(0, 0, 1);

    public float minZoom = 5f;
    public float maxZoom = 15f;


    private float currentZoom = 10f;
    public Vector3 consDir;
    public virtual void OnEnable()
    {
        objMng = manager.GetComponent<ObjManagement>();
        myCamera = GetComponent<Camera>();
    }
    public virtual void Start()
    {//Set up things on the start method
        /*objMng = manager.GetComponent<ObjManagement>();
        myCamera = GetComponent<Camera>();*/
    }
    void Update()
    {
        //RoteAround();
        //Zoom2();
        //RoteAround();
        //FreeMove();
    }
    private void LateUpdate()
    {
        //camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoom, Time.deltaTime * zoomSpeed);
    }

    public void CamSwitch()
    {

    }

    public void FreeMove()
    {
        var c = Camera.main.transform;
        c.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        c.Rotate(0, 0, -Input.GetAxis("QandE") * 90 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void RoteAround()
    {
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it

        /*var c = Camera.main.transform;
        c.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);*/

        transform.RotateAround(point, new Vector3(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity, 0), 10 * Time.deltaTime * speedMod);
    }

    public void ConsRotate()
    {
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it


        transform.RotateAround(point, consDir, 10 * Time.deltaTime * speedMod);
    }

    public void Zoom()
    {
        /*zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);*/
    }

    public void Zoom2()
    {
        if (myCamera.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                myCamera.orthographicSize += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                myCamera.orthographicSize -= zoomSpeed;
            }
            myCamera.orthographicSize = Mathf.Clamp(myCamera.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                myCamera.fieldOfView += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                myCamera.fieldOfView -= zoomSpeed;
            }
            myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, fovMin, fovMax);
        }
    }
}
