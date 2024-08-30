using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

    [SerializeField] private AudioClip bgmMusic;
    private AudioManger audioM;
    // Start is called before the first frame update
    void Start()
    {
        audioM = FindObjectOfType<AudioManger>();
        audioM.PlayBGM(bgmMusic);
    }


}
