using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class items{
    public string Description;
    public bool status = false;
}
public class TODO : MonoBehaviour
{
    [SerializeField] private List<items> items;
}
