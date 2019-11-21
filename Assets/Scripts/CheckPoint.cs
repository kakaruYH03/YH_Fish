using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.SendMessage("IncreaseScore");
    }
}