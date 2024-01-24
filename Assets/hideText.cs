using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnHideText(GameObject Object){
        Object.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
