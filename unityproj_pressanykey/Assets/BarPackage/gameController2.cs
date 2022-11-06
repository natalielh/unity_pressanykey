using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController2 : MonoBehaviour {

	//this script controls the meters and all camera effects attached to them

	private UnityStandardAssets.ImageEffects.BloomOptimized bloom;
	private UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration aberration;
	private UnityStandardAssets.ImageEffects.ColorCorrectionCurves colorcurves;
	private ColorCurvesManager colorChange;

	public KeyCode userKey;

	public Vector3 spawnValues;
	public int waveLength;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private float waveDuration;
	public float currentWave = 1;
	private int meterSelect = 1;

	public int meterMax;
	public int meterMin;

	public Text waveCountText;		//states the meter#

	[SerializeField]
	private Stat meter1;

	[SerializeField]
	private Stat meter2;

	[SerializeField]
	private Stat meter3;

	[SerializeField]
	private Stat meter4;

	[SerializeField]
	private Stat meter5;

	[SerializeField]
	private Stat meter6;

	private List<Stat> meters = new List<Stat>();

	public Text waveText1;
	public Text waveText2;
	public Text waveText3;
	public Text waveText4;
	public Text waveText5;
	public Text waveText6;

	public GameObject dust;

	public GameObject meterGroup;

	void Awake () {
		//needed to "get" values from Stat when game begins
		meters.Add(meter1);
		meters.Add(meter2);
		meters.Add(meter3);
		meters.Add(meter4);
		meters.Add(meter5);
		meters.Add(meter6);

		meter1.Initialize ();
		meter2.Initialize ();
		meter3.Initialize ();
		meter4.Initialize ();
		meter5.Initialize ();
		meter6.Initialize ();

		//gets components
		colorChange = Camera.main.GetComponent<ColorCurvesManager> ();
		bloom = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>();
		aberration = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();
		colorcurves = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>();

	}
		
	void Start () {

		//
		waveCountText.text = "Current Meter: " + meterSelect.ToString("0");

		foreach (Stat meter in meters)
		{
			meter.meterGameObject.SetActive(false);
		}
		meters[meterSelect - 1].meterGameObject.SetActive(true);

	}

	void Update () {
		//meter reset function
		if (Input.GetKeyDown (userKey)) {
			meter1.CurrentVal = 0;
			meter2.CurrentVal = 0;
			meter3.CurrentVal = 40;
			meter4.CurrentVal = 0;
			meter5.CurrentVal = 0;
			meter6.CurrentVal = 0;
			Camera.main.transform.localPosition = Vector3.zero;
		}

		//meter adjustment down
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (meterSelect == 1) meter1.CurrentVal -= 10;
			if (meterSelect == 2) meter2.CurrentVal -= 10;
			if (meterSelect == 3) meter3.CurrentVal -= 10;
			if (meterSelect == 4) meter4.CurrentVal -= 10;
			if (meterSelect == 5) meter5.CurrentVal -= 10;
			if (meterSelect == 6) meter6.CurrentVal -= 1;
		}


		//meter adjustment up
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (meterSelect == 1) meter1.CurrentVal += 10;
			if (meterSelect == 2) meter2.CurrentVal += 10;
			if (meterSelect == 3) meter3.CurrentVal += 10;
			if (meterSelect == 4) meter4.CurrentVal += 10;
			if (meterSelect == 5) meter5.CurrentVal += 10;
			if (meterSelect == 6) meter6.CurrentVal += 1;
		}

		//switch between meters
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (meterSelect < meterMax) {
				foreach (Stat meter in meters)
				{
					meter.meterGameObject.SetActive(false);
				}
				

				//meterGroup.transform.Translate(Vector3.down * ((meterSelect - meterSelect) + 78)); //predetermined distance to transform
				meterSelect += 1;

				meters[meterSelect - 1].meterGameObject.SetActive(true);
			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (meterSelect > meterMin) {
				foreach (Stat meter in meters)
				{
					meter.meterGameObject.SetActive(false);
				}
				

				//meterGroup.transform.Translate (Vector3.down * ((meterSelect - meterSelect) - 78));
				meterSelect -= 1;

				meters[meterSelect - 1].meterGameObject.SetActive(true);
			}
		}
		waveCountText.text = meterSelect.ToString("0");

		//displayed the numerical value atached to the meter
		waveText1.text = meter1.CurrentVal.ToString("0");
		waveText2.text = meter2.CurrentVal.ToString("0");
		waveText3.text = meter3.CurrentVal.ToString("0");
		waveText4.text = meter4.CurrentVal.ToString("0");
		waveText5.text = meter5.CurrentVal.ToString("0");
		waveText6.text = meter6.CurrentVal.ToString("0");

		//sets the bloom intensity to the value of meter1
		bloom.intensity = meter1.CurrentVal/40;
		//sets the aberration to the value of meter2
		aberration.chromaticAberration = meter2.CurrentVal;
		//sets the saturation to the value of meter3
		colorcurves.saturation = meter3.CurrentVal/20;
		//sets the timescale to the value of meter4
		Time.timeScale = meter4.CurrentVal/-133 + 1;
		//sets the color to the value of meter5
		colorChange.SetFactor (meter5.CurrentVal / 100);

		//sets the camera flag. Basically a bool done with an int
		if (meter6.CurrentVal == 0) {
			Camera.main.clearFlags = CameraClearFlags.SolidColor;
			dust.SetActive(true); 
		} else {
			Camera.main.clearFlags = CameraClearFlags.Nothing;
			dust.SetActive(false);
		}
			
	}

}
