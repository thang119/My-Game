using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data")]
public class Item : ScriptableObject
{
    public Sprite Pic;
    public string Description;
    public enum Type {Weapon, Item, Mist};
    public int ID;
    public Type TypeItem;
}
