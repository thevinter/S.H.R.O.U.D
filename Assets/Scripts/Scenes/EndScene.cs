using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    public TextMeshProUGUI text;
    public AudioSource src;
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
        yield return new WaitForSeconds(30f);
        src.PlayOneShot(SoundManager.endShot);
        text.text = "Thanks for playing.\n\nGame developed for the 44th Ludum Dare by\n\nCoding: Nikita Brancatisano\nArt: Miriam Oajdea\nTesting and Balancing: Matteo Balestra and Christian Taccon";
    }
}
