using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    private void Start()
    {
        float value;
        audioMixer.GetFloat("volume", out value);
        slider.value = value;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
