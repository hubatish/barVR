using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Just a classic better monobehavior
/// 
///     Credit for _cachedComponents & general start goes to FlyClops (MonoBehavclops)
/// </summary>

public class ZBehaviour : MonoBehaviour 
{
	private Dictionary<Type,Component> _cachedComponents;

	public T Cached<T>() where T : Component
	{
		if (_cachedComponents == null) _cachedComponents = new Dictionary<Type,Component>();
		if (_cachedComponents.ContainsKey(typeof(T))) return (T)_cachedComponents[typeof(T)];
		T component = GetComponent<T>();
		_cachedComponents.Add(typeof(T),component);
		return component;
	}

    //special consideration for sprite, which can have a UI renderer or a 2D sprite renderer
    public virtual Sprite sprite
    {
        get
        {
            if (Cached<SpriteRenderer>() != null)
            {
                return Cached<SpriteRenderer>().sprite;
            }
            else if (Cached<Image>() != null)
            {
                return Cached<Image>().sprite;
            }
            return null;
        }
        set
        {
            if (Cached<SpriteRenderer>() != null)
            {
                Cached<SpriteRenderer>().sprite = value;
            }
            else if (Cached<Image>() != null)
            {
                Cached<Image>().sprite = value;
            }
        }
    }

    public virtual bool visible
    {
        get
        {
            if (Cached<SpriteRenderer>() != null)
            {
                return Cached<SpriteRenderer>().enabled;
            }
            else if (Cached<Image>() != null)
            {
                return Cached<Image>().enabled;
            }
            else if (Cached<Renderer>() != null)
            {
                return Cached<Renderer>().enabled;
            }
            return false;
        }
        set
        {
            if (Cached<SpriteRenderer>() != null)
            {
                Cached<SpriteRenderer>().enabled = value;
            }
            else if (Cached<Image>() != null)
            {
                Cached<Image>().enabled = value;
            }
            else if (Cached<Renderer>() != null)
            {
                Cached<Renderer>().enabled = value;
            }
        }
    }

    protected static bool _appIsQuitting = false;

    public virtual void OnApplicationQuit()
    {
        _appIsQuitting = true;
    } 
}
