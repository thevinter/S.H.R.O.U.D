using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomEvent : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI choiceA;
    public TextMeshProUGUI choiceB;
    public GameObject buttonC;
    public GameObject buttonA;
    public GameObject buttonB;
    public string question;
    public string choice_a;
    public string winText;
    public string loseText;
    public string choice_b;
    public bool isActive;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive && !WorldVariables.caveEvent)
        {
            pc.setSlow(0f);
            dialogueBox.SetActive(true);
            questionText.text = question;
            choiceA.text = choice_a;
            choiceB.text = choice_b;
        }
    }

    public void AnswerA()
    {
        PlayerStats.waterBottles += 2;
        questionText.text = winText;
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonC.SetActive(true);
    }

    public void AnswerB()
    {
        //PlayerStats.currentHealth -= 20;
        questionText.text = loseText;
        buttonB.SetActive(false);
        buttonA.SetActive(false);
        buttonC.SetActive(true);
    }

    public void Close()
    {
        dialogueBox.SetActive(false);
        WorldVariables.caveEvent = true;
        pc.setSlow(1f);

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
