using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sonido
{
    public string nombre;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volumen;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float dimensiones;

    public bool loop;

    [HideInInspector]
    public AudioSource source;


}
