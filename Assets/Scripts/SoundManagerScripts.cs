using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScripts : MonoBehaviour
{
    public static AudioClip PlayerWalk;
    public static  AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        PlayerWalk = Resources.Load<AudioClip>("SFXFootstepsLooping_1");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string Enter)
    {
        switch (Enter)
        {
            case "Walk":
                audioSrc.PlayOneShot(PlayerWalk);
                break;

        }
    }
}
