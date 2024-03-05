using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParents kitchenObjectParents;

    public KitchenObjectSO GetkitchenObject()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParents(IKitchenObjectParents kitchenObjectParents)
    {
        if(this.kitchenObjectParents != null)
            this.kitchenObjectParents.ClearKitchenObject();

        this.kitchenObjectParents = kitchenObjectParents;

        if (kitchenObjectParents.HasKitchenObject())
            Debug.LogError("Counter has already has the somthing");

        kitchenObjectParents.SetKitchenObject(this);

        transform.parent = kitchenObjectParents.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero; 
    }

    public IKitchenObjectParents GetKitchenObjectParents()
    {
        return kitchenObjectParents;
    }
}
