using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float MOVE_FORCE;
    public float MAX_SPEED;
    public float JUMP_FORCE;

    private bool _facingRight;
    private bool _jumping;
    private bool _doubleJumping;

 
    private float jumpForce;
    private float doubleJumpForce;
    private Transform groundCheck;

    private bool _grounded;
    private Animator animator;
    private Rigidbody2D playerBody;

	// Use this for initialization
	void Awake () {
        _jumping = false;
        _doubleJumping=false;
        _facingRight = false;
        _grounded = true;
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck").GetComponent<Transform>();
        
	}

    void Update()
    {
        animator.SetBool("Grounded", _grounded);
        if (_grounded)
        {
            _jumping = false;
            _doubleJumping = false;
            animator.SetBool("Jump", _jumping);
        }



    }
	void FixedUpdate () {


        horizzontalMove();
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, (1 << LayerMask.NameToLayer("Ground")) |  (1 << LayerMask.NameToLayer("Platform")));

        if (_grounded)
        {
            _jumping = false;
            animator.SetBool("Jump", _jumping);
            if (Input.GetKeyDown(KeyCode.W))
                jump();
        }
	}

    void flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void jump()
    {

        playerBody.AddForce(new Vector2(0f, JUMP_FORCE));
        _jumping = true;
        animator.SetBool("Jump", _jumping);
    }

    void horizzontalMove()
    {
        float h = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(h));

       
        if (h != 0)
        {

            float direction = h > 0 ? 1 : -1;
            playerBody.AddForce(new Vector2(MOVE_FORCE * direction, 0f));
            float actualForce = Mathf.Abs(playerBody.velocity.x);
            if (actualForce > MAX_SPEED)
            {
                float verticalVelocity = playerBody.velocity.y;
                playerBody.velocity = new Vector2(MAX_SPEED * direction, verticalVelocity);
            }


        }
        else
            playerBody.velocity = new Vector2(0f, playerBody.velocity.y);

        if (h < 0 && !_facingRight)
            flip();
        else
        {
            if (h > 0 && _facingRight)
                flip();
        }
    }

}
