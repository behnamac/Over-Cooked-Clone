using UnityEngine;

public interface IKitchenObjectParents 
{
    public Transform GetKitchenObjectFollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObjecy();

    public void ClearKitchenObject();

    public bool HasKitchenObject(); 

}
