using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmeraManager : MonoBehaviour
{

    void Start()
    {

        
    }

    void Update()
    {
        
    }

    public void Shake()
    {
        GetComponent<Animator>().SetTrigger("shake");
    }
}
