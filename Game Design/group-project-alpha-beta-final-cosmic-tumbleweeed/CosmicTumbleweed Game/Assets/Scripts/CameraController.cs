using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraFollow = new Vector3(0,0,-10);
    public float xOffset = 0;
    public float yOffset = 0;
    public float smoothTime = 0.2f;
    public float ysmooth = 0.1f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Transform target = null; // What the camera should follow
    private float ylimit;
    private bool falling;
    private bool initialFall;
    public Rigidbody2D player;
    public Camera camera;
    private float cameraSize;
    private Vector3 scaleTmp;
    private bool fallingOff;
    private GameMaster gm;
    public Transform boy;
    public UnityEvent checkpoint;
    private float smoothFallSpeed;
    public float cameraExpansion;

    private void Start() {
        cameraSize = camera.orthographicSize;
    }


    //Called once every frame.
    private void LateUpdate()
    {
        //Set the offset from the player for the camera to follow
        cameraFollow.x = xOffset;
        cameraFollow.y = yOffset;


        if (target == null) return;
        //logic taken from https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html 

        //get the position to lerp toward
        Vector3 playerPosition = target.position + cameraFollow;

        //Lerp the camera toward the player
        Vector3 smoother = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothTime);
        smoother.y = Mathf.Lerp(transform.position[1],target.position.y + yOffset, ysmooth);

        if (target.position.y < (transform.position.y - 5.6)) fallingOff = true;

        //special cases for longer falls
        if (player.velocity.y == 0){
            if (smoother.y <= ylimit + 0.1) initialFall = false;
            fallingOff = false;
            smoothFallSpeed = ysmooth;
        }
        if (fallingOff)
        {
            smoothFallSpeed = Mathf.Lerp(smoothFallSpeed, 0.8f, 0.1f);
            smoother.y = Mathf.Lerp(transform.position[1],target.position.y + yOffset, smoothFallSpeed);
        };

        //set new camera location
        transform.position = smoother;
    }

    private void Update() {
        //Scale camera up to view more of the level
        scaleTmp = transform.localScale;

        if (Input.GetKey(KeyCode.J))
        { 
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,cameraExpansion, 0.05f);
            scaleTmp.x = camera.orthographicSize / cameraSize;
            scaleTmp.y = camera.orthographicSize / cameraSize;
            transform.localScale = scaleTmp;
        }

        else
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,cameraSize, 0.2f);
            scaleTmp.x = camera.orthographicSize / cameraSize;
            scaleTmp.y = camera.orthographicSize / cameraSize;
            transform.localScale = scaleTmp;
        }
    }
}
