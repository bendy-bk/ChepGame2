using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask layerGround;
    [SerializeField] float speed = 200;
    [SerializeField] Animator animator;

    private bool isGround;
    private bool isJumping;
    private bool isAttack;

    private float horizontal;

    private string currentAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //Debug.Log(CheckGrounded());
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, Vector3.down * 1.2f + transform.position, Color.red);


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, layerGround);


        return hit.collider != null;
    }
    private void Move()
    {
        isGround = CheckGrounded();

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Math.Abs(horizontal) > 0.01f)
        {
            ChangeAnim("run");
            rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * speed, rb.velocity.y);
            //Quay mat sang left or right
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));

        }
        else if (isGround)
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }

    }
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }
    private void Attack()
    {

    }
    private void Jump()
    {

    }
    private void Throw()
    {

    }
}
