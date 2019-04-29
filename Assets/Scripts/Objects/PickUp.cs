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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            switch (type)
            {
                case ObjectType.food:
                    PlayerStats.foodPieces++;
                    Destroy(gameObject);
                    break;
                case ObjectType.water:
                    PlayerStats.waterBottles++;
                    Destroy(gameObject);
                    break;
                case ObjectType.money:
                    PlayerStats.addMoney(moneyCount);
                    Destroy(gameObject);
                    break;
                case ObjectType.pistol:
                    if (!PlayerStats.hasPistol)
                    {
                        PlayerStats.hasPistol = true;
                        Destroy(gameObject);
                    }
                    break;
                case ObjectType.rifle:
                    if (!PlayerStats.hasRifle   )
                    {
                        PlayerStats.hasRifle = true;
                        Destroy(gameObject);
                    }
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
