using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCircle : MonoBehaviour
{
    private Rigidbody2D rgb;

    [SerializeField]
    private float charaSpeed;

    private Vector2 moveDirection;
    private float moveX;

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

        Vector3 charaterFlip = transform.localScale;
        if(moveX < 0)
        {
            charaterFlip.x = -1;
        }
        else if(moveX > 0)
        {
            charaterFlip.x = 1;
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
        rgb.velocity = new Vector2(moveDirection.x * charaSpeed, moveDirection.y * charaSpeed);
    }
}
