using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    private const string IS_WALKING = "IsWalking";

    private void Awake()
    {
        if (!animator)
            animator = GetComponentInChildren<Animator>();
        if (!player)
            player = GetComponent<Player>();
    }

    private void Update()
    {
        PlayAnimation();
    }


    private void PlayAnimation()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }




}
