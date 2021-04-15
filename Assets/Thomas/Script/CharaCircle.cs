using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCircle : MonoBehaviour
{
    private Rigidbody2D rgb;

    [Header("Character Movement")]
    [SerializeField]
    private float charaSpeed = 0f;
    [SerializeField]
    private GameObject point = null;

    private Vector2 moveDirection;
    private float moveX;
    public Animator Anim;
    public bool Controller;
    public MouvementPersoTest Mouv;

    [Header("Health")]
    public int maxHealth = 3;
    public int currentHealth;

    private bool flashActive;
    [SerializeField]
    private float flashLenght = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!Controller)
        {
            ProcessInput();
        }else
        {
            moveDirection = Mouv.Vec.normalized;
        }

        if (flashActive)
        {
            if (flashCounter > flashLenght * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLenght * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLenght * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 charaMouse = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        Vector2 v = new Vector3(point.transform.position.x - transform.position.x, point.transform.position.y - transform.position.y);
        Vector2 n = Vector2.Perpendicular(v);

        Vector3 charaterFlip = transform.localScale;
        //ATTENTION : A MODIFIER LORS DE LA MISE DES SPRITES (ENLEVER LE SYSTEME SCALE ET METTRE "SPRITE FLIP")
        if(Vector2.Dot(n, charaMouse) > 0 && charaterFlip.x < 0)
        {
            charaterFlip.x *= -1;
            //Debug.Log("droite");
        }
        else if(Vector2.Dot(n, charaMouse) < 0 && charaterFlip.x > 0)
        {
            charaterFlip.x *= -1;
            //Debug.Log("gauche");
        }
        transform.localScale = charaterFlip;
    }

    public void ProcessInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if(moveDirection!=Vector2.zero)
        {
            Anim.SetBool("Mouving",true);
        }else
        {
            Anim.SetBool("Mouving", false);
        }
        rgb.velocity = new Vector2(moveDirection.x * charaSpeed, moveDirection.y * charaSpeed);
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        //Debug.Log("Player - 1");
        //Debug.Log(damageToGive);
        flashActive = true;
        flashCounter = flashLenght;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            Time.timeScale = 0;
        }
    }
}
