using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip stepSound;
    static AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        stepSound = Resources.Load<AudioClip>("Sounds/step");
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "step":
                src.PlayOneShot(stepSound);
                break;

        }            
    }
}
