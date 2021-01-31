using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private string[] playingQueue;
    public static AudioManager instance;
    private int index;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
		{
            instance = this;
		} else
		{
            Destroy(gameObject);
            return;
		}

        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
		{
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
		}

        playingQueue = new string[9];
    }

    public IEnumerator Next(float f)
	{
        
		while (f > 0)
		{
            f -= Time.deltaTime;
            Play(playingQueue[++index]);
            yield return new WaitForSeconds(f);
        }
    }

	public void Play(string name)
	{
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null)
		{
            Debug.LogWarning("No se encontro el tema " + name);
            return;
		}
        sound.audioSource.Play();
        if (playingQueue[index + 1] != null)
            StartCoroutine(Next(sound.audioClip.length));
	}

    public void Play(string[] names)
	{
        index = 0;
        for (int i = 0; i < names.Length; i++)
		{
            playingQueue[i] = names[i];
        }
        Play(playingQueue[index]);
    }
}
