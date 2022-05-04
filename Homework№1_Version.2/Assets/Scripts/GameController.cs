using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int itemsCollected = 0;
    public int Items
    {
        get { return itemsCollected; }
        set { itemsCollected = value;}
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 75, 150, 25), "Items Collected:" + itemsCollected);
        
    }
}
