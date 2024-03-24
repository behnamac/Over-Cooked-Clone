using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounterVisual : MonoBehaviour
{
    [SerializeField] private CountainerCounter countainer;
    private Animator anim;
    private const string OPEN_CLOSE = "OpenClose";


    private void Awake()
    {
        anim = GetComponent<Animator>();
        countainer.OnPlayerGrabbedObject += CountainerCounter_OnPlayerGrabbedObject;
    }

    private void OnDisable()
    {
        countainer.OnPlayerGrabbedObject -= CountainerCounter_OnPlayerGrabbedObject;
    }

    private void CountainerCounter_OnPlayerGrabbedObject()
    {
        anim.SetTrigger(OPEN_CLOSE);
    }
}
