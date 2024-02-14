using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixerGroup mixerGroup; // Reference to the Audio Mixer Group to control
    public Slider slider; // Reference to the Slider UI element

    void Start()
    {
       
        if (slider == null)
        {
            Debug.LogError("VolumeSlider script attached to a GameObject without a Slider component.");
            return;
        }

        // Add listener to the slider's value change event
        slider.onValueChanged.AddListener(delegate { SetVolume(); });

        // Initialize slider value to current volume level
        float currentVolume = GetVolume();
        slider.value = currentVolume;
    }

    // Method to set the volume of the Audio Mixer Group based on the slider's value
    public void SetVolume()
    {
        float volume = slider.value;
        mixerGroup.audioMixer.SetFloat(mixerGroup.name + "Volume", volume);
    }

    // Method to get the current volume level of the Audio Mixer Group
    public float GetVolume()
    {
        float volume;
        mixerGroup.audioMixer.GetFloat(mixerGroup.name + "Volume", out volume);
        return volume;
    }
}
