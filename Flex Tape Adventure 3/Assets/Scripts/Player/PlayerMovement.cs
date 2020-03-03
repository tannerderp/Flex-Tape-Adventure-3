using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpVel;
    [SerializeField] LayerMask layerMask;

    public float direction = 1f;
    public bool canMove = true;
    public int health = 100;

    Rigidbody2D rigidBody;
    BoxCollider2D boxCollider;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove && rigidBody.velocity.y == 0)
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        else
        {
            Movement();
        }
    }

    private void Movement()
    {
        var horizontal = Input.GetAxis("Horizontal"); //movement
        var rawHorizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * moveSpeed, rigidBody.velocity.y);

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))) //jumping
        {
            rigidBody.velocity = Vector2.up * jumpVel;
        }
        if (IsGrounded())
        {
            animator.SetBool("Jumping", false);
        }
        else
        {
           animator.SetBool("Jumping", true);
        }

        if (rawHorizontal != 0) //direction player is facing
        {
            direction = rawHorizontal;
        }
        var absoluteValue = Mathf.Abs(transform.localScale.x);
        var change = absoluteValue * direction;
        transform.localScale = new Vector2(change, transform.localScale.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontal * moveSpeed));
    }

    private bool IsGrounded()
    {
        RaycastHit2D boxCast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.2f, layerMask);
        return boxCast.collider != null;
    }

}
