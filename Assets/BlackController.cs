using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackController : MonoBehaviour
{
    Image image;
    bool fading;
    float alpha = 0;
    public float fadingSpeed = 0.01f;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;

        if (fading)
            alpha = Mathf.Min(0.5f, alpha + fadingSpeed);
    }

    public void fadeOut()
    {
        fading = true;
        alpha = 0;
    }
}
