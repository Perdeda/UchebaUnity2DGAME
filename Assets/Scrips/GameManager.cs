using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool GameEnd = false;
    public void End()
    {
        if(GameEnd == false)
        {
            GameEnd = true;
            Invoke("Restart",1.4f);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
