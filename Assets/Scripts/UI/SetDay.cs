using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetDay : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string day;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day = "Day:" + WorldVariables.GetCurrentDay();
        text.text = day;
    }
}
