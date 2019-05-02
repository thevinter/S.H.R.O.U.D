using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip stepSound;
    public static AudioClip gunSound;
    public static AudioClip laserSound;
    public static AudioClip menuSound;
    public static AudioClip pick;
    public static AudioClip rifleSound;
    public static AudioClip endShot;
    static AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        stepSound = Resources.Load<AudioClip>("Sounds/step");
        gunSound = Resources.Load<AudioClip>("Sounds/shotGun");
        rifleSound = Resources.Load<AudioClip>("Sounds/shotRifle");
        laserSound = Resources.Load<AudioClip>("Sounds/laserShot");
        menuSound = Resources.Load<AudioClip>("Sounds/menu");
        pick = Resources.Load<AudioClip>("Sounds/pickup");
        endShot = Resources.Load<AudioClip>("Sounds/endShot");
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetVolume(float f)
    {
        src.volume = f;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "step":
                src.PlayOneShot(stepSound);
                break;
            case "gunSound":
                src.PlayOneShot(gunSound);
                break;
            case "menuSound":
                src.PlayOneShot(menuSound);
                break;
            case "laserSound":
                src.PlayOneShot(laserSound);
                break;
            case "rifleSound":
                src.PlayOneShot(rifleSound);
                break;
            case "pick":
                src.PlayOneShot(pick);
                break;
            case "endShot":
                src.PlayOneShot(endShot);
                break;
        }
    }
}
