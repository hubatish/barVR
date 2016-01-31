using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Effects : MonoBehaviour {

    public List<Action> effects = new List<Action>();

    public float sensitivity = 0.5f;

    protected void Start()
    {
        OVRCameraRig rig = Camera.main.transform.root.GetComponent<OVRCameraRig>();
        Action slowDown = delegate ()
        {
            rig.LookSensitivity.x -= sensitivity;
        };
        effects.Add(slowDown);
        Action speedUp = delegate ()
        {
            rig.LookSensitivity.y += sensitivity;
        };
        effects.Add(speedUp);
    }

    public void PerformEffect()
    {
        int r = UnityEngine.Random.Range(0, effects.Count);
        effects[r]();
    }
}
