using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    //GameObject[] lives;
    public ScoreIndicator scoreIndicator;

    [SerializeField]
    GameObject bullet;

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    public static PlayerController instance;
    public static int Damage = 25;

    int livesNumber;

    public static int score;

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private float reload = 0.6f;
    private float countReload;
    private bool canShoot;

    private bool grounded;
    private bool doubleJump = false;
    public static bool Shoot;
    private Animator anim;

    public bool FacingRight = true;

    public PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerController>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stats.Init();

        score = 0;

        anim = GetComponent<Animator>();

        countReload = reload;
        canShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        scoreIndicator.SetScore(score);
        HandleInput();

        if (grounded)
        {
            doubleJump = false;
            anim.SetBool("IsJumping", false);
        }
        else
        {
            anim.SetBool("IsJumping", true);
        }

        if (!canShoot && countReload > 0)
        {
            countReload -= Time.deltaTime;
        }
        else if (!canShoot && countReload < 0)
        {
            canShoot = true;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hand"))
        {
            DamagePlayer(20);
            SoundManager.PlaySound("Aww");
        }
        if (stats.curHealth <= 0)
        {
            ZombieController.isAttacking = false;
        }

    }

    public void HandleInput()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            FacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            FacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            anim.SetBool("IsJumping", true);
            SoundManager.PlaySound("Jump");
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJump)
        {
            anim.SetBool("IsJumping", true);
            SoundManager.PlaySound("Jump");
            Jump();
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                if (canShoot)
                {
                    anim.SetBool("IsShoot", true);
                    Shooting(0);
                    SoundManager.PlaySound("Shoot");
                    canShoot = false;
                    countReload = reload;
                }
            }

            if (!grounded)
            {
                anim.SetBool("IsShoot", true);
                Shooting(0);
                SoundManager.PlaySound("Shoot");
                canShoot = false;
                countReload = reload;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            anim.SetBool("IsShoot", false);
        }
    }

    public void Shooting(int value)
    {
        if (FacingRight)
        {
            GameObject tmp = (GameObject)Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.left);
        }
    }

    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
}
