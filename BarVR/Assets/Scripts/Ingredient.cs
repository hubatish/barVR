﻿using UnityEngine;
using System.Collections;
using System;

public class Ingredient : Selectable {

    public Combination formingCombination = null;

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

        if(formingCombination == null || formingCombination.ingredients.Count==0)
        {
            string otherName = c.ToString();
            string myName = ToString();

            return myName == otherName;
        }
        else if (c.formingCombination == null)
        {
            return false;
        }
        else
        {
            return c.formingCombination.Equals(formingCombination);
        }
    }

    public Action onSelect = delegate () { };

    public override void Select()
    {
        onSelect();
        PlayerHand.Instance.Grab(this);
    }

    public override string ToString()
    {
        string sName = StripString(gameObject.name);
        string dumbString = "Clone";
        if (sName.Contains(dumbString))
        {
            int cloneStart = sName.IndexOf(dumbString);
            sName.Remove(cloneStart,dumbString.Length);
        }
        return sName;
    }

    public void ClearAll()
    {
        for(int i= transform.childCount-1; i>=0;i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
        Selector selector = GetComponent<Selector>();
        if (selector != null)
        {
            Destroy(selector);
        }
        gameObject.SetActive(false);
    }

    protected string StripString(string s)
    {
        var toRemove = new char[] { '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        string newS = s.Trim();
        foreach(var c in toRemove)
        {
            //should probably remove multiple ones
            int loc = newS.IndexOf(c);
            if (loc >= 0)
            {
                newS = newS.Remove(loc);
            }
        }
        return newS;
    }

    public override int GetHashCode()
    {
        return StripString(gameObject.name).GetHashCode();
    }
}

