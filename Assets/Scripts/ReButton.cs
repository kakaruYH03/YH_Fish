using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReButton : MonoBehaviour
{
    public void ReGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
