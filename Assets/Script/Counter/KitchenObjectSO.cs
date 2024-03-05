using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="KitchenObject",menuName ="Data")]
public class KitchenObjectSO : ScriptableObject
{
    public string ObjectName;
    public Sprite Sprite;
    public Transform Prefab;
}
