using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public int Damage(string EnemyType)
    {
        switch (EnemyType)
        {
            case "skeleton1":
                return 1;
            case "knight1":
                return 2;
            default:
                Debug.Log("Cannot determine what enemy is attacking! Attack will deal 0 damage.");
                return 0;
        }
    }
}
