using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup defaultMixerGroup; // Default Audio Mixer Group for sounds without a specified group
    public AudioMixerGroup[] mixerGroups; // Array of Audio Mixer Groups for different types of sounds
    public Sound[] sounds;

    public AudioMixer audioMixer;

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            // Route AudioSource to the appropriate Audio Mixer Group
            if (s.mixerGroupIndex >= 0 && s.mixerGroupIndex < mixerGroups.Length)
            {
                s.source.outputAudioMixerGroup = mixerGroups[s.mixerGroupIndex];
            }
            else
            {
                // Use default Audio Mixer Group if no specific group is assigned
                s.source.outputAudioMixerGroup = defaultMixerGroup;
            }
        }
    }
    public void Play(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogError("Sound with name '" + name + "' not found. Check spelling.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogError("Sound with name '" + name + "' not found for stopping. Check spelling.");
            return;
        }
        s.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogError("Sound with name '" + name + "' not found for checking if playing. Check spelling.");
            return false;
        }
        return s.source.isPlaying;
    }

    // Helper method to find a sound by name
    private Sound FindSound(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }

    // Method to adjust the volume of a group in the Audio Mixer
    public void SetVolume(string groupName, float volume)
    {
        audioMixer.SetFloat(groupName + "Volume", volume);
    }
}
