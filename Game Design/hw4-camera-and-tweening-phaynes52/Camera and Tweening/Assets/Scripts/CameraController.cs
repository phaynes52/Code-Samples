using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraFollow = new Vector3(0,0,-10);
    public float xOffset = 0;
    public float yOffset = 0;
    public float smoothTime = 0.4f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Transform target = null; // What the camera should follow
    

    //Called once every frame.
    private void LateUpdate()
    {
        cameraFollow.x = xOffset;
        cameraFollow.y = yOffset;
        if (target == null) return;
        //logic taken from https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html 
        Vector3 playerPosition = target.position + cameraFollow;
        Vector3 smoother = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothTime);
        transform.position = smoother;
    }
}
