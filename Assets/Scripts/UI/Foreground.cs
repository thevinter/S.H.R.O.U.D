using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foreground : MonoBehaviour
{
    public GameObject house;
    public bool inverted;
    public bool foreground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inverted)
        {
            if (this.transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
            {
                print("a");
                house.GetComponent<Renderer>().sortingLayerName = "PlayerTop";
            }

            else
            {
                print("b");
                house.GetComponent<Renderer>().sortingLayerName = "Default";
            }
        }
        else
        {
            if (this.transform.position.y > GameObject.FindGameObjectWithTag("Player").transform.position.y)
            {
                house.GetComponent<Renderer>().sortingLayerName = "PlayerTop";
            }

            else
            {
                house.GetComponent<Renderer>().sortingLayerName = "Default";
            }
        }
    }
}
