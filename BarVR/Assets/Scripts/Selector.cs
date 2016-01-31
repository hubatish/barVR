using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Provide in Editor support for clicking objects
/// </summary>
public class Selector : ZBehaviour
{
    public Selectable toSelect;
    public Shader shader;
    protected Shader startShader;

    private Renderer _renderer;
    protected Renderer mRenderer
    {
        get
        {
            if (_renderer == null)
            {
                _renderer = gameObject.GetComponentInChildren<Renderer>();
            }
            return _renderer;
        }
    }

    protected void Start()
    {
        startShader = mRenderer.material.shader;
    }

    protected void OnMouseEnter()
    {
        if (mRenderer.material.shader==shader)
        {
            return;
        }

        startShader = mRenderer.material.shader;
        if (shader != null)
        {
            mRenderer.material.shader = shader;
        }
    }

    protected void OnMouseExit()
    {
        mRenderer.material.shader = startShader;
    }

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
