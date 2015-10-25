using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CalendarUI : MonoBehaviour {

	public Slider month;
	public Slider day;
	public Slider hour;
	public Toggle timeTick;
	public Slider oneDayMin;

	public TOD_Sky todSky;
	private TOD_Time todTime;

	public Text display;

	// Use this for initialization
	void Start () {

		if (todSky) {
			todTime = todSky.GetComponent<TOD_Time> ();

			month.value = todSky.Cycle.DateTime.Month;
			day.value = todSky.Cycle.DateTime.Day;
			hour.value = todSky.Cycle.DateTime.Hour;
			timeTick.isOn = todTime.ProgressTime;
			oneDayMin.value = todTime.DayLengthInMinutes;
		} else {
			Debug.Log ("This Calendar UI is ment to be used with Time of Day : http://modmonkeys.net/");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (todSky) {
			display.text = todSky.Cycle.DateTime.ToString ();
		}
	}

	public void DayLengthChanged(){
		int odm = (int)oneDayMin.value;
		bool tt = timeTick.isOn;

		if (todSky) {
			todTime.ProgressTime = tt;
//			todTime.ProgressDate = tt;
//			todTime.ProgressMoonPhase = tt;
			todTime.DayLengthInMinutes = odm;
		}
	}

	public void SetCurrentDateTime(){
		DateTime dt = DateTime.Now; 

		month.value = dt.Month;
		day.value = dt.Day;
		hour.value = dt.Hour;

		if (todSky) {
			todSky.Cycle.DateTime = dt;
		}
	}

	public void ValueUpdated(){
		print ("ValueUpdate");
		int m = (int)month.value;
		int d = (int)day.value;
		int h = (int)hour.value;

		if (todSky) {
			DateTime dt = DateTime.Now; 
			todSky.Cycle.DateTime = new DateTime (dt.Year, m, d, h, 0, 0);
		}

	}
}
