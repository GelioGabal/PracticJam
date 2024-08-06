using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="GameObject/Item")]
public class Item : ScriptableObject
{

    public TileBase Tile;
    public Sprite sprite;
    public ItemType type;
    public AtionType ation;



    public enum ItemType
    {
        BuldingBlock,
        Tool
    }

    public enum AtionType
    {
        remove
    }


}


