using UnityEngine;
using System.Collections;

public class Player1Conroller : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;  
    bool blockFacing;
    bool onGround;
    float nextFire;
    public bool canMove;
    IUseable useable;
    float climbSpeed;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGound;
    private bool jump;

    private Ladder ladder;

    public bool onLadder;
    public bool facingRight;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float speed;
    public float jumpForce;
    public float shotSpeed;
    public GameObject weapon;

    


	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        onGround = true;
        nextFire = 0f;
        canMove = true;
        facingRight = true;
        onLadder = false;

	}
	
	void FixedUpdate () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        onGround = IsGrounded();

        if (canMove)
        {
            HandleMovement(horizontal, vertical);         
            Flip(horizontal);
            Jump();
            Attack();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        HandleLayers();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }    
    }


    void HandleMovement(float horizontal, float vertical)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (onLadder)
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }

        if (horizontal != 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (ladder != null)
        {
            if (((Input.GetKeyDown(KeyCode.W) && ((transform.position.y - ladder.gameObject.transform.position.y) < 0)) || Input.GetKeyDown(KeyCode.S)) && !onLadder)
                ladder.Use();
        }

        if (rb.velocity.y < 0 && !onLadder)
        {
            anim.SetBool("land", true); //falling animation
        }
    }


    void Flip(float horizontal)
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void Jump()
    {
        if(onGround && !onLadder)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector2(0.5f, jumpForce), ForceMode2D.Impulse);
                speed = 3;                       
                anim.SetTrigger("jump");
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Useable")
        {
            useable = other.GetComponent<IUseable>();
        }
        else if(other.tag == "Ladder")
        {
            ladder = other.GetComponent<Ladder>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Useable")
        {
            useable = null;
        }
        else if (other.tag == "Ladder")
        {
            ladder = null;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void Attack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            rb.velocity = Vector2.zero;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && onGround)
        {
            nextFire = Time.time + 1;
            anim.SetTrigger("swordAttack");
            rb.velocity = Vector2.zero;
            weapon.GetComponent<Animator>().SetTrigger("attack");

            if(weapon.tag == "Staff")
            {
                GetComponent<StaffAttack>().Shoot();
            }
        }
    }

    void ChangeWeapobVisib()
    {
        weapon.GetComponent<SpriteRenderer>().enabled = !weapon.GetComponent<SpriteRenderer>().enabled;
    }

    void ChangeCanMovem()
    {
        canMove = !canMove;
    }

    private void Use()
    {
        if(useable != null)
        {
            if (useable.GetType() == "Container" || useable.GetType() == "Lever")
            {
                anim.SetTrigger("sit");
                useable.Use();
                useable = null;
            }
            else if(useable.GetType() == "Door" || useable.GetType() == "Quest")
            {
                useable.Use();
            }
        }
    }

    private bool IsGrounded()
    {
        if(rb.velocity.y <= 0)
        {
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGound);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        anim.SetBool("land", false);
                        speed = 4;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if(!onGround)
        {
            anim.SetLayerWeight(1, 1);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }
}
