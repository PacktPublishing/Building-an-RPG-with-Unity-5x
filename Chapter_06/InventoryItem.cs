using System;
using UnityEngine;
using System.Collections;


[Serializable]
public class InventoryItem : BaseItem
{
  public enum ItemType
  {
    HELMET = 0,
    SHIELD = 1,
    SHOULDER_PAD = 2,
    KNEE_PAD = 3,
    BOOTS = 4,
    WEAPON = 5
  }

  [SerializeField]
  private ItemCatrgory category;
  [SerializeField]
  private ItemType type;
  [SerializeField]
  private float strength;
  [SerializeField]
  private float weight;

  public ItemCatrgory CATEGORY
  {
    get { return this.category; }
    set { this.category = value; }
  }

  public ItemType TYPE
  {
    get { return this.type; }
    set { this.type = value; }
  }

  public float STRENGTH
  {
    get { return this.strength; }
    set { this.strength = value; }
  }

  public float WEIGHT
  {
    get { return this.weight; }
    set { this.weight = value; }
  }

  public void CopyInventoryItem(InventoryItem item)
  {
    this.CATEGORY = item.CATEGORY;
    this.TYPE = item.TYPE;
    this.DESCRIPTION = item.DESCRIPTION;
    this.NAME = item.NAME;
    this.STRENGTH = item.STRENGTH;
    this.WEIGHT = item.WEIGHT;
  }
}
