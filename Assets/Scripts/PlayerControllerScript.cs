using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

    public float maxSpeed = 10;
    public float jumpForce = 400f;
    bool facingRight = true;

    Animator anim;
    Rigidbody2D body;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    bool doubleJump = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", body.velocity.y);

        if (grounded)
            doubleJump = false;


        float move = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * maxSpeed, body.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        if (move < 0 && facingRight)
            Flip();
	}

    void Update()
    {
        if((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Ground", false);
            body.AddForce(new Vector2(0, jumpForce));
            if (body.velocity.y > 1)
            {
                body.velocity = new Vector2(body.velocity.x, 1);
            }

            if (!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
