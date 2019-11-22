using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void ReGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
