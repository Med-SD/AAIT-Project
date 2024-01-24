using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum Repitation
{
    once,
    muliti,
}

public class Following
{
    public int order;
    public Repitation repitation;
    public List<GameObject> gameObjects = new List<GameObject>();
    public TextMeshProUGUI txt;
}


public class Steps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
