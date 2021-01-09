using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenPlatforms : MonoBehaviour
{
    public static bool SetTopLeft = true;
    public static bool SetTopRight = true;
    public static bool SetBottomLeft = true;
    public static bool SetBottomRight = true;
    public bool TopLeft;
    public bool TopRight;
    public bool BottomLeft;
    public bool BottomRight;
    public bool closePath;

    void Awake() {
        if (TopLeft == true) {
            this.gameObject.SetActive(SetTopLeft);
            if (closePath == true) this.gameObject.SetActive(!SetTopLeft);
        }
        if (TopRight == true) {
            this.gameObject.SetActive(SetTopRight);
            if (closePath == true) this.gameObject.SetActive(!SetTopRight);
        }
        if (BottomLeft == true) {
            this.gameObject.SetActive(SetBottomLeft);
            if (closePath == true) this.gameObject.SetActive(!SetBottomLeft);
        }
        if (BottomRight == true) {
            this.gameObject.SetActive(SetBottomRight);
            if (closePath == true) this.gameObject.SetActive(!SetBottomRight);
        }

    }

    private IEnumerator open(int quadrant){
        if ( quadrant == 0) {
            if (TopLeft == true) {
                if (closePath == true) this.gameObject.SetActive(true);
                else this.gameObject.SetActive(false);
                SetTopLeft = false;
            }
        }

        if ( quadrant == 1) {
            if (TopRight == true) {
                this.gameObject.SetActive(false);
                if (closePath == true) this.gameObject.SetActive(true);
                SetTopRight = false;
            }
        }

        if ( quadrant == 2) {
            if (BottomLeft == true) {
                this.gameObject.SetActive(false);
                if (closePath == true) this.gameObject.SetActive(true);
                SetBottomLeft = false;
            }
        }

        if ( quadrant == 3) {
            if (BottomRight == true) {
                this.gameObject.SetActive(false);
                if (closePath == true) this.gameObject.SetActive(true);
                SetBottomRight = false;
            }
        }
        
        return null;
    }

    public void onEnter(int quadrant){
        StartCoroutine(open(quadrant));
    }
}
