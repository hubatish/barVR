using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PreparationStation : BaseStation
{
    //Animator anim;
    // int boilhash = Animator.StringToHash("shake");
    public GameObject animEffect;
    public Ingredient product;

    public PrepMethod method;
    public UITimer timer;

    protected void Start()
    {
        // anim = GetComponent<Animator>();
        if (animEffect == null)
        {
            animEffect = GameObject.Find("HolyFireStrike");
        }
        if (animEffect != null)
        {
            animEffect.SetActive(false);
        }
        timer.done = FinishPrep;
    }

    public override void UseIngredients()
    {
        //They clicked while have ingredients in Station
        if (animEffect != null)
        {
            animEffect.SetActive(true);
        }
        timer.StartTimer();
    }

    public float prepTime = 2f;

    public void FinishPrep()
    {
        // anim.SetTrigger(boilhash);

        product = MasterIngredientList.Instance.CombineIngredients(curIngredients, method);
        product.transform.position = ingredientSpots[0].position;

        Debug.Log("Done prepping!"+product.name);

        Vector3 towardsZero = (Camera.main.transform.position - transform.position).normalized;
        towardsZero.y += 0.2f;
        product.GetComponent<Rigidbody>().AddForce(towardsZero * 0.3f);

        ClearIngredients();
        if (animEffect != null)
        {
            animEffect.SetActive(false);
        }
    }
}
