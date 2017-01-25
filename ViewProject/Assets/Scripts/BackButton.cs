using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("Back Button click!");
		Application.LoadLevel("start_menu");

		GameObject objRotSender = GameObject.Find("RotSender") as GameObject;
		RotSender RS = objRotSender.GetComponent<RotSender> ();
		RS.ThreadAbort ();
	}
}