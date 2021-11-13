using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource card;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioMixerGroup master;
    [SerializeField] private AudioMixerGroup music;

    internal void PlayCardSound()
    {
        card.Play();
    }

    public void ToggleSFX(bool enabled)
    {
        if (enabled)
            master.audioMixer.SetFloat("Master", 0);
        else
            master.audioMixer.SetFloat("Master", -80);
    }

    public void ChangeVolume(float volume)
    {
        master.audioMixer.SetFloat("Music", Mathf.Lerp(-80, -15, volume));
    }
}
