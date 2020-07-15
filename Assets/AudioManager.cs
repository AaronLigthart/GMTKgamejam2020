using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip onBallHitAudio;
    public AudioClip onPinHitAudio;
    public List<AudioClip> onPanchinkoStartAudio;
    public List<AudioClip> onPanchinkoEndAudio;
    public AudioClip PanchinkoMusic;
    public List<AudioClip> MaingameMusic;
    public AudioSource ownAudioSource;

    private void Start()
    {
        ownAudioSource = GetComponent<AudioSource>();
    }

    public void ChangeMusicToPanchinko()
    {
        StartCoroutine(SmoothTransitTo(PanchinkoMusic));
    }

    public void ChangeMusicToMainMusic()
    {
        StartCoroutine(SmoothTransitTo(MaingameMusic[Random.Range(0,MaingameMusic.Count)]));
    }


    public IEnumerator SmoothTransitTo(AudioClip targetClip)
    {
        while (ownAudioSource.volume != 0)
        {
            ownAudioSource.volume -= 0.1f;
            yield return new WaitForEndOfFrame();
        }
        ownAudioSource.clip = targetClip;
        ownAudioSource.Play();
        while (ownAudioSource.volume != 1)
        {
            ownAudioSource.volume += 0.1f;
            yield return new WaitForEndOfFrame();
        }


    }

    public void OnBallHit(Vector3 pos)
    {
        ownAudioSource.PlayOneShot(onBallHitAudio);
        AudioSource.PlayClipAtPoint(onBallHitAudio, pos);
    }

    public void OnPinHit(Vector3 pos)
    {
        ownAudioSource.PlayOneShot(onPinHitAudio);
        AudioSource.PlayClipAtPoint(onPinHitAudio, pos);

    }

    public void OnPanchinkoStart(Vector3 pos)
    {
        ownAudioSource.PlayOneShot(onPanchinkoStartAudio[Random.Range(0, onPanchinkoStartAudio.Count)]);
        AudioSource.PlayClipAtPoint(onPanchinkoStartAudio[Random.Range(0,onPanchinkoStartAudio.Count)], pos);
    }
    public void OnPanchinkoEnd(Vector3 pos)
    {
        ownAudioSource.PlayOneShot(onPanchinkoEndAudio[Random.Range(0, onPanchinkoEndAudio.Count)]);
        AudioSource.PlayClipAtPoint(onPanchinkoEndAudio[Random.Range(0, onPanchinkoEndAudio.Count)], pos);
    }
}
