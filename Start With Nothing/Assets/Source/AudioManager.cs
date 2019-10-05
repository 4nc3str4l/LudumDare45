using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource m_AudioSource;
    private float m_MasterVolume = 1;

    private void Awake()
    {
        Instance = this;
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundRandomizePitch(AudioClip _clip, float _volume)
    {
        float lastPitch = m_AudioSource.pitch;
        m_AudioSource.pitch = Random.Range(0, 1);
        m_AudioSource.PlayOneShot(_clip, _volume * m_MasterVolume);
        m_AudioSource.pitch = lastPitch;
    }
}
