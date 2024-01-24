using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITesting : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private Image img;
    private int id = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickMe()
    {
        Debug.Log("ClickMe");
    }

    public void ChangePanel()
    {
        if (id >= spriteList.Count)
        {
            id = 0;
        }

        img.sprite = spriteList[id];
        id++;
    }
}
