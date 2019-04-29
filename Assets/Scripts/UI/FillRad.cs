using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillRad : MonoBehaviour
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case "health":
                GetComponent<Image>().fillAmount = PlayerStats.currentHealth * 0.01f;
                break;
            case "rad":
                GetComponent<Image>().fillAmount = PlayerStats.radLevel * 0.01f;
                break;
            case "water":
                GetComponent<Image>().fillAmount = PlayerStats.waterLevel * 0.01f;
                break;
            case "food":
                GetComponent<Image>().fillAmount = PlayerStats.foodLevel * 0.01f;
                break;
        }
        
    }
}
