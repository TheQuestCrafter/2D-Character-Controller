using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    float maxSpeed = 10f, groundRadius = 0.2f, jumpForce = 700;
    bool facingRight = true, grounded = false;
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    Animator anim;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("verticalSpeed", rb2d.velocity.y);

        float move = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * move * maxSpeed);
        anim.SetFloat("Speed", Mathf.Abs(move));
        
        //rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
        //didn't move character at all
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
	}

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
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
