using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public TileBase tile; //Montre la tile visée
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("UI")]
    public bool stackable=true;

    [Header("Both")]
    public Sprite image;

    public enum ItemType
    {
        Tool,
        Weapon,
        Potion
    }

    public enum ActionType
    {
        Break,
        Use,
        Attack
    }
}
