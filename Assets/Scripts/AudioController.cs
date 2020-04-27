using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource backgroudSound;
    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(this);

        PlayBackgroundSound();
    }

    public void PlayBackgroundSound()
    {
        backgroudSound.Play();
    }

    public void PlayWinSound()
    {
        winSound.Play();
    }

    public void PlayLoseSound()
    {
        loseSound.Play();
    }
}
