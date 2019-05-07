using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}



public class PlayerController : MonoBehaviour
{
    private bool flipX;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 change;
    private PlayerState currentState;
    public float speed = 0;
    private Vector3 shootingDir;
    private Shooting shootScript;
    private SpriteRenderer sr;
    private float slowFactor = 1;
    private AudioSource step;
    private bool isRunning = false;
    public float boost = 2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.currentHealth = PlayerStats.health;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        this.currentState = PlayerState.idle;
        rb = this.GetComponent<Rigidbody2D>();
        shootScript = GetComponent<Shooting>();
        step = GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level)
    {
        this.transform.position = PlayerStats.playerCoords;
    }

    public void TimePass()
    {
        PlayerStats.foodLevel -= 0.35f;
        PlayerStats.waterLevel-= 0.55f;
        PlayerStats.radLevel += 0.2f;
        if(PlayerStats.fastHunger)
            PlayerStats.foodLevel -= 0.23f;
        if(PlayerStats.fastThirst)
            PlayerStats.waterLevel -= .33f;
        if (PlayerStats.fastRad)
            PlayerStats.radLevel += 0.13f;

        if (PlayerStats.inRadZone)
            PlayerStats.radLevel += 1.5f;
        if(isRunning)
            PlayerStats.foodLevel -= .2f;

    }

    public void EatFood()
    {
        if(PlayerStats.foodPieces > 0)
        {
            PlayerStats.foodPieces--;
            PlayerStats.foodLevel += 35;
        }
 
    }

    public void DrinkWater()
    {
        if (PlayerStats.waterBottles > 0)
        {
            PlayerStats.waterBottles--;
            PlayerStats.waterLevel += 40;
        }
        
    }

    public void UseMedpack()
    {
        if(PlayerStats.healthPacks > 0)
        {
            PlayerStats.healthPacks--;
            PlayerStats.currentHealth += 50;
        }
        
    }

    public void UseRadaway()
    {
        if(PlayerStats.radPacks > 0)
        {
            PlayerStats.radPacks--;
            PlayerStats.radLevel -= 30;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        NormalizeStats();
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerStats.Reset();
            transform.position = PlayerStats.playerCoords;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (flipX)
            sr.flipX = true;
        else
            sr.flipX = false;
        GetShootingDir();
        change = Vector3.zero;
        GetInput();
        if ((Input.GetButtonDown("AttackHor")) && currentState != PlayerState.attack)
        {
            if((PlayerStats.usesPistol && PlayerStats.pistolBullets > 0)|| (PlayerStats.usesRifle && PlayerStats.rifleBullets >0))
            {
                if (shootingDir.x == -1)
                {
                    flipX = false;
                }
                else if (shootingDir.x == 1)
                {
                    flipX = true;
                }
                StartCoroutine(Attack(shootScript.shootingDelay, shootingDir));
            }
        }
        if (currentState == PlayerState.walk || currentState == PlayerState.idle || currentState == PlayerState.attack)
        {
            UpdateAnimAndMove();
        }

        PlayerStats.playerCoords = this.transform.position;
        
    }

    private void CheckDeath()
    {
        if(PlayerStats.currentHealth < 0 || PlayerStats.foodLevel < 0 || PlayerStats.waterLevel < 0 || PlayerStats.radLevel == 100)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NormalizeStats()
    {
        if (PlayerStats.foodLevel > 100)
            PlayerStats.foodLevel = 100;
        if (PlayerStats.waterLevel > 100)
            PlayerStats.waterLevel = 100;
        if (PlayerStats.radLevel > 100)
            PlayerStats.radLevel = 100;
        if (PlayerStats.currentHealth > 100)
            PlayerStats.currentHealth = 100;
    }

    public void Donate(BodyParts p) //Loses a body part, starting from 0.
    {
        switch (p)
        {
            case BodyParts.eye: //eye
                if (PlayerStats.rEye == false)
                {
                    PlayerStats.lEye = false;
                }

                else
                {
                    PlayerStats.rEye = false;
                }
                    
                break;
            case BodyParts.arm:
                if (PlayerStats.rArm == false)
                    PlayerStats.lArm = false;
                else
                    PlayerStats.rArm = false; 
                break;
            case BodyParts.leg:
                if (PlayerStats.rLeg == false)
                    PlayerStats.lLeg = false;
                else
                    PlayerStats.rLeg = false;
                break;
            case BodyParts.ear:
                if (PlayerStats.rEar == false)
                    PlayerStats.lEar = false;
                else
                    PlayerStats.rEar = false;
                break;
            case BodyParts.lung:
                PlayerStats.lung = false;
                break;
            case BodyParts.kidney:
                PlayerStats.kidney = false;
                break;
            case BodyParts.stomach:
                PlayerStats.stomach = false;
                break;
        }
    }

    private void GetShootingDir()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shootingDir = new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shootingDir = new Vector3(-1, 0, 0);
        }
    }

    private void GetInput()
    {
        isRunning = false;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change.x == 1 && currentState != PlayerState.attack)
            flipX = true;
        if (change.x == -1 && currentState != PlayerState.attack)
            flipX = false;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerStats.usesPistol = false;
            PlayerStats.usesRifle = false;
            PlayerStats.melee = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerStats.hasPistol)
        {
            PlayerStats.usesPistol = true;
            PlayerStats.usesRifle = false;
            PlayerStats.melee = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerStats.hasRifle)
        {
            print("Rifle");
            PlayerStats.usesPistol = false;
            PlayerStats.usesRifle = true;
            PlayerStats.melee = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
    }

    private void UpdateAnimAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveEffector(change.normalized);
            anim.SetBool("isRunning", true);
            
        }
        else
        {
            step.Stop();
            anim.SetBool("isRunning", false);
        }
    }

    private void MoveEffector(Vector3 change)
    {
        float tempSpeed = speed;
        if (isRunning)
        {
            tempSpeed = tempSpeed + boost;
        }
        rb.MovePosition(
            transform.position + change * tempSpeed * Time.deltaTime * slowFactor
        );
    }

    public void Step()  
    {
       SoundManager.PlaySound("step");
    }

    public void setSlow(float s)
    {
        slowFactor = s;
    }

    private IEnumerator Attack(float delay, Vector3 dir)
    {
        while (Input.GetButton("AttackHor"))
        {
            shootScript.shoot(dir);
            currentState = PlayerState.attack;
            yield return new WaitForSeconds(delay);
        }
        currentState = PlayerState.walk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Damage();
            GameObject.Destroy(collision.gameObject);
        }
    }

    private void Damage()
    {
        StartCoroutine(TurnRed());
        PlayerStats.currentHealth -= 10;
    }

    private IEnumerator TurnRed()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

    }
}
