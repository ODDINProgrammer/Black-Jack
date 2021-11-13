using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource card;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource lose;
    [SerializeField] private AudioSource draw;
    [Header("Mixer")]
    [SerializeField] private AudioMixerGroup master;
    [SerializeField] private AudioMixerGroup music;

    internal void PlayCardSound()
    {
        card.Play();
    }

    internal void PlayWin()
    {
        win.Play();
    }

    internal void PlayLose()
    {
        lose.Play();
    }

    internal void PlayDraw()
    {
        draw.Play();
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
