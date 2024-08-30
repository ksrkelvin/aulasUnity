using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
   public static AudioManger instance;
   [SerializeField] private AudioSource audioSource;

   private void Awake()
   {
       if (instance == null)
       {
           instance = this;
           DontDestroyOnLoad(instance);
       }
       else
       {
           Destroy(gameObject);
       }
   }

   public void PlayBGM(AudioClip audio)
   {
        audioSource.clip = audio;
        audioSource.Play();
   }

}
