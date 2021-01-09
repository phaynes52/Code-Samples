using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float duration = 1f;
    public Tween.Easing easingFunction;

    public float offset;
    float y;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
        offset = 0f;
        t = 0f;
    }

    // Called every frame
    private void Update()
    {
        offset = Mathf.LerpUnclamped(y, y - 5f, Tween.GetEasedValue(t, easingFunction));

        if (t < 1f)
        {
            transform.position = new Vector3(transform.position.x, offset);
            t += Time.deltaTime / duration;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, y - 5f);
            t = 1f;
        }
    }
}
