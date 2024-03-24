using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO ingridientPrefab;
    public Action OnPlayerGrabbedObject;


    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            var ingridien = Instantiate(ingridientPrefab.Prefab);
            ingridien.GetComponent<KitchenObject>().SetKitchenObjectParents(player);
            OnPlayerGrabbedObject?.Invoke();
        }
       
    }

    
}
