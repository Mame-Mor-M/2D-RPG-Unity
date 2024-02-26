using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip trollDeath;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        trollDeath = Resources.Load<AudioClip>("DeathVoice");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound()
    {
        audioSrc.PlayOneShot(trollDeath);
    }
}
