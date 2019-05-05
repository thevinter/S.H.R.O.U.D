using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI text;
    public string dialogue;
    public string dialogue2;
    public bool isActive;
    private int page = 0;
    private bool talked = false;
    // Start is called before the first frame update
    void Start()
    {
        page = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print("Page:" + page);
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            
            if (dialogueBox.activeInHierarchy)
            {
                if (PlayerStats.hasMemory)
                {
                    dialogueBox.SetActive(false);
                }
                else if (page == 3)
                {   
                    dialogueBox.SetActive(false);
                    page = 0;
                }

                else if (page == 1 && !PlayerStats.hasMemory)
                {
                    text.text = dialogue2;
                    talked = true;
                    page = 3;
                }
            }
            else
            {
                
                if (page == 0)
                {
                    print("aaaaaaaaaaaaaa");
                    text.text = dialogue;
                    if (PlayerStats.hasMemory)
                    {
                        PlayerStats.hasKey = true;
                    }
                    page++;
                } 
                dialogueBox.SetActive(true);
            }
        }

        if (PlayerStats.hasMemory)
        {
            if (talked)
            {
                dialogue = "Oh! You found it. Thanks, here's the key as promised";
            }
            else
            {
                dialogue = "Hey, that's mine. Take this key as a reward";
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
            page = 0;
        }
    }
}
