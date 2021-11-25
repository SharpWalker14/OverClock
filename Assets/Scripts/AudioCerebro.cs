using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioCerebro : MonoBehaviour
{
    public Sonido[] sonidos;

    public void Awake()
    {
        foreach (Sonido s in sonidos)
        {
            if (s.existe == false)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volumen;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.spatialBlend = s.dimensiones;
                s.source.playOnAwake = s.playOnAwake;
            }
            else
            {
                s.source = s.ubicacion.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volumen;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.spatialBlend = s.dimensiones;
                s.source.playOnAwake = s.playOnAwake;
            }
        
        }
    }

    public void Play(string nombre)
    {
        Sonido s = Array.Find(sonidos, sound => sound.nombre == nombre);
        s.source.Play();
    }
}
