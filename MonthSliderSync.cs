using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonthSliderSync : MonoBehaviour
{

	public Slider monthSlider;

	// Use this for initialization
	void Awake ()
	{ 
		
		slider = GetComponent<Slider> ();
		Adjust ();
	}

	void Adjust ()
	{
		int v = (int)monthSlider.value;
		if (v == 2) {
			slider.maxValue = 28;
			return;
		}
		
		if (v >= 8) {
			v -= 1;
		}
		if (v % 2 == 1) {
			slider.maxValue = 31;
		} else {
			slider.maxValue = 30;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetValue (float f)
	{
		Adjust ();
	}
}
