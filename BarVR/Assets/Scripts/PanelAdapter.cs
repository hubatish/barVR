using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelAdapter : MonoBehaviour {

    public Color A = Color.magenta;
    public Color B = Color.blue;
    public float speed = 1.0f;
    private Image col;
    //SpriteRenderer spriteRenderer;

    void Start()
    {
        col = gameObject.GetComponent<Image>();
        //spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    void Update()
    {
        col.color = Color.Lerp(A, B, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
