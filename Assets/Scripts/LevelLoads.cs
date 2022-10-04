using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoads : MonoBehaviour
{
    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
