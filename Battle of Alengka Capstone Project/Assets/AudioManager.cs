using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [Header("----- AudioClip -----")]
    public AudioClip background;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip afterJump;
    public AudioClip panah;
    public AudioClip enemy;
    public AudioClip miniBoss;
    public AudioClip miniBossDie;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

}
