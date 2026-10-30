using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerNoises : MonoBehaviour
{
    [SerializeField] AudioSource soundSource, soundSourceLoop;
    [SerializeField] List<AudioClip> soundList = new List<AudioClip>();


    public void PlayShooting()
    {
        soundSource.clip = soundList[0];
        soundSource.Play();

    }

    public void LoopWalking(bool looping)
    {
        if (looping)
        {
            soundSourceLoop.clip = soundList[1];
            soundSourceLoop.loop = looping;
            soundSourceLoop.Play();
        }
        else
        {
            soundSourceLoop.Pause();
        }
            
    }


    public void PlayOutOfAmmo()
    {
        soundSource.clip = soundList[2];
        soundSource.loop = false;
        soundSource.Play();
    }
}
