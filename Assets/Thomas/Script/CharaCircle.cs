using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCircle : MonoBehaviour
{
    private Rigidbody2D rgb;

    [SerializeField]
    private float charaSpeed = 0f;
    [SerializeField]
    private GameObject point = null;

    private Vector2 moveDirection;
    private float moveX;
    public Animator Anim;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInput();
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
            Debug.Log("droite");
        }
        else if(Vector2.Dot(n, charaMouse) < 0 && charaterFlip.x > 0)
        {
            charaterFlip.x *= -1;
            Debug.Log("gauche");
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
}
