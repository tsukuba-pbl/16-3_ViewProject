using UnityEngine;
using System.Collections;

public class SampleButtonController : BaseButtonController
{

	void Start() {

	}

	protected override void OnClick(string objectName)
	{
		// 渡されたオブジェクト名で処理を分岐
		//（オブジェクト名はどこかで一括管理した方がいいかも）
		if ("Button1".Equals(objectName))
		{
			// Button1がクリックされたとき
			this.Button1Click();
		} 
		else if ("Button2".Equals(objectName))
		{
			// Button2がクリックされたとき
			this.Button2Click();
		}
		else
		{
			throw new System.Exception("Not implemented!!");
		}
	}

	private void Button1Click()
	{
		Debug.Log("Button1 Click");
		GV.bFurniture = false;
		Application.LoadLevel("Main_Android");

	}

	private void Button2Click()
	{
		Debug.Log("Button2 Click");
		GV.bFurniture = true;
		Application.LoadLevel("Main_Android");
	}
}