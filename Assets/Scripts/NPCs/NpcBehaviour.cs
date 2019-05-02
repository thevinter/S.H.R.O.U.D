using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum State
{
    idle,
    sold,
    over,
    ready,
    bought,
}

public enum NpcType
{
    vendor,
    common,
    seller
}

public enum BodyParts {
    eye, arm, lung, kidney, stomach, leg, ear
}


public class NpcBehaviour : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI text;
    public string dialogue;
    public bool isActive;
    public DropType[] type = new DropType[10];
    public int quantity;
    private Drop[] drop = new Drop[10];
    private Drop currentDrop;
    public BodyParts buyingPart;
    private string partName;
    public NpcType npcType;
    public State npcState;
    public bool variable;
    public int price;
    private int sel;
    public TextMeshProUGUI buy;
    private string buydialogue = "";
    public bool debug;
    private void OnLevelWasLoaded(int level)
    {
        
        for(int i = 0; i < type.Length; i++)
        {
            drop[i] = new Drop(type[i]);
        }
        sel = Random.Range(0, 10);
        currentDrop = drop[sel];
        if (variable && (npcType == NpcType.vendor || npcType == NpcType.common))
        {
            if (Random.Range(0, 2) == 1)
                npcType = NpcType.vendor;
            else
                npcType = NpcType.common;
        }
        if (npcType == NpcType.vendor || npcType == NpcType.seller)
        {
            GenerateDialogue();
        }
        npcState = State.idle;
   
    }

    private void GenerateDialogue()
    {
        string name = currentDrop.dropName;
        int price = currentDrop.dropPrice;
        if (npcType == NpcType.vendor)
        {

            buydialogue = "E - Buy";
            dialogue = "Hey kid, you wanna buy " + name + " for only " + price + "$? It's a deal!\nI have " + quantity + " of them";
        }
        else if (npcType == NpcType.seller)
        {
            buydialogue = "E - Sell";
            dialogue = "I'm interested in your " + buyingPart + "! Can I have one?";
        }
            
    }




    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            print("This state is: " + npcType)
;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
                SoundManager.PlaySound("menuSound");

                if (npcState == State.ready)
                {
                    npcState = State.idle;
                }
            }

            else if(npcState == State.idle)
            {
                dialogueBox.SetActive(true);
                SoundManager.PlaySound("menuSound");
                buy.text = buydialogue;
                text.text = dialogue;
                if((npcType == NpcType.vendor || npcType == NpcType.seller) && npcState != State.sold && npcState != State.bought && npcState != State.over)
                {
                    npcState = State.ready;
                }
            }
            else if(npcState == State.sold)
            {
                dialogueBox.SetActive(true);
                dialogue = "I already sold you everything";
                text.text = dialogue;
                buy.text = buydialogue;
            }
            else if(npcState == State.bought)
            {
                dialogueBox.SetActive(true);
                dialogue = "I can't buy more. I dont want you to die huh!";
                text.text = dialogue;
                buy.text = buydialogue;
            }
            else if(npcState == State.over)
            {
                dialogueBox.SetActive(true);
                text.text = dialogue;
                buy.text = buydialogue;
            }

        }

        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            if(npcState == State.ready)
            {
                if(npcType == NpcType.vendor)
                {
                    Sell();
                }
                else if(npcType == NpcType.seller)
                {
                
                    Buy();
                }
            }
            else if(npcState == State.sold){
                dialogue = "I already sold you everything";
                text.text = dialogue;
                buy.text = buydialogue;
            }
            else if(npcState == State.bought)
            {
                dialogue = "I can't buy more. I dont want you to die huh!";
                text.text = dialogue;
                buy.text = buydialogue;
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = false;
            dialogueBox.SetActive(false);
        }
    }

    private void Thanks()
    {
        text.text = "Thanks for your purchase!";
        npcState = State.sold;
    }

    private void Buy()
    {
        if (CheckIfPresent(buyingPart))
        {
            print("bought");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Donate(buyingPart);
            PlayerStats.addMoney(price);
            npcState = State.bought;
            text.text = "Now me be more human!";
        }
        else
        {
            dialogue = "Hey, I though you had what I wanted...";
            text.text = dialogue;
            npcState = State.over;
        }
    }

    private void Sell()
    {
        if(PlayerStats.getMoney() >= currentDrop.dropPrice * quantity)
        {
            PlayerStats.addMoney(-currentDrop.dropPrice * quantity);
            switch (type[sel])
            {
                case DropType.gun:
                    if (!PlayerStats.hasPistol)
                    {
                        if (PlayerStats.canShoot)
                        {
                            PlayerStats.hasPistol = true;
                            PlayerStats.usesPistol = true;
                            Thanks();
                        }
                        else
                            text.text = "It doesn't look like you can handle that...";
                    }
                    else
                    {
                        text.text = "Hey, you already have a " + currentDrop.dropName;
                    }
                    break;
                case DropType.food:
                    PlayerStats.foodPieces += quantity;
                    Thanks();
                    break;
                case DropType.water:
                    PlayerStats.waterBottles += quantity;
                    Thanks();
                    break;
                case DropType.rifle:
                    if (!PlayerStats.hasRifle)
                    {
                        if (PlayerStats.canShoot)
                        {
                            PlayerStats.hasRifle = true;
                            PlayerStats.usesRifle = true;
                            Thanks();
                        }
                        else
                            text.text = "It doesn't look like you can handle that...";
                    }
                    else
                    {
                        text.text = "Hey, you already have a " + currentDrop.dropName;
                    }
                    break;
                case DropType.medicine:
                    PlayerStats.healthPacks += quantity;
                    Thanks();
                    break;
                case DropType.radaway:
                    PlayerStats.healthPacks += quantity;
                    Thanks();
                    break;
                case DropType.rbullets:
                    PlayerStats.rifleBullets += quantity;
                    Thanks();
                    break;
                case DropType.gbullets:
                    PlayerStats.pistolBullets += quantity;
                    Thanks();
                    break;

            }

        }
        else
        {
            dialogue = "You don't have enough money kiddo";
            text.text = dialogue;
            npcState = State.over;
        }


    }

    private bool CheckIfPresent (BodyParts p)
    {
        switch (p) {        
            case BodyParts.eye:
                return (PlayerStats.rEye || PlayerStats.lEye);
            case BodyParts.arm:
                return (PlayerStats.rArm || PlayerStats.lArm);
            case BodyParts.leg:
                return (PlayerStats.rLeg || PlayerStats.lLeg);
            case BodyParts.ear:
                return (PlayerStats.rEar || PlayerStats.lEar);
            case BodyParts.lung:
                return PlayerStats.lung;
            case BodyParts.kidney:
                return PlayerStats.kidney;
            case BodyParts.stomach:
                return PlayerStats.stomach;
            default:
                return false;
        }
    }
}

