using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public ItemType type;
    public ActionType actionType;


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
