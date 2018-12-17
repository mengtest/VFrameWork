using System.Collections;
using UnityEngine;
using VFrameWork.Utils;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Debug.Log(Utils.resolutionUtil.GetAspectRatio());
	}

	private void Awake()
	{
	
	}
	// Update is called once per frame
}
