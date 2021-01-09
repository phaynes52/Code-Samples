using System;
using System.Collections;
using UnityEngine;

public static class Tween
{
    public static float GetEasedValue(float x, Easing easingFunction)
    {
        float c1 = 1.70158f;
        float c2 = c1 * 1.525f;
        float c3 = c1 + 1f;
        float c4 = (2f * Mathf.PI) / 3f;
        float c5 = (2f * Mathf.PI) / 4.5f;
        float n1 = 7.5625f;
        float d1 = 2.75f;


        switch (easingFunction)
        {
            case Easing.Linear:
                return x; // This one is the correct implementation. The rest you have to replace from the functions from easings.net
            case Easing.InSine:
                x = 1 - Mathf.Cos((x * Mathf.PI) / 2);
                return x;
            case Easing.OutSine:
                x = Mathf.Sin((x * Mathf.PI) / 2);;
                return x;
            case Easing.InOutSine:
                x = -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
                return x;
            case Easing.InQuad:
                x = x * x;
                return x;
            case Easing.OutQuad:
                x = 1 - (1 - x) * (1 - x);
                return x;
            case Easing.InOutQuad:
                x = (x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2);
                return x;
            case Easing.InCubic:
                x = x * x * x;
                return x;
            case Easing.OutCubic:
                x = 1 - Mathf.Pow(1 - x, 3);
                return x;
            case Easing.InOutCubic:
                x = (x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2);
                return x;
            case Easing.InQuart:
                x = x * x * x * x;
                return x;
            case Easing.OutQuart:
                x = 1 - Mathf.Pow(1 - x, 4);
                return x;
            case Easing.InOutQuart:
                x = (x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2);
                return x;
            case Easing.InQuint:
                x = x * x * x * x * x;
                return x;
            case Easing.OutQuint:
                x = 1 - Mathf.Pow(1 - x, 5);
                return x;
            case Easing.InOutQuint:
                x = (x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2);
                return x;
            case Easing.InExpo:
                x = (x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10));
                return x;
            case Easing.OutExpo:
                x = (x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x));
                return x;
            case Easing.InOutExpo:
                x = (x == 0
                        ? 0
                        : x == 1
                        ? 1
                        : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
                        : (2 - Mathf.Pow(2, -20 * x + 10)) / 2);
                return x;
            case Easing.InCirc:
                x = 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
                return x;
            case Easing.OutCirc:
                x = Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
                return x;
            case Easing.InOutCirc:
                x = (x < 0.5
                        ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
                        : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2);
                return x;
            case Easing.InBack:
                x = c3 * x * x * x - c1 * x * x;
                return x;
            case Easing.OutBack:
                x = 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
                return x;
            case Easing.InOutBack:
                x = (x < 0.5
                        ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
                        : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2);
                return x;
            case Easing.InElastic:
                x = (x == 0
                        ? 0
                        : x == 1
                        ? 1
                        : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4));
                return x;
            case Easing.OutElastic:
                x = ( x == 0
                        ? 0
                        : x == 1
                        ? 1
                        : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1);
                return x;
            case Easing.InOutElastic:
                x = (x == 0
                        ? 0
                        : x == 1
                        ? 1
                        : x < 0.5
                        ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2
                        : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1);
                return x;
            case Easing.InBounce:
                x = 1 - GetEasedValue((1 - x), Easing.OutBounce);
                return x;
            case Easing.OutBounce:
                if (x < 1 / d1) {
                        x = n1 * x * x;
                    } else if (x < 2f / d1) {
                        x =  n1 * (x -= 1.5f / d1) * x + 0.75f;
                    } else if (x < 2.5f / d1) {
                        x = n1 * (x -= 2.25f / d1) * x + 0.9375f;
                    } else {
                        x = n1 * (x -= 2.625f / d1) * x + 0.984375f;
                    }
                return x;
            case Easing.InOutBounce:
                x = (x < 0.5
                        ? (1 - GetEasedValue((1 - 2 * x), Easing.OutBounce) / 2)
                        : (1 + GetEasedValue((2 * x - 1), Easing.OutBounce) / 2));
                return x;
            default:
                return x;
        }
    }

    public enum Easing
    {
        Linear,
        InSine,
        OutSine,
        InOutSine,
        InQuad,
        OutQuad,
        InOutQuad,
        InCubic,
        OutCubic,
        InOutCubic,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InBack,
        OutBack,
        InOutBack,
        InElastic,
        OutElastic,
        InOutElastic,
        InBounce,
        OutBounce,
        InOutBounce,
    }


    /// <summary>
    /// Part of the Optional Tweening portion. Implement this function to automatically change a passed in value.
    /// To call this function, it will look like
    /// float x;
    /// StartCoroutine(Tween.ExecuteCoroutine((result) => x = result, startPosition.x, endPosition.x, time, Tween.Easing.Linear));
    /// </summary>
    /// <param name="callback"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="time"></param>
    /// <param name="easingFunction"></param>
    /// <returns></returns>
    public static IEnumerator ExecuteCoroutine(Action<float> callback, float start, float end, float time, Easing easingFunction)
    {
        // Your code here
        yield return null;
    }
}
