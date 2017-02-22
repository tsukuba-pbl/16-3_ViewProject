using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("Back Button click!");
		Application.LoadLevel("Demo_mainmenu");

		GameObject objRotSender = GameObject.Find("RotSender") as GameObject;
		RotSender RS = objRotSender.GetComponent<RotSender> ();
		RS.ThreadAbort ();
	}
}