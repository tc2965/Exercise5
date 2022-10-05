using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}