using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int num_keys;
    bool[] keys_collected;

    int curr_keys = 0;

    // Start is called before the first frame update
    void Start()
    {
        keys_collected = new bool[num_keys]; // will all be intialized to default bool (false)
    }

    public void addKey() {
        keys_collected[curr_keys++] = true;
        print(curr_keys);
    }

    public bool accessDoor(int door_code) {
        return keys_collected[door_code];
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadNextLevel()
    {
        string currlevel = SceneManager.GetActiveScene().name;
        int nextlevel = currlevel[currlevel.Length-1] - '0';
        SceneManager.LoadScene("Level" + (++nextlevel).ToString());
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("StartScene");

    }

}
