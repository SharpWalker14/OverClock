using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion : MonoBehaviour
{
    [SerializeField]
    float param = 0.5f;
    Material material;
    // Start is called before the first frame update
    void Awake()
    {
        material = new Material(Shader.Find("Zombos/Shader"));
    }

    // Update is called once per frame
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_param", param);
        Graphics.Blit(source, destination, material);
    }
}
