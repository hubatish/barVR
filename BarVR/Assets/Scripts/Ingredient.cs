using UnityEngine;
using System.Collections;
using System;

public class Ingredient : Selectable {

    public override bool Equals(object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }

        // If parameter cannot be cast to Point return false.
        Ingredient c = obj as Ingredient;
        if ((System.Object)c == null)
        {
            return false;
        }

        string otherName = c.ToString();
        string myName = ToString();
        return myName == otherName;
    }

    public override void Select()
    {
        PlayerHand.Instance.Grab(this);
    }

    public override string ToString()
    {
        return StripString(gameObject.name);
    }

    protected string StripString(string s)
    {
        return s.Trim().Trim(new char[] { '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
    }

    public override int GetHashCode()
    {
        return StripString(gameObject.name).GetHashCode();
    }
}

