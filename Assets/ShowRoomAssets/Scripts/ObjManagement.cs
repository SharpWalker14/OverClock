using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjManagement : MonoBehaviour
{

    public MyArray[] categories;    
    //-------------------------------------------//
    private int _inptPly;
    private int _befInp;
    public KeyCode key_switch;

    public GameObject actualObj;
    public GameObject objSpace;

    private GameObject[] objArray;

    public GameObject cam;
    public Vector3 objOffset;
    public GameObject camSpace;
    public Vector3 spaceOffset;
    // Start is called before the first frame update
    void Start()
    {
        _inptPly = 0;
        _befInp = -1;
        SelectCategory(categories[0].name);
        SetObj();
        SelectCategory("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key_switch))
        {
            Switch();
            Debug.Log(objArray[_inptPly].GetComponent<MeshRenderer>().bounds.size);
        }
    }

    public void SelectCategory(string name)
    {
        MyArray arr = Array.Find(categories, myarray => myarray.name == name);
        if (arr == null)
        {
            Debug.Log("La categoria " + name + " no se ha encontrado");
            return;
            
        }
        camSpace.transform.position = arr.objBase.transform.position + spaceOffset;
        objArray = arr.objList;
        objSpace = arr.objBase;

        _befInp = -1;
        _inptPly = 0;
        SetObj();
        //Debug.Log(arr.objBase);

    }

    public void SelectCategory(GameObject label)
    {
        string name = label.GetComponent<Text>().text;
        SelectCategory(name);
        /*MyArray arr = Array.Find(categories, myarray => myarray.name == name);
        if (arr == null)
        {
            Debug.Log("La categoria " + name + " no se ha encontrado");
            return;

        }
        objArray = arr.objList;
        objSpace = arr.objBase;
        camSpace.transform.position = camSpace.GetComponent<ConstantCamera>().target.transform.position + spaceOffset;
        _befInp = -1;
        _inptPly = 0;
        SetObj();*/
        //Debug.Log(name);
    }


    void SetObj()
    {
        Debug.Log("Player num in array: " + _inptPly + " of: " + objArray.Length);

        for (int i = 0; i < objArray.Length; i++)
        {

            if (objArray[i] == null)
            {
                //return;
            }
            else
            {
                if (i != _inptPly)
                {
                    //Que se quede Uykieto

                }
                else
                {
                    if (cam == null)
                    {
                        Debug.Log(name + ": Please place a Camera on the Inspector");
                        return;
                    }
                    else if (cam.GetComponent<ObjCamera>())
                    {
                        cam.GetComponent<ObjCamera>().target = objArray[i];
                        actualObj = objArray[i];
                        cam.transform.position = new Vector3(
                            cam.GetComponent<ObjCamera>().target.transform.position.x + objArray[i].GetComponent<MeshRenderer>().bounds.size.x + objOffset.x,
                            cam.GetComponent<ObjCamera>().target.transform.position.y + objArray[i].GetComponent<MeshRenderer>().bounds.size.y/2 + objOffset.y,
                            cam.GetComponent<ObjCamera>().target.transform.position.z + objArray[i].GetComponent<MeshRenderer>().bounds.size.z + objOffset.z);
                            /*cam.GetComponent<ObjCamera>().target.transform.position + objOffset;*/
                    }
                    else
                    {
                        Debug.Log(name + ": Please add a SampleCam component on the Inspector");
                        return;
                    }
                }
            }
        }
    }
    public void Switch()
    {

        int tmpUses = 0;
        while (tmpUses <= objArray.Length)
        {
            if (_inptPly < objArray.Length - 1)
            {
                _inptPly++;
                tmpUses++;
            }
            else
            {
                _inptPly = 0;
                tmpUses++;
            }

            if (objArray[_inptPly] != null)
            {
                if (_befInp != _inptPly)
                {
                    SetObj();
                }
                return;
            }
            else
            {
                Debug.Log(name + ": There was some empty CharacterSpaces" + "(" + tmpUses + ")");
            }
        }

    }

}
