using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text viewText;
    public Text objText;

    private ViewModeMng viewMng;
    private ObjManagement objMng;
    // Start is called before the first frame update
    void Start()
    {
        viewMng = gameObject.GetComponent<ViewModeMng>();
        objMng = gameObject.GetComponent<ObjManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjText();
        ViewText();
    }

    void ObjText()
    {
        objText.text = objMng.actualObj.name;
    }

    void ViewText()
    {
        if (viewMng.activeView == true)
        {
            viewText.text = "AutoMove Mode";
        }
        else
        {
            viewText.text = "FreeZoom Mode";
        }
    }
}
