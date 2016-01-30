using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Holding ingredients
///     Probably follow player around (parent to Camera)
/// </summary>
public class PlayerHand : MonoBehaviour
{
    public static PlayerHand Instance;

    protected void Awake()
    {
        Instance = this;
    }

    public Ingredient heldIngredient;

    public void Grab(Ingredient ingredient)
    {
        heldIngredient = ingredient;
        MoveTo(ingredient, transform);
    }

    public void MoveTo(Ingredient ingredient, Transform t)
    {
        //Should tween
        ingredient.transform.position = t.position;
        ingredient.transform.SetParent(t);
    }

    /// <summary>
    /// Drop an item to the reticle or last position
    /// </summary>
    public void DropIngredient()
    {
        //TODO: implement this
        throw new NotImplementedException();
    }

    public Ingredient Release()
    {
        if (heldIngredient == null)
        {
            return null;
        }
        var ingredient = heldIngredient;
        heldIngredient = null;
        ingredient.transform.SetParent(null);
        return ingredient;
    }
}
