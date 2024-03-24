using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO ingridientPrefab;



    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParents(this);
            }
            else
            {
                // Player has nothing;
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                //Player carrying somthing so it can not put in because the countainer is full
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParents(player);
            }

        }
    }



}
