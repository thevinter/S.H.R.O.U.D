using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inv : MonoBehaviour
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
        switch (type) {
        case 0:
                text.text = "x" + PlayerStats.foodPieces;
                break;
        case 1:
                text.text = "x" + PlayerStats.waterBottles;
                break;
        case 2:
                text.text = "x" + PlayerStats.healthPacks;
                break;
        case 3:
                text.text = "x" + PlayerStats.radPacks;
                break;
        }
    }
}
