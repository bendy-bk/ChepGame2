using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask layerGround;
    [SerializeField] float speed = 200;

    [SerializeField] private float jumpForce;
    [SerializeField] private Kunai kunaiPrefap;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private GameObject attackArea;

    private bool isGround = true;
    private bool isJumping = false;
    private bool isAttack = false;
    //private bool isDead = false;
    private float horizontal;
    private int coin;


    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coin", 0);
    }

    void Update()
    {
        Move();
        //Debug.Log(CheckGrounded());
    }

    public override void OnInit()
    {
        base.OnInit();
        //isDead = false;
        isAttack = false;

        ChangeAnim("idle");
        DeactiveAttack();

        UIManger.instance.SetCoin(coin);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        OnInit();
    }

    protected override void OnDeadth()
    {
        base.OnDeadth();

    }

    /// <summary>
    /// Check isGrounded
    /// </summary>
    /// <returns></returns>
    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, Vector3.down * 1.2f + transform.position, Color.red);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, layerGround);


        return hit.collider != null;
    }
    /// <summary>
    /// Di chuuyen
    /// </summary>
    private void Move()
    {
        isGround = CheckGrounded();

        //horizontal = Input.GetAxisRaw("Horizontal");

        if (isGround)
        {
            if (isAttack)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            if (isJumping)
            {
                return;
            }

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                Jump();
            }


            if (Math.Abs(horizontal) > 0.01f)
            {
                ChangeAnim("run");
            }

            if (Input.GetKeyDown(KeyCode.F) && isGround)
            {
                Debug.Log("attack");
                //attack
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.C) && isGround)
            {
                //throw
                Throw();
            }


        }
        //Check jumpout
        if (!isGround && rb.velocity.y < 0)
        {
            ChangeAnim("fall");
            isJumping = false;
        }
        //Moving
        if (Math.Abs(horizontal) > 0.01f)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            //Quay mat sang left or right
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));

        }
        else if (isGround)
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }

    }
    private void Attack()
    {
        ChangeAnim("attack");
        isAttack = true;
        Invoke(nameof(RessetIdle), 0.5f);
        ActiveAttack();
        Invoke(nameof(DeactiveAttack), 0.5f);
    }
    private void RessetIdle()
    {
        isAttack = false;
        ChangeAnim("idle");
    }
    private void Jump()
    {
        ChangeAnim("jump");
        isJumping = true;
        rb.AddForce(jumpForce * Vector2.up);
    }
    private void Throw()
    {
        ChangeAnim("throw");
        isAttack = true;
        Invoke(nameof(RessetIdle), 0.5f);

        Instantiate(kunaiPrefap, throwPoint.position, throwPoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.enabled) return;
        if (collision.tag == "coin")
        {
            coin++;
            PlayerPrefs.SetInt("coin", coin);
            Debug.Log(coin);
            UIManger.instance.SetCoin(coin);
            Destroy(collision.gameObject);
        }

    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }
    private void DeactiveAttack()
    {
        attackArea.SetActive(false);
    }

    public void SetMove(float horizontal)
    {
        this.horizontal = horizontal;
    }


}
