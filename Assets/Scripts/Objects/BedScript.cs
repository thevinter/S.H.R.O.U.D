using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{

    private bool isActive;
    private bool sleeping;
    public GameObject fade;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnLevelWasLoaded(int level)
    {
        WorldVariables.IncrementCurrentDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
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
        fade.GetComponent<FadeInOut>().StartFade();
    }


}
