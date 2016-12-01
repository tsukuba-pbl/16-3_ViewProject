using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	/// ボタンをクリックした時の処理
	public void OnClick() {
		Debug.Log("Back Button click!");
		Application.LoadLevel("start_menu");
	}
}