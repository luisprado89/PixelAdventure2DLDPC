using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    public Joystick joystick;


    public float runSpeedHorizontal = 2;
    public float runSpeed = 1.2f;

    public float jumpSpeed = 3;

    public float doubleJumpSpeed = 2.5f;// Creamos para un doble salto en el aire que sera menor al primer salto
    private bool canDoubleJump;//Variable para saber cuando podemos hacer el doble salto doubleJumpSpeed
    Rigidbody2D rb2D;  // Variable para almacenar una referencia al componente Rigidbody2D del jugador.

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        //Esta correccion me la dio chatgpt
        rb2D = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (horizontalMove > 0)//derecha
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }
        else if (horizontalMove < 0)//izquierda
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
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
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        rb2D.linearVelocity = new Vector2(horizontalMove * runSpeed, rb2D.linearVelocity.y);

    }
    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
        }
        else
        {
            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);//Activamos animacion doble salto
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }
        }
    }
    // En el script del jugador para no tener problema de que se pierda la animacion y el salto al entrar en contacto con las puertas del menu
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OpenDoor"))
        {
            Debug.Log("Entró en el trigger de la puerta");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OpenDoor"))
        {
            Debug.Log("Salió del trigger de la puerta");
        }
    }

}
