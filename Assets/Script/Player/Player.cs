using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParents
{
    public static Player Instance;

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter SelectedCounter;
    }

    [SerializeField] private float speed;

    [SerializeField] private LayerMask counterLayerMask;

    [SerializeField] private GameInput input;

    [SerializeField] private Transform kitchenObjectHolderPoint;
    private KitchenObject currentKitchenObject;

    private bool isWalking;
    private Vector3 moveDir;
    private float moveDistance;
    private Vector3 lastDirection;
    private BaseCounter selectedCounter;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one player");
        }

        Instance = this;
    }

    private void Start()
    {
        input.OnIntractionAction += GameInputIntraction;
    }

    private void OnDisable()
    {
        input.OnIntractionAction -= GameInputIntraction;
    }

    private void GameInputIntraction()
    {
        if (!selectedCounter)
            return;

        selectedCounter.Interact(this);
    }

    private void Update()
    {
        CheckMoveDirecrion();
        HandleInteraction();
    }



    private void CheckMoveDirecrion()
    {
        Vector2 inputVector = input.GetMovementVectorNormalize();

        moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        moveDistance = speed * Time.deltaTime;

        var playerHeight = 2f;
        var playerRadius = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up *
             playerHeight, playerRadius, moveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up *
           playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up *
                        playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                    moveDir = moveDirZ;
                else
                {
                    //I can not move
                }
            }
        }
        if (canMove)
        {
            Movement();
        }


    }

    private void Movement()
    {
        moveDistance = speed * Time.deltaTime;
        transform.position += moveDir * moveDistance;

        isWalking = moveDir != Vector3.zero;
        if (!isWalking) return;
        float speedRotate = 10f * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, speedRotate);
    }



    public bool IsWalking()
    {
        return isWalking;
    }




    private void HandleInteraction()
    {
        Vector2 inputVector = input.GetMovementVectorNormalize();
        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastDirection = moveDir;
        }
        float interactionDistance = 2;
        if (Physics.Raycast(transform.position, lastDirection, out RaycastHit raycast, interactionDistance, counterLayerMask))
        {
            if (raycast.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);

                }
            }
            else
            {
                SetSelectedCounter(null);
            }

        }
        else
        {
            SetSelectedCounter(null);
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 origin = new Vector3(transform.position.x, moveDir.x, transform.position.z);
        Gizmos.DrawLine(transform.position, origin);
    }

    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            SelectedCounter = selectedCounter
        });
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHolderPoint;
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
