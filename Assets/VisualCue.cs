using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualCue : MonoBehaviour
{


    public GameObject water, rad, food, health;
    public Image waterI, radI, foodI, healthI;
    private bool startedRad;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        waterI = water.GetComponent<Image>();
        radI = rad.GetComponent<Image>();
        foodI = food.GetComponent<Image>();
        healthI = health.GetComponent<Image>();

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerStats.waterLevel < 15)
            if (!startedRad)
            {
                StartCoroutine(TurnRed(waterI));
                startedRad = true;
            }
        if (PlayerStats.currentHealth < 15)
            if (!startedRad)
            {
                StartCoroutine(TurnRed(healthI));
                startedRad = true;
            }
        if (PlayerStats.radLevel > 85)
        {
            if (!startedRad)
            {
                StartCoroutine(TurnRed(radI));
                startedRad = true;
            }
        }
        if (PlayerStats.foodLevel < 15)
            if (!startedRad)
            {
                StartCoroutine(TurnRed(foodI));
                startedRad = true;
            }
    }


    IEnumerator TurnRed(Image image)
    {
        SoundManager.PlaySound("warning");
        image.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(.3f);
        image.color = Color.black;
        yield return new WaitForSeconds(.3f);
        startedRad = false;
    }
}
