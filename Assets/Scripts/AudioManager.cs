using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public IDictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>();
    private static AudioManager instance = null;
    void Awake() 
    {
         if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }

        // keep playing background music even when scenes are switched
        DontDestroyOnLoad(this.gameObject);

        foreach (Sound sound in sounds) {
            soundsDictionary.Add(sound.name, sound);

            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = false;
        }
    }

    public void Play(string name, bool loop = true)
    {
        Sound sound = soundsDictionary[name];
        sound.source.Play();
        sound.source.loop = loop;
    }

    public void Stop(string name)
    {
        Sound sound = soundsDictionary[name];
        sound.source.Stop();
    }

    public bool isPlaying(string name) {
        Sound sound = soundsDictionary[name];
        return sound.source.isPlaying;
    }
}
