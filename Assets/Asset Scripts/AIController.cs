using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform player;
    private SpriteRenderer SR;
    private Animator EA;
    public float speed = 1f;
    public float minDistance = 1f;
    public float attackDistance = 0.1f;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        EA = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.position.x < transform.position.x + attackDistance && player.position.x > transform.position.x - attackDistance)
        {
            EA.SetBool("isWalking", false);
            EA.SetTrigger("Attack");
        }
        else if (player.position.x < transform.position.x + minDistance && player.position.x > transform.position.x - minDistance)
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
}
