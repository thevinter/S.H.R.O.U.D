using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPartRed : MonoBehaviour
{
    public Image right_arm;
    public Image left_arm;
    public Image right_leg;
    public Image left_leg;
    public Image lung;
    public Image kidney;
    public Image right_eye;
    public Image left_eye;
    public Image right_ear;
    public Image left_ear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.rArm)
        {
            right_arm.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.lArm)
        {
            left_arm.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.rLeg)
        {
            right_leg.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.lLeg)
        {
            left_leg.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.kidney)
        {
            kidney.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.lung)
        {
            lung.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.rEye)
        {
            right_eye.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.lEye)
        {
            left_eye.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.rEar)
        {
            right_ear.color = new Color(255, 0, 0);
        }
        if (!PlayerStats.lEar)
        {
            left_ear.color = new Color(255, 0, 0);
        }
    }
}
