using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDisplay : MonoBehaviour
{
    public Texture2D plant; 
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorOffset = new Vector2(plant.width/2, plant.height/2);
        Cursor.SetCursor(plant, cursorOffset, CursorMode.Auto);
    }
}
