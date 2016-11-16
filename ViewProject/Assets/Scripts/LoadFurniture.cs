using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

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

			//Debug.Log(www.text);

			//受信した家具配置情報をパースする
			var jsonDict = Json.Deserialize(www.text) as Dictionary<string,object>;
			var jsonDict2 = jsonDict["contents"] as  Dictionary<string,object>;
			int idLayout = int.Parse(jsonDict2 ["layout_id"].ToString ()); //レイアウトIDの格納
			//Debug.Log (idLayout);

			//家具の種類と座標をパースし，配置する
			List<object> list = (List<object>)jsonDict2 ["placed_furniture_items"];
			for (int i = 0; i < list.Count; i++) {
				var test = ((List<object>)jsonDict2 ["placed_furniture_items"]) [i] as Dictionary<string,object>;
				//回転成分の格納
				float a = float.Parse(test ["a_rotation"].ToString());
				float b = float.Parse(test ["b_rotation"].ToString());
				float c = float.Parse(test ["c_rotation"].ToString());
				Debug.Log ("Rotation = (" + a + "," + b + "," + c + ")");
				//座標成分の格納
				float x = float.Parse(test ["x_coordinate_data"].ToString());
				float y = float.Parse(test ["y_coordinate_data"].ToString());
				float z = float.Parse(test ["z_coordinate_data"].ToString());
				Debug.Log ("Position = (" + x + "," + y + "," + z + ")");
				//家具の種別の格納
				int furniture_item_id = int.Parse(test ["furniture_item_id"].ToString());
				Debug.Log ("item id = " + furniture_item_id);
			}

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
