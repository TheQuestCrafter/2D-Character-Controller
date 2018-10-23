using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    float maxSpeed = 10f;
    bool facingRight = true;
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    Animator anim;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
