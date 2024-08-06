using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class BuldingSystem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] private TileBase hightLightTile;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;
    private Vector3Int highlightedTilePos;
    private bool highlighted;


    private void Update()
    {
        if(item!=null) 
        {
            HighlightTile(item);
        }
    }

    private Vector3Int getMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(input.inputActions.Camera.MousePos.ReadValue<Vector2>());
        Vector3Int mouseSellPosition =mainTilemap.WorldToCell(mousePosition);
        mouseSellPosition.z = 0;
        return mouseSellPosition;
    }

    private void HighlightTile(Item currentItem)
    {
        Vector3Int mouseGridPos=getMousePosition();

        if(highlightedTilePos != mouseGridPos)
        {
            tempTilemap.SetTile(highlightedTilePos, null);
            TileBase tile = mainTilemap.GetTile(mouseGridPos);
            Debug.Log(mouseGridPos);
            if (tile)
            {
                tempTilemap.SetTile(mouseGridPos, hightLightTile);
                Debug.Log(hightLightTile);
                highlightedTilePos = mouseGridPos;
                highlighted = true;
            }
            else
            {
                highlighted=false;
            }
        }

        Debug.Log(highlighted);

    }
}
