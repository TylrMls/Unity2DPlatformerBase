using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    public GuardScript GS;
    public GameObject[] Enemies;
    public Transform player;
    public Transform enemyTransform;
    public Animator anim;
    public AIController enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendDamage(string EnemyType)
    {
        GS.TakeDamage(EnemyType);
    }
    public void HitDamage(int Damage)
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in Enemies)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
            anim = enemy.GetComponent<Animator>();
            enemyTransform = enemy.GetComponent<Transform>();
            enemyScript = enemy.GetComponent<AIController>();
            if (enemyTransform.position.x >= player.position.x - GS.attackDistance && GS.isLookingLeft == false && enemyTransform.position.y >= player.position.y - 0.5 && enemyTransform.position.y <= player.position.y + 0.5)
            {
                anim.SetTrigger("Hit");
                enemyScript.Health = enemyScript.Health - GS.AttackDamage;
                anim.ResetTrigger("Hit");
            }
            else if (enemyTransform.position.x <= player.position.x + GS.attackDistance && GS.isLookingLeft == true && enemyTransform.position.y >= player.position.y - 0.5 && enemyTransform.position.y <= player.position.y + 0.5)
            {
                anim.SetTrigger("Hit");
                enemyScript.Health = enemyScript.Health - GS.AttackDamage;
                anim.ResetTrigger("Hit");
            }
        }
    }
}
