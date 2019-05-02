using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{
    public bool canSleep = true;
    public bool isActive;
    private bool sleeping;
    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnLevelWasLoaded(int level)
    {
        canSleep = true;
        WorldVariables.IncrementCurrentDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive && canSleep)
        {
            print("aaaa");
            GoToSleep();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sda");
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
        }
    }

    private void GoToSleep()
    {
        canSleep = false;
        PlayerStats.currentHealth += 20;
        PlayerStats.foodLevel -= 15;
        PlayerStats.waterLevel -= 15;
        fade.GetComponent<FadeInOut>().StartFade();
    }


}
