using UnityEngine;
using System.Collections;

public class LoadFurniture : MonoBehaviour {
	private string path = "https://salty-fortress-26407.herokuapp.com/layouts/1.json";

	// Use this for initialization
	IEnumerator Start () {

		using(WWW www = new WWW(path)){

			yield return www;

			if(!string.IsNullOrEmpty(www.error)){

				Debug.LogError("www Error:" + www.error);
				yield break;

			}

			Debug.Log(www.text);
			/*
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

			//全天球画像の表示
			GameObject instance = Instantiate (Resources.Load ("SphereMovie")) as GameObject;
			instance.transform.position = cameraPos;
			*/
		}
	}
}
