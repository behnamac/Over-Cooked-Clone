using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParents
{
    public abstract void Interact(Player player);

    [SerializeField] protected Transform topCounterSpawnPoint;

    private KitchenObject currentKitchenObject;


    public Transform GetKitchenObjectFollowTransform()
    {
        return topCounterSpawnPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.currentKitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
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

