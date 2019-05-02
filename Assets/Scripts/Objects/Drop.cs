using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DropType
{
    gun,
    food,
    water,
    rifle,
    gbullets,
    rbullets,
    medicine,
    radaway,
}

public class Drop
{
    public string dropName;
    public int dropPrice;

    public Drop(DropType type)
    {
        switch (type)
        {
            case DropType.gun:
                this.dropName = "a gun";
                this.dropPrice = 100;
                break;
            case DropType.food:
                string[] names = { "some lettuce", "a steak", "some bacon", "some tomatoes", "some rat meat" };
                this.dropName = names[Random.Range(0,5)];
                this.dropPrice = 20;
                break;
            case DropType.water:
                this.dropName = "some water";
                this.dropPrice = 40;
                break;
            case DropType.rifle:
                this.dropName = "a rifle";
                this.dropPrice = 100;
                break;
            case DropType.gbullets:
                this.dropName = "some gun bullets";
                this.dropPrice = 1;
                break;
            case DropType.rbullets:
                this.dropName = "some rifle bullets";
                this.dropPrice = 2;
                break;
            case DropType.medicine:
                this.dropName = "some medicine";
                this.dropPrice = 50;
                break;
            case DropType.radaway:
                this.dropName = "some radaway";
                this.dropPrice = 30;
                break;

        }
    }

}
