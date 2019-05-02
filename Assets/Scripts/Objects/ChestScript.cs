using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestScript : MonoBehaviour
{
    public ObjectType type;
    public bool isActive;
    public int moneyCount;
    public GameObject dialogueBox;
    public TextMeshProUGUI text;
    private bool opened = false;
    public Sprite sprite;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        print(dialogueBox);
        if (Input.GetKeyDown(KeyCode.Space) && isActive && !opened)
        {
            switch (type)
            {
                case ObjectType.food:
                    PlayerStats.foodPieces++;
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found some food";
                    break;
                case ObjectType.water:
                    PlayerStats.waterBottles++;
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found one water bottle!";
                    break;
                case ObjectType.money:
                    PlayerStats.addMoney(moneyCount);
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found " + moneyCount + "$";
                    break;
                case ObjectType.medkit:
                    PlayerStats.healthPacks++;
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found a medkit!";
                    break;
                case ObjectType.radaway:
                    PlayerStats.radPacks++;
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found some radaway";
                    break;
                case ObjectType.gbullets:
                    PlayerStats.pistolBullets+=30;
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found 30 gun bullets!";
                    break;
                case ObjectType.rbullets:
                    PlayerStats.rifleBullets += 50;
                    opened = true;
                    sr.sprite = sprite;
                    dialogueBox.SetActive(true);
                    SoundManager.PlaySound("menuSound");

                    text.text = "You found 50 rifle bullets!";
                    break;
            }

        }
        else if(Input.GetKeyDown(KeyCode.Space) && isActive && dialogueBox.activeInHierarchy)
        {
            dialogueBox.SetActive(true);
            SoundManager.PlaySound("menuSound");

        }

        else if(Input.GetKeyDown(KeyCode.Space) && isActive && !dialogueBox.activeInHierarchy && opened)
        {
            dialogueBox.SetActive(true);
            SoundManager.PlaySound("menuSound");

            text.text = "The chest is now empty";
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
}
