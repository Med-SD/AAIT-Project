using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public float timing = 0f;
    public TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timing > 0f)
        {
            displayText.text = $"waiting for {(int)timing} s";
            timing -= Time.deltaTime;
        }
    }

    public void NewFile()
    {
        Debug.Log("NewFile");
    }
}
