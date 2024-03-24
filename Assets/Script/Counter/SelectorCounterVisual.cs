using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] selectedVisual;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        foreach (var item in selectedVisual)
        {

            item.SetActive(false);
        }
    }

    private void Show()
    {
        foreach (var item in selectedVisual)
        {

            item.SetActive(true);
        }
    }
}
