using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private const float KColumnSpacing = 1f;
    private const float KRowSpacing = 1f;


    [SerializeField] RectTransform ContentParent;
    [SerializeField] StorageSlot StorageSlotPrefab;

    private List<StorageSlot> StorageSlots;

    [SerializeField] int StorageSlotsNumber = 10;
    [SerializeField] int Columns = 3;

    private float itemDestroyedTimer;
    [SerializeField] GameObject itemDestroyedIndicator;

    private float timer = 1f;


    private void Awake()
    {
        StorageSlots = new List<StorageSlot>();
    }

    void Start()
    {
        for (int i = 0; i < StorageSlotsNumber; i++)
        {
            AddStorageSlot();
        }
    }

    void Update()
    {
        itemDestroyedTimer -= Time.deltaTime;

        UpdateItemDestroyedIndicator();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1;
            var item = new Item((ItemName)UnityEngine.Random.Range(1, 12));
            AddItem(item);
        }
    }

    public void AddStorageSlot()
    {
        var number = StorageSlots.Count;

        var storageSlot = Instantiate(StorageSlotPrefab);

        var row = number / Columns;
        var column = number % Columns;

        var posX = column * KColumnSpacing;
        var posY = -row * KRowSpacing;

        var storageSlotRT = storageSlot.GetComponent<RectTransform>();
        storageSlotRT.SetParent(ContentParent);
        storageSlotRT.anchoredPosition = new Vector3(posX, posY);

        StorageSlots.Add(storageSlot);
    }

    public void AddItem(Item item)
    {
        foreach (var storageSlot in StorageSlots)
        {
            if (storageSlot.Item == null)
            {
                storageSlot.SetItem(item);
                return;
            }
        }

        DestroyItem(item);
    }

    public void DestroyItem(Item item)
    {
        itemDestroyedTimer = 0.2f;
    }

    private void UpdateItemDestroyedIndicator()
    {
        if (itemDestroyedTimer > 0)
        {
            if (!itemDestroyedIndicator.activeSelf)
            {
                itemDestroyedIndicator.SetActive(true);
            }
        }
        else
        {
            if (itemDestroyedIndicator.activeSelf)
            {
                itemDestroyedIndicator.SetActive(false);
            }
        }
    }
}
