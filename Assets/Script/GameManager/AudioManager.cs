using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip shootSound; //Am thanh khi ban
    public AudioClip explosionSound; //Am thanh khi no
    public AudioClip backgroundMusic; //Nhac nen
    private AudioSource audioSource;
    private AudioSource musicSource;
    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>(); // them bien audioSource vao trong Component AudioSource
        musicSource = gameObject.AddComponent<AudioSource>(); // them bien musicSource vao trong Component AudioSource

        musicSource.loop = true;
        PlayBackgroundMusic();
    }
    public void PlayShootSound(){
        PlaySound(shootSound);
    }
    public void PlayExplosionSound(){
        PlaySound(explosionSound);    
    }
    public void PlayBackgroundMusic(){
        if(backgroundMusic != null && !musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }
    private void PlaySound(AudioClip clip){
        if(clip != null){
            audioSource.PlayOneShot(clip);
        }
    }
    public void StopBackgroundMusic(){
        if(musicSource.isPlaying){
            musicSource.Stop();
        }
    }
}
