using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingTypes
{
    CraftingTable,
    Furnace,
    Kitchen,
    Storage
}

[System.Serializable]

public class CraftingRecipe
{
    public string itemName;
    public ItemType resultItem;
    public int resultAmount = 1;
    public ItemType[] requiredItems;
    public int[] requiredAmounts;        //필요한 재료
}