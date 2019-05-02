using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShoot : MonoBehaviour
{
    AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator shoot()
    {
        yield return new WaitForSeconds(15f);
        src.Play();
    }
}
