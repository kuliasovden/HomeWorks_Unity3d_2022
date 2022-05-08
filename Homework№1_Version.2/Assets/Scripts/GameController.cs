using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set { _itemsCollected = value;}
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 75, 150, 25), "Items Collected:" + _itemsCollected);
        
    }
}
