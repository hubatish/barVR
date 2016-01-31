using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Effects : MonoBehaviour
{
    public List<Action> effects = new List<Action>();

    AudioSource[] sounds;

    public float sensitivity = 0.5f;

    protected void Start()
    {
        sounds = GetComponents<AudioSource>();
        OVRCameraRig rig = Camera.main.transform.root.GetComponent<OVRCameraRig>();
        sounds[0].volume = 0;

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
        Action heartBeat = delegate ()
        {
            sounds[0].volume = 1;
            sounds[1].volume = 0;

            StartCoroutine(alterSound());
        };
        effects.Add(heartBeat);
    }

    public void PerformEffect()
    {
        int r = UnityEngine.Random.Range(0, effects.Count);
        effects[r]();
    }

    IEnumerator alterSound() {
        yield return new WaitForSeconds(2);
        sounds[1].volume = 0.1f;
        sounds[0].volume = 0;
    }
}
