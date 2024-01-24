using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsObjectSelected : MonoBehaviour
{
    public bool selected = false;

    public void setVariable(bool variable)
    {
        selected = variable;
    }
}
