using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ObjectType
{
    food,
    water,
    money,
    pistol,
    shotgun,
    rifle,
    medkit,
    radaway,
    gbullets,
    rbullets,
}

public class PickUp : MonoBehaviour
{
    public bool isActive;
    public ObjectType type;
    public int moneyCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnLevelWasLoaded(int level)
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            SoundManager.PlaySound("pick");
            switch (type)
            {
                case ObjectType.food:
                    PlayerStats.foodPieces++;
                    gameObject.SetActive(false);
                    break;
                case ObjectType.water:
                    PlayerStats.waterBottles++;
                    gameObject.SetActive(false);
                    break;
                case ObjectType.money:
                    PlayerStats.addMoney(moneyCount);

                    gameObject.SetActive(false);
                    break;
                case ObjectType.pistol:
                    if (!PlayerStats.hasPistol)
                    {
                        PlayerStats.hasPistol = true;
                        PlayerStats.usesPistol = true;
                        gameObject.SetActive(false);
                    }
                    break;
                case ObjectType.rifle:
                    if (!PlayerStats.hasRifle && !PlayerStats.oneHanded)
                    {
                        PlayerStats.hasRifle = true;
                        PlayerStats.usesRifle = true;
                        gameObject.SetActive(false);
                    }
                    break;
                case ObjectType.medkit:
                        PlayerStats.healthPacks++;
                    gameObject.SetActive(false);
                    break;
                case ObjectType.radaway:
                    PlayerStats.radPacks++;
                    gameObject.SetActive(false);
                    break;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = false;
        }
    }
}
