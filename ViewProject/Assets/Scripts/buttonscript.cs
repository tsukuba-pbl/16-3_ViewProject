using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class buttonscript : MonoBehaviour {

	public InputField inputfield;

	public void ButtonPush() {
		string input = inputfield.text;
		int m = -1;
		try
		{
			m = Int32.Parse(input);
		}
		catch (FormatException e)
		{
			Console.WriteLine(e.Message);
		}
		if (m < 0) {
			Debug.Log ("不正な値です");
		} else {
			Debug.Log ("Layout ID = " + m);
			GV.demo_layout_id = m;
			Application.LoadLevel("Main_Android");
		}
	}
}
