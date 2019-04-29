using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullets : MonoBehaviour
{
    public int type;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case 0:
                text.text = "x" + PlayerStats.pistolBullets;
                break;
            case 1:
                text.text = "x" + PlayerStats.rifleBullets;
                break;
        }
    }
}
