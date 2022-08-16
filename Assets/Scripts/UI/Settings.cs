using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _volume;

    private void OnEnable()
    {
        AudioListener.volume = _volume.value;
        _volume.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnDisable()
    {
        _volume.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float newValue)
    {
        AudioListener.volume = newValue;
    }
}
