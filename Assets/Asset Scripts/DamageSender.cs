using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    public GuardScript GS;
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
    public void DealDamage(int Damage)
    {

    }
}
