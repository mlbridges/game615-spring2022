using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource soundEffectsPlayer;
    public AudioClip footsteps;

    // Start is called before the first frame update
    void Start()
    {
        soundEffectsPlayer = GetComponent<AudioSource>();
        //footsteps = GetComponent<AudioClip>();
        instance = GetComponent<SoundManager>();
    }

    public static SoundManager instance;
    public static SoundManager Instance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footsteps()
    {
        soundEffectsPlayer.clip = footsteps;
        soundEffectsPlayer.Play();
    }
}
