using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using UnityEngine;


public enum Repetend
{
    Multi,
    Once
}

[Serializable]
public class MyObjet
{
    public string name;
    public AudioClip clip;
    public Repetend repetend;
    public bool status = false;
}

[CreateAssetMenu(menuName ="Scenario")]
public class CheckList : ScriptableObject
{
    public List<MyObjet> list = new List<MyObjet>();
}
