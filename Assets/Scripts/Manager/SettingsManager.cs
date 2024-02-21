using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    public AudioMixer AudioMixer;
    [SerializeField]
    public Slider AudioSlider;
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        // AudioMixer.SetFloat("Volume", volume);
    }
}
