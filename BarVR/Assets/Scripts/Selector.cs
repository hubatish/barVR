using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Provide in Editor support for clicking objects
/// </summary>
public class Selector : MonoBehaviour
{
    public Selectable toSelect;

    protected void OnMouseDown()
    {
        if (toSelect != null)
        {
            toSelect.Select();
        }
        else
        {
            toSelect = gameObject.GetComponent<Selectable>();
            toSelect.Select();
        }
    }
}
