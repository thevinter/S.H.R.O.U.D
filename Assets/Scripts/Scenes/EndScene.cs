using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    public TextMeshProUGUI text;
    public AudioSource src;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Shoot()
    {
        if (!done)
        {
            yield return new WaitForSeconds(20f);
            src.PlayOneShot(SoundManager.endShot);
            text.text = "Thanks for playing.\n\nGame developed for the 44th Ludum Dare by\n\nCoding: Nikita Brancatisano\nArt: Miriam Oajdea\nTesting and Balancing: Matteo Balestra and Christian Taccon";
        }
        done = true;
    }
}
