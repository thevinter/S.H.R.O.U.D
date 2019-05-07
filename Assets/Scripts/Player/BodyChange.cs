using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BodyChange : MonoBehaviour
{

    public PlayerController pc;
    public string spriteSheetName;
    public string oldSheet;
    public Image sBlind;
    public Image fBlind;

    void LateUpdate()
    {
        var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName);

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        print("The current Sprite is: " + spriteSheetName);
        CheckForChanges();
        NewShit();
    }

    void CheckForChanges()
    {
       
       

        if (PlayerStats.rLeg == false)
        {
            PlayerStats.semiSlow = true;
            pc.setSlow(0.5f);
        }

        if (PlayerStats.lLeg == false && PlayerStats.rLeg == false)
        {
            PlayerStats.fullSlow = true;
            pc.setSlow(0.1f);
        }

        if (PlayerStats.rEar == false)
        {
            PlayerStats.semiDeaf = true;
            SoundManager.SetVolume(.35f);
        }

        if (PlayerStats.rEar == false && PlayerStats.lEar == false)
        {
            PlayerStats.fullDeaf = true;
            SoundManager.SetVolume(0f);
        }

        if (PlayerStats.rArm == false)
        {
            PlayerStats.hasRifle = false;
            PlayerStats.usesRifle = false;
            PlayerStats.oneHanded = true;
        }

        if (PlayerStats.rArm == false && PlayerStats.lArm == false)
        {
            PlayerStats.canShoot = false;
            PlayerStats.hasRifle = false;
            PlayerStats.usesRifle = false;
            PlayerStats.usesPistol = false;
            PlayerStats.hasPistol = false;
        }

        if (PlayerStats.lung == false)
        {
            PlayerStats.fastRad = true;
        }

        if (PlayerStats.kidney == false)
        {
            PlayerStats.fastThirst = true;
        }

        if (PlayerStats.stomach == false)
        {
            PlayerStats.fastHunger = true;
        }

        if (PlayerStats.rEye == false)
        {
            PlayerStats.semiBlind = true;
            sBlind.gameObject.SetActive(true);
        }
        else
        {
            sBlind.gameObject.SetActive(false);
        }

        if (PlayerStats.lEye == false)
        {
            fBlind.gameObject.SetActive(true);
            PlayerStats.fullBlind = true;
        }   
        else
        {
            fBlind.gameObject.SetActive(false);
        }
    }

    void NewShit()
    {
        spriteSheetName = "Base";

        if(!PlayerStats.rEye || !PlayerStats.lEye || PlayerStats.rLeg ||
           !PlayerStats.lLeg || !PlayerStats.rArm || !PlayerStats.rArm)
        spriteSheetName = "No";

        if (!PlayerStats.rLeg)
        {
            spriteSheetName = spriteSheetName + "Leg";
        }

        if (!PlayerStats.lLeg)
        {
            spriteSheetName = spriteSheetName + "s";
        }

        if (!PlayerStats.rArm)
        { 
            print("i have no arm");
            spriteSheetName = spriteSheetName + "Arm";
        }

        if (!PlayerStats.lArm)
        {
            spriteSheetName = spriteSheetName + "s";
        }

        if (!PlayerStats.rEye)
        {
            spriteSheetName = spriteSheetName + "Eye";
        }

        if (!PlayerStats.lEye)
        {
            spriteSheetName = spriteSheetName + "s";
        }

        if (PlayerStats.usesPistol)
        {
            spriteSheetName = spriteSheetName + "Gun";
        }

        if (PlayerStats.usesRifle)
        {
            spriteSheetName = spriteSheetName + "Rifle";
        }

    }
}
