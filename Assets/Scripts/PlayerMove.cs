using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;

    public float doubleJumpSpeed = 2.5f;// Creamos para un doble salto en el aire que sera menor al primer salto
    private bool canDoubleJump;//Variable para saber cuando podemos hacer el doble salto doubleJumpSpeed
    Rigidbody2D rb2D;  // Variable para almacenar una referencia al componente Rigidbody2D del jugador.
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);//Activamos animacion doble salto
                        rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }
        if (rb2D.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
        else if (rb2D.linearVelocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            animator.SetBool("Run", false);
        }




        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }

        }
    }
}
