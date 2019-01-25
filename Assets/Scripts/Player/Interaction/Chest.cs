using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {

    Inventory Inventory;
    InventorySlot[] slots;

    public Transform slotsParent;
    public GameObject chestUI;
    public List<Item> chestContents;
    public Item chestItem1, chestItem2, chestItem3, chestItem4;


    public override void EInteract(GameObject Chest)
    {
        base.EInteract(Chest);
        UpdateUI();
        
    }

    // Use this for initialization
    void Start()
    {
        Inventory = Inventory.instance;
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ResetUI();
        }
    }

    public void ResetUI()
    {
        chestUI.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            //slots[i].Clearslot();
            slots[i] = null;
            chestContents.RemoveAt(i);
        }

    }

    public void FillList()
    {
        if (chestItem1 != null)
        {
            chestContents.Add(chestItem1);
        }
        if (chestItem2 != null)
        {
            chestContents.Add(chestItem2);
        }
        if (chestItem3 != null)
        {
            chestContents.Add(chestItem3);
        }
        if (chestItem4 != null)
        {
            chestContents.Add(chestItem4);
        }
    }

    public void UpdateUI()
    {
        ResetUI();
        FillList();
        //for (int i = 0; i < 3; i++)
        //{
        //    if (chestContents != null)
        //    {
        //       // slots[i].Additem(chestContents[i]);
        //    }
        //}
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < chestContents.Count)
            {
                slots[i].Additem(chestContents[i]);
            }
            else
            {
                slots[i].Clearslot();
            }
        }
        chestUI.SetActive(true);
    }


}
