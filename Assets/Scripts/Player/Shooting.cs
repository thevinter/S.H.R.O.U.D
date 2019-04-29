using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    pistol,
    rifle,
    melee
}

public class Shooting : MonoBehaviour
{

    public WeaponType weapon;
    public float shootingDelay;
    public Transform pistolBullet;
    public Transform rifleBullet;
    public float shootForce;
    public Transform start;

    // Start is called before the first frame update
    void Start()
    {
        chooseDelay();
        chooseSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        CycleWeapon();
    }

    public void shoot(Vector3 dir)
    {
        if(weapon == WeaponType.pistol)
        {
            Transform clone = Instantiate(pistolBullet, start.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().AddForce(dir * shootForce, ForceMode2D.Impulse);

        }
        else if(weapon == WeaponType.rifle)
        {
            Transform clone = Instantiate(rifleBullet, start.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().AddForce(dir * shootForce, ForceMode2D.Impulse);
        }
        
    }

    private void CycleWeapon()
    {
        if (PlayerStats.hasPistol)
        {
            ChangeWeapon(WeaponType.pistol);
        }
        else if (PlayerStats.hasRifle)
        {
            ChangeWeapon(WeaponType.rifle);
        }
        else if (PlayerStats.melee)
        {
            ChangeWeapon(WeaponType.melee);
        }
    }

    private void ChangeWeapon(WeaponType newWeapon)
    {
        this.weapon = newWeapon;
        chooseDelay();
        chooseSpeed();
    }

    private void chooseDelay()
    {
        switch (weapon)
        {
            case WeaponType.pistol:
                shootingDelay = .4f;
                break;
            case WeaponType.rifle:
                shootingDelay = .2f;
                break;
        }
    }

    private void chooseSpeed()
    {
        switch (weapon)
        {
            case WeaponType.pistol:
                shootForce = 20;
                break;
            case WeaponType.rifle:
                shootForce = 17;
                break;
        }
    }
}
