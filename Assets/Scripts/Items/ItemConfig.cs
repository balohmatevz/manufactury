using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Config/ItemConfig", order = 2)]
public class ItemConfig : ScriptableObject
{
    [System.Serializable]
    public class ItemSetting
    {
        public ItemName ItemName;
        public Sprite Sprite;
        public Color Color;
    }

    [SerializeField]
    private List<ItemSetting> ItemSettings;

    public ItemSetting GetItemSetting(ItemName itemName)
    {
        return ItemSettings.Find(x => x.ItemName == itemName);
    }

}
