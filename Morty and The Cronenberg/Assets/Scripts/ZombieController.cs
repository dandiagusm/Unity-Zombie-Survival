using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    float dirX;

    private int health;
    public int MaxHealth;
    public int factorScaling = 10;

    [SerializeField]
    float moveSpeed = 3f;

    Rigidbody2D rb;

    bool facingRight = false;

    Vector3 localScale;

    public static bool isAttacking = false;

    [SerializeField]
    private StatusIndicator statusIndicator;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;

        anim = GetComponent<Animator>();
        MaxHealth = MaxHealth + WaveSpawner.nextWave * factorScaling;
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x > 9f)
            dirX = -1f;

        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);

        statusIndicator.SetHealth(health, MaxHealth);

    }

    void FixedUpdate()
    {
        if (!isAttacking)
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("fireball(Clone)"))
        {
            if (health - PlayerController.Damage <= 0)
            {
                SoundManager.PlaySound("DeathVoice");
                PlayerController.score = PlayerController.score + 1;
                Destroy(gameObject);
            }
            else
            {
                health = health - PlayerController.Damage;
            }

        }
    }
}
