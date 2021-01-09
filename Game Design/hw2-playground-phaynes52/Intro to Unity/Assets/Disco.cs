using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disco : MonoBehaviour
{
    //These are the Sliders that control the values. Remember to attach them in the Inspector window.
    public Slider m_SliderHue, m_SliderSaturation, m_SliderValue;

    //Determines if sliders should be rising or falling
    public bool hueRise;
    public bool satRise;
    public bool valRise;

    //Make sure your GameObject has a Renderer component in the Inspector window
    Renderer m_Renderer;

    void Start()
    {
        //Fetch the Renderer component from the GameObject with this script attached
        m_Renderer = GetComponent<Renderer>();

        //Set the maximum and minimum values for the Sliders
        m_SliderHue.maxValue = 1;
        m_SliderSaturation.maxValue = 1;
        m_SliderValue.maxValue = 1;

        m_SliderHue.minValue = 0;
        m_SliderSaturation.minValue = 0;
        m_SliderValue.minValue = 0;

		m_SliderHue.value = 0f;
        m_SliderSaturation.value = 0.5f;
        m_SliderValue.value = 0.3f;

        hueRise = true;
        satRise = true;
        valRise = true;
    }

    void Update()
    {

    	//Vary hue
 
 		if (hueRise == true) {
 			m_SliderHue.value = m_SliderHue.value + 0.001f;

 			if (m_SliderHue.value > 0.95f) {
 				hueRise = false;
 			}
 		}

 		else if (hueRise == false) {
 			 	m_SliderHue.value = m_SliderHue.value - 0.001f;

 			if (m_SliderHue.value < 0.05f) {
 				hueRise = true;
 			}
 		}


 		//Vary saturation
        
        if (satRise == true) {
 			m_SliderSaturation.value = m_SliderSaturation.value + 0.01f;

 			if (m_SliderSaturation.value > 0.95f) {
 				satRise = false;
 			}
 		}

 		else if (satRise == false) {
 			 	m_SliderSaturation.value = m_SliderSaturation.value - 0.01f;

 			if (m_SliderSaturation.value < 0.05f) {
 				satRise = true;
 			}
 		}

 		//vary Value

 		if (valRise == true) {
 			m_SliderValue.value = m_SliderValue.value + 0.1f;

 			if (m_SliderValue.value > 0.95f) {
 				valRise = false;
 			}
 		}

 		else if (valRise == false) {
 			 	m_SliderValue.value = m_SliderValue.value - 0.1f;

 			if (m_SliderValue.value < 0.05f) {
 				valRise = true;
 			}
 		}


        //Create an RGB color from the HSV values from the Sliders
        //Change the Color of your GameObject to the new Color
        m_Renderer.material.color = Color.HSVToRGB(m_SliderHue.value, m_SliderSaturation.value, m_SliderValue.value);
    }
}
