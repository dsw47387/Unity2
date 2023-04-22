using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string volumeParameter;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private float multiplier = 30f;
    
    private void SetVolume(float sliderValue)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(sliderValue) * multiplier);
    }

    private void Awake()
    {
        slider.onValueChanged.AddListener(SetVolume);
    }
    
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
    }
}
