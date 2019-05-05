using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactive : MonoBehaviour
{
    public GameObject fade;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerStats.inRadZone = true;
            fade.GetComponent<FadeInOut>().RadFadeIn();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.inRadZone = false;
            fade.GetComponent<FadeInOut>().RadFadeOut();
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
