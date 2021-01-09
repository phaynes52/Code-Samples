using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should not be modified by the student.
/// </summary>
public class CameraParallaxTest : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 20f)]
    private float speed = 5f;

    [SerializeField]
    [Range(0f, 5f)]
    private float jumpAmplitude = 1f;

    [SerializeField]
    [Range(0f, 20f)]
    private float jumpFrequency = 5f;


    // Local var references
    Vector3 targetPos;
    float yOffset;

    private void Update()
    {
        yOffset = jumpAmplitude * Mathf.Clamp01(Mathf.Sin(2f * Mathf.PI * jumpFrequency * Time.time));
        targetPos.x += speed * Time.deltaTime;
        targetPos.y = yOffset;
        transform.position = targetPos;
    }
}
