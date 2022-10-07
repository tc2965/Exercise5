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

    AudioSource audioSrc;
    public AudioClip audioClip; // for key pick up

    // Start is called before the first frame update
    void Start()
    {
        keys_collected = new bool[num_keys]; // will all be intialized to default bool (false)

        GameObject player =  GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            audioSrc = player.GetComponent<AudioSource>();
        }
    }

    public void addKey() {
        keys_collected[curr_keys++] = true;
        print(curr_keys);

        if (audioSrc != null && audioClip != null) {
            audioSrc.PlayOneShot(audioClip);
        }
    }

    public bool accessDoor(int door_code) {
        return keys_collected[door_code];
    }

    public int getKeysCollected() {
        return curr_keys;
    }

    public int totalKeys() {
        return num_keys;
    }

    public void ResetLevel() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel1()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
        SceneManager.LoadScene("Level1");
    }

    public void LoadNextLevel()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
        string currlevel = SceneManager.GetActiveScene().name;
        int nextlevel = currlevel[currlevel.Length-1] - '0';
        if (nextlevel == 3) {
            SceneManager.LoadScene("WinScene");
        }
        SceneManager.LoadScene("Level" + (++nextlevel).ToString());
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("StartScene");
    }

}
