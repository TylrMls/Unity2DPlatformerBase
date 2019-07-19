using UnityEngine;
using System.Collections;

public class GuardScript : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 4.0f;

    private float inputX;
    public RemoveHealth RmvHlth;
    private Animator animator;
    private Rigidbody2D body2d;
    private Animator fade;
    public Vector3 oldplayerpos;
    private bool combatIdle = false;
    private bool isGrounded = true;
    private bool HasBegun = false;
    private int AttackDamage = 2;
    private int DamageTaken = 0;
    private int PlayerHealth = 5;

    // Use this for initialization
    void Start()
    {
        oldplayerpos = transform.position;
        fade = GameObject.Find("Fade").GetComponent<Animator>();
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
        animator.SetTrigger("Death");
        RmvHlth = GameObject.Find("Player").GetComponent<RemoveHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasBegun && PlayerHealth > 0)
        {
            if (Input.GetKeyDown("r"))
            {
                animator.SetTrigger("Recover");
                HasBegun = true;
            }
        }
        if (PlayerHealth <= 0)
        {
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Jump");
            animator.SetTrigger("Death");
            HasBegun = false;
            fade.SetBool("GameEnd", true);

        }
        // -- Handle input and movement --
        inputX = Input.GetAxis("Horizontal");
        if (HasBegun)
        {
            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            else if (inputX < 0)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

            // Move
            body2d.velocity = new Vector2(inputX * speed, body2d.velocity.y);

            // -- Handle Animations --
            isGrounded = IsGrounded();
            animator.SetBool("Grounded", isGrounded);

            /*
            //Death
            if (Input.GetKeyDown("k"))
            {
                animator.SetTrigger("Death");
            }
            //Hurt
            else if (Input.GetKeyDown("h"))
            {
                animator.SetTrigger("Hurt");
            }
            //Change between idle and combat idle
            else if (Input.GetKeyDown("i"))
            {
                combatIdle = !combatIdle;
            }
            */
            //Attack
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");
            }

            //Jump
            else if (Input.GetKeyDown("space") && isGrounded)
            {
                body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
                animator.SetTrigger("Jump");
            }

            //Walk
            else if (Mathf.Abs(inputX) > Mathf.Epsilon && isGrounded)
                animator.SetInteger("AnimState", 2);
            //Combat idle
            else if (combatIdle)
                animator.SetInteger("AnimState", 1);
            //Idle
            else
                animator.SetInteger("AnimState", 0);
            }
        }
    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, 0.00f);
    }
    public void TakeDamage(string Enemy)
    {
        DamageTaken = RmvHlth.Damage(Enemy);
        PlayerHealth = PlayerHealth - DamageTaken;
        animator.SetTrigger("Hurt");
    }
}
