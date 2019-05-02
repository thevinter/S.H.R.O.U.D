using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{

    public static Vector3 playerCoords = new Vector3(-19,-2,0);

    public static readonly float health = 100f;
    public static int c = 0;
    public static float currentHealth = 100;
    public static float waterLevel = 100;
    public static float foodLevel = 100;
    public static float radLevel = 0;
    public static bool inRadZone;

    public static bool hasMemory = false;
    public static bool hasKey = false;

    public static bool usesRifle;
    public static bool usesPistol;
    public static bool melee;

    public static int rifleBullets = 0;
    public static int pistolBullets = 0;

    public static int foodPieces = 2;
    public static int waterBottles = 2;
    public static int healthPacks = 0;
    public static int radPacks = 0; 
    private static int currency = 78;

    public static bool semiDeaf = false;
    public static bool fullDeaf = false;
    public static bool semiSlow = false;
    public static bool fullSlow = false;
    public static bool oneHanded = false;
    public static bool canShoot = true;
    public static bool semiBlind = false;
    public static bool fullBlind = false;
    public static bool fastHunger = false;
    public static bool fastRad = false;
    public static bool fastThirst = false;
    public static bool lEye = true;
    public static bool rEye = true;
    public static bool lArm = true;
    public static bool rArm = true;
    public static bool lung = true;
    public static bool kidney = true;
    public static bool stomach = true;
    public static bool rLeg = true;
    public static bool lEar = true;
    public static bool rEar = true;
    public static bool lLeg = true;

    public static bool hasRifle;
    public static bool hasPistol;

    public static int getMoney()
    {
        return currency;
    }

    public static void addMoney(int sum)
    {
        currency += sum;
    }

    public static void Reset()
    {
        WorldVariables.currentDay = 0;
        playerCoords = new Vector3(-19, -2, 0);
        semiDeaf = fullDeaf = semiSlow = fullSlow = oneHanded = semiBlind = fullBlind = fastHunger = fastRad = fastThirst = false;
        canShoot = true;
        lEye = rEye = lArm = rArm = lung = kidney = stomach = rLeg = lEar = rEar = lLeg = true;
        hasRifle = hasPistol = false;
        currency = 78;
        foodPieces = waterBottles = 2;
        healthPacks = radPacks = 0;
        currentHealth = waterLevel = foodLevel = 100;
        hasMemory = hasKey = false;
        inRadZone = false;
        radLevel = 0;
        pistolBullets = rifleBullets = 0;
    }   
}
