using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fades : MonoBehaviour
{
    public Image fadeImage;

    public GameObject thisGame;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(1.0f);

        
    }

    void Update()
    {
        FadeIn();
    }
    

    // Update is called once per frame
    void FadeIn()
    {
        fadeImage.CrossFadeAlpha(0, 2, false);

        timer += Time.deltaTime;
        if(timer >= 2)
        {
            thisGame.SetActive(false);
        }
        
    }
}
