using DG.Tweening;
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
        if (heldIngredient != null)
        {
            //derp, git change
            ReleaseWithForce();
        }
        heldIngredient = ingredient;
        heldIngredient.GetComponent<Rigidbody>().useGravity = false;
        heldIngredient.GetComponent<Collider>().enabled = false;
        MoveTo(ingredient, transform);
    }

    public void MoveTo(Ingredient ingredient, Transform t)
    {
        MoveTo(ingredient, t, delegate () { });
    }

    public void MoveTo(Ingredient ingredient, Transform t, TweenCallback callback)
    {
        //Should tween
        //ingredient.transform.position = t.position;
        ingredient.GetComponent<Rigidbody>().DOMove(t.position, 1f).OnComplete(callback);
        ingredient.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
        heldIngredient.GetComponent<Rigidbody>().useGravity = true;
        heldIngredient.GetComponent<Collider>().enabled = true;
        heldIngredient = null;
        ingredient.transform.SetParent(null);
        return ingredient;
    }

    public float force = 8f;

    protected void ReleaseWithForce()
    {
        Ingredient i = Release();
        i.GetComponent<Rigidbody>().AddForce(transform.root.forward * force, ForceMode.Impulse);
    }

    [SerializeField]
    protected Ingredient startIngredient;

    protected void MouseDown()
    {
        if (heldIngredient != null && startIngredient==heldIngredient)
        {
            ReleaseWithForce();
        }
        startIngredient = heldIngredient;
    }

    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown();
        } else if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    protected void MouseUp()
    {
    }
}
