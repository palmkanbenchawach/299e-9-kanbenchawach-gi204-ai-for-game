using UnityEngine;
using System.Collections;

public class MusicFader : MonoBehaviour
{
    public AudioSource musicSource;
    public float fadeTime = 2f;
    public float targetVolume = 0.5f;

    void Start()
    {
        musicSource.volume = 0;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (musicSource.volume < targetVolume)
        {
            musicSource.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}