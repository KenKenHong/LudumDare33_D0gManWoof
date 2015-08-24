using UnityEngine;
using System.Collections;

public class Outline : MonoBehaviour
{
    public float alpha;

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Color temp = renderer.color;
        renderer.color = new Color(temp.r, temp.g, temp.b, alpha);
    }
}
