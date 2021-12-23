using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventory : MonoBehaviour
{
    public List<Item> item = new List<Item>();
    public List<Drag> drag;
    public GameObject invetory;

    void Start()
    { }
    void Update()
    {
        InventoryActive();
    }    
    public void InventoryActive()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(invetory.activeSelf)
            {
                InventoryDisable();
            }
            else
            {
                InventoryEnabled();
            }
        }
    }

    public void InventoryDisable()
    {
        foreach (Drag drag in drag)
            drag.RemoveCell();

        invetory.SetActive(false);
    }
    public void InventoryEnabled()
    {
        invetory.SetActive(true);

        foreach (Drag drag in drag)
            drag.RemoveCell();

            for (int i = 0; i < item.Count; i++)
            {
                Item it = item[i];
                for (int j = 0; j < drag.Count; j++)
                {
                    if(drag[j].ownerItem != "")
                    {
                        if(item[i].isStackable)
                        {
                            if(drag[j].item.nameItem == it.nameItem)
                            {
                                drag[j].countItem++;
                                drag[j].count.text = drag[j].countItem.ToString();
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        drag[j].item = it;
                        drag[j].image.sprite = Resources.Load<Sprite>(it.pathSprite);
                        drag[j].ownerItem = "myItem";
                        drag[j].countItem++;
                        break;
                    }
                }
            } 
            
    }

    

    public void RemoveItem(Drag drag)
    {
        Item it = drag.item;
        GameObject newObj = Instantiate<GameObject>(Resources.Load<GameObject>(it.pathPrefab));
        newObj.transform.position = transform.position + transform.forward + transform.up;
        item.Remove(it);
        InventoryEnabled();
    }
    public void UseItem(Drag drag)
    {
        print("use");
    }
}
