using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sonido
{
    public string nombre;

    public AudioClip clip;

    public bool existe;

    public GameObject ubicacion;

    [Range(0f, 1f)]
    public float volumen;
    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float dimensiones;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;


}
