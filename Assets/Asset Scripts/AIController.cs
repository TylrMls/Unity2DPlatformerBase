using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform player;
    private BoxCollider2D boxcollider;
    private SpriteRenderer SR;
    private Animator EA;
    public float speed = 1f;
    public float minDistance = 1f;
    public float attackDistance = 0.1f;
    public float BoxX;
    public int Health = 5;
    private bool isDead = false;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        EA = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        BoxX = boxcollider.size.x;
    }

    void Update()
    {
        Debug.Log("Health is at " + Health.ToString());
        if (Health <= 0)
        {
            EA.ResetTrigger("Attack");
            EA.SetBool("isWalking", false);
            EA.SetBool("Dead", true);
            boxcollider.size = new Vector2(BoxX, 0.5f);
        }
        else if (player.position.x < transform.position.x + attackDistance && player.position.x > transform.position.x - attackDistance && player.position.y >= transform.position.y - 0.5 && player.position.y <= transform.position.y + 0.5)
        {
            EA.SetBool("isWalking", false);
            EA.SetTrigger("Attack");
        }
        else if (player.position.x < transform.position.x + minDistance && player.position.x > transform.position.x - minDistance && player.position.y >= transform.position.y - 0.5 && player.position.y <= transform.position.y + 0.5)
        {
            EA.ResetTrigger("Attack");
            Vector3 posToGo = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);
            EA.SetBool("isWalking", true);
        }
        if (player.position.x < transform.position.x)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
    }
    public void RemoveBody()
    {
        Destroy(gameObject);
    }
}
