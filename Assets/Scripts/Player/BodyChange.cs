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
        print("The current weapon is: " + PlayerStats.hasRifle);
        CheckForChanges();
        ChangeSprite();
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

    public void ChangeSprite()
    {
        if (!PlayerStats.usesPistol && !PlayerStats.usesRifle)
        {
            oldSheet = spriteSheetName;
        }

        if (PlayerStats.rEye && PlayerStats.rEye && PlayerStats.rLeg && //Has everything
            PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.rArm)
        {
            spriteSheetName = "Base";
        }

        if (!PlayerStats.rEye && PlayerStats.lEye && PlayerStats.rLeg && //Non ha un occhio destro
            PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoEye";
        }

        if (!PlayerStats.rEye && !PlayerStats.lEye && PlayerStats.rLeg && //Non ha gli occhi
            PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoEyes";
        }

        if (PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && //Non ha la gamba
            PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLeg";
        }

        /*if (PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && //non ha le gambe
            !PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLegs";
        }*/

        if (PlayerStats.rEye && PlayerStats.lEye && PlayerStats.rLeg && //Non ha il braccio
            PlayerStats.lLeg && !PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoArm";

        }

        if (PlayerStats.rEye && PlayerStats.lEye && PlayerStats.rLeg && //Non ha le braccia
            PlayerStats.lLeg && !PlayerStats.rArm && !PlayerStats.lArm)
        {
            spriteSheetName = "NoArms";

        }

        if (!PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && //Non ha l'occhio e la gamba
            PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoEye";

        }

      /*  if (!PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && //Non ha l'occhio e non ha le gambe
            !PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
        } */

        if (!PlayerStats.rEye && PlayerStats.lEye && PlayerStats.rLeg && //non ha un occhio e non ha la mano 
            PlayerStats.lLeg && !PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoArmNoEye";
        }

        if (!PlayerStats.rEye && PlayerStats.lEye && PlayerStats.rLeg && //Non ha un occhio e non ha le mani
            PlayerStats.lLeg && !PlayerStats.rArm && !PlayerStats.lArm)
        {
            spriteSheetName = "NoArmsNoEye";

        }

        if (!PlayerStats.rEye && !PlayerStats.lEye && !PlayerStats.rLeg && //Non ha gli occhi e non ha la gamba
            PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoEyes";

        }

        if (!PlayerStats.rEye && !PlayerStats.lEye && !PlayerStats.rLeg && //Non ha gli occhi e non ha le gambe
            !PlayerStats.lLeg && PlayerStats.rArm && PlayerStats.lArm)
        {
        }

        if (!PlayerStats.rEye && !PlayerStats.lEye && PlayerStats.rLeg && //Non ha gli occhi e non ha la mano
            PlayerStats.lLeg && !PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoArmNoEyes";

        }
        if (!PlayerStats.rEye && !PlayerStats.lEye && PlayerStats.rLeg && //Non ha gli occhi e non ha le mani
            PlayerStats.lLeg && !PlayerStats.rArm && !PlayerStats.lArm)
        {
            spriteSheetName = "NoArmsNoEyes";

        }
        if (!PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && // Non ha l'occhio, non ha la mano, e non ha la gamba
           PlayerStats.lLeg && !PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoArmNoEye";
        }
        if (!PlayerStats.rEye && !PlayerStats.lEye && !PlayerStats.rLeg && //Non hagli occhi, non ha la mano e non ha la gamba
           PlayerStats.lLeg && !PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoArmNoEyes";

        }
        if (!PlayerStats.rEye && !PlayerStats.lEye && !PlayerStats.rLeg && //Senza occhi, senza mani, senza gamba
           PlayerStats.lLeg && !PlayerStats.rArm && !PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoArmsNoEyes";

        }

        if (!PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && //senza mani, senza gamba
           PlayerStats.lLeg && !PlayerStats.rArm && !PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoArms";

        }
        if (!PlayerStats.rEye && PlayerStats.lEye && !PlayerStats.rLeg && //senza mano, senza gamba
          PlayerStats.lLeg && !PlayerStats.rArm && PlayerStats.lArm)
        {
            spriteSheetName = "NoLegNoArm";

        }

        if (PlayerStats.usesPistol)
        {
            spriteSheetName = oldSheet;
            spriteSheetName = spriteSheetName + "Gun";
            print("PistolSprite" + spriteSheetName);
        }

        if (PlayerStats.usesRifle)
        {
            spriteSheetName = oldSheet;
            spriteSheetName = spriteSheetName + "Rifle";
            print("RifleSprite +" + spriteSheetName);
        }
    }
}
