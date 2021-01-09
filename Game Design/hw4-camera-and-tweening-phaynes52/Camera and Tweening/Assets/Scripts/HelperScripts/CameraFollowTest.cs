using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should not be modified by the student.
/// </summary>
public class CameraFollowTest : MonoBehaviour
{
    private List<Vector2> targetPoints;
    private const float targetRadius = 10f;
    
    // Local var references
    float t;
    Vector2 startPos;
    Vector2 targetPos;

    private void Start()
    {
        targetPoints = new List<Vector2>();
        for (int i = 0; i < 256; i++)
        {
            targetPoints.Add(Random.insideUnitCircle * targetRadius);
        }

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            t = 0f;
            startPos = transform.position;
            targetPos = targetPoints[Random.Range(0, targetPoints.Count)];
            while (t < 1f)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, t);
                t += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(Random.Range(0f, 2f));
            transform.position = targetPos;
        }
    }
}
