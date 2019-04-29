using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public Transform laser;
    public int shootForce;
    private bool canShoot = true;
    private Vector3 heading;

    private float newFireTime; //This holds the time for the next shot
    private float stopFireTime; //Holds the time for when you want to change your anim
    private float firingDelay = 1; //The delay in seconds you set (ie a value of "2" means 1 shot every 2 seconds)

    private bool attackLoopStarted;
    public int health = 30;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        heading = player.transform.position - transform.position;
        var dir = heading / heading.magnitude;
        float step = speed * Time.deltaTime;    
        if (Vector3.Distance(transform.position, player.transform.position) < 10 && Vector3.Distance(transform.position, player.transform.position) > 4)
        {
            canShoot = true;
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < 4)
        {
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            if (canShoot)
            {
                AttackTimer();
            }   
        }

    }
     
    private void AttackTimer()
    {
        if (!attackLoopStarted) //If the attack loop has not been initiated
        {
            attackLoopStarted = true; //Signal the loop has been started
            newFireTime = Time.time + (1 / firingDelay); //Takes your fire delay in seconds and converts it to shots Per second and record this
            stopFireTime = Time.time + (1 / stopFireTime); // Same as above, except for your animation
            Shoot(); //Call your method to initiate an attack
        }

        if (attackLoopStarted) //Once the attack loop has started check the time against the future time
        {
            //If the gametime is greater than or equal to the newFireTime, then set the bool to false to restart the loop
            if (Time.time >= newFireTime)
            {
                attackLoopStarted = false;
            }
            
        }
    }

    private void Shoot()
    {
        Transform clone = Instantiate(laser, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * shootForce, ForceMode2D.Impulse);
    }


    private IEnumerator Reload()
    {  
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Damage(collision.GetComponent<BulletScript>().damage);
            GameObject.Destroy(collision.gameObject);
        }
    }

    private void Damage(int d)
    {
        print("damage");
        StartCoroutine(TurnRed());
        health -= d;
        if (health < 0)
            Destroy(this.gameObject);
    }

    private IEnumerator TurnRed()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }
}
