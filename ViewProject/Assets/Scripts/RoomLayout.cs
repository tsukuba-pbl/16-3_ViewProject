using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class RoomLayout : MonoBehaviour {

	//喫煙室enpit用
	//private string path = "https://salty-fortress-26407.herokuapp.com/uxsers/21.json";
	//private string path = "https://salty-fortress-26407.herokuapp.com/uxsers/23.json";
	private string path = null;

	//軽量全天周画像
	//private string path = "https://salty-fortress-26407.herokuapp.com/uxsers/20.json";

	public static string url = null;

	//カメラオブジェクト
	public GameObject MainCamera;

	void Start () {
		
	}

	public void SetImageId(int id){
		this.path = "https://salty-fortress-26407.herokuapp.com/uxsers/" + id.ToString() + ".json";
		Debug.Log ("SetImagePath = " + path);
	}

	public void SetImage(){
		StartCoroutine ("LoadImage");
	}

	// Use this for initialization
	IEnumerator LoadImage () {

		using(WWW www = new WWW(path)){

			yield return www;

			if(!string.IsNullOrEmpty(www.error)){

				Debug.LogError("www Error:" + www.error);
				yield break;

			}

			Debug.Log(www.text);
			var jsonDict = Json.Deserialize(www.text) as Dictionary<string,object>;
			Debug.Log("id = " + jsonDict["id"]);
			Debug.Log("gazo_url = " + jsonDict["gazo_url"]);
			url = jsonDict ["gazo_url"].ToString ();

			var jsonDict2 = jsonDict ["zahyo"] as Dictionary<string,object>;
			Debug.Log("x = " + jsonDict2["x"]);
			Debug.Log("y = " + jsonDict2["y"]);
			Debug.Log("z = " + jsonDict2["z"]);
			Debug.Log("offset = " + jsonDict["offset"]);

			//カメラの位置を変更
			float x = float.Parse(jsonDict2["x"].ToString());
			float y = float.Parse(jsonDict2["y"].ToString());
			float z = float.Parse(jsonDict2 ["z"].ToString());
			Vector3 cameraPos = new Vector3(x, y, z);
			SetCameraPos (cameraPos);

			//全天球画像のの回転角度
			float offset = float.Parse(jsonDict["offset"].ToString());

			//全天球画像の表示
			GameObject instance = Instantiate (Resources.Load ("SphereMovie")) as GameObject;
			instance.transform.position = cameraPos;
			Vector3 rot = new Vector3 (270.0f, offset, 0.0f);
			instance.transform.Rotate (rot);
		}
	}

	void SetCameraPos(Vector3 p){
		MainCamera.transform.position = p;
	}
}
