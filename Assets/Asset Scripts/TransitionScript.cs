using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public GuardScript PositionFinder;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Died");
    }
    public void BackToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    public void RemoveText()
    {
        Destroy(GameObject.Find("ShowText"));
    }
}
