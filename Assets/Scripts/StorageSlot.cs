using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSlot : MonoBehaviour
{
    public Item Item { get; private set; }
    [SerializeField] private ItemConfig ItemConfig;
    [SerializeField] private Image _image;

    public void SetItem(Item item)
    {
        Item = item;

        var itemSetting = ItemConfig.GetItemSetting(Item.ItemName);
        _image.sprite = itemSetting.Sprite;
        _image.color = itemSetting.Color;
    }
}
