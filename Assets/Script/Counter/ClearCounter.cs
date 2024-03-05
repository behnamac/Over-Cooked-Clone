using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParents
{
    [SerializeField] private KitchenObjectSO ingridientPrefab;
    [SerializeField] private Transform topCounterSpawnPoint;
    private KitchenObject currentKitchenObject;

    //Tesing
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;


    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (currentKitchenObject != null)
            {
                currentKitchenObject.SetKitchenObjectParents(secondClearCounter);
            }
        }
    }

    public void Interact(Player player)
    {
        if (currentKitchenObject == null)
        {
            var ingridien = Instantiate(ingridientPrefab.Prefab, topCounterSpawnPoint);
            ingridien.GetComponent<KitchenObject>().SetKitchenObjectParents(this);           
        }
        else
        {
         //   currentKitchenObject.SetKitchenObjectParents(player);

        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return topCounterSpawnPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.currentKitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObjecy()
    {
        return currentKitchenObject;
    }

    public void ClearKitchenObject()
    {
        currentKitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return currentKitchenObject != null;
    }
   
}
