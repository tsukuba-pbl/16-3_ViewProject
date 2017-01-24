﻿using UnityEngine;
using System.Collections;
using MiniJSON;
using System.Collections.Generic;

public class LoadFurniture : MonoBehaviour {
	private string path = "https://salty-fortress-26407.herokuapp.com/ft_layouts/last.json";

	private List<GameObject>furnitureInstanceList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		reloadlayout ();
	}

	public void reloadlayout(){
		StartCoroutine ("loadlayout");
	}

	public void clearlayout(){
		for (int i = 0; i < furnitureInstanceList.Count; i++) {
			GameObject.Destroy (furnitureInstanceList[i]);
		}
		furnitureInstanceList = new List<GameObject>();
		Debug.Log ("aaaaaaaaaaaaaaaaaaaaaa");
	}

	public IEnumerator loadlayout(){
			using (WWW www = new WWW (path)) {

				yield return www;

				if (!string.IsNullOrEmpty (www.error)) {

					Debug.LogError ("www Error:" + www.error);
					yield break;

				}

				Debug.Log(www.text);

				//受信した家具配置情報をパースする
				var jsonDict = Json.Deserialize (www.text) as Dictionary<string,object>;
				var jsonDict2 = jsonDict ["contents"] as  Dictionary<string,object>;
				int idLayout = int.Parse (jsonDict2 ["layout_id"].ToString ()); //レイアウトIDの格納

				//天球画像のidを取得
				int gazo_id = int.Parse(jsonDict2["gazo_id"].ToString());
				Debug.Log ("gazo_id = " + gazo_id);
				GameObject RoomLayout_instance = GameObject.Find ("RoomLayout");
				RoomLayout rl = RoomLayout_instance.GetComponent<RoomLayout> ();
				rl.SetImageId (gazo_id);
				rl.SetImage ();

				//全天球画像の配置
				GameObject tenkyu_instance = Instantiate (Resources.Load ("RoomLayout")) as GameObject;

			if (GV.bFurniture == true) {
				//家具の種類と座標をパースし，配置する
				List<object> list = (List<object>)jsonDict2 ["placed_furniture_items"];
				for (int i = 0; i < list.Count; i++) {
					var test = ((List<object>)jsonDict2 ["placed_furniture_items"]) [i] as Dictionary<string,object>;

					//回転成分の格納
					float x = float.Parse (test ["top"].ToString ());
					float y = 0.0f;
					float z = float.Parse (test ["left"].ToString ());
					Debug.Log ("Position = (" + x + "," + y + "," + z + ")");
					//回転成分の格納
					float a = 0.0f;
					float b = float.Parse (test ["deg"].ToString ());
					float c = 0.0f;
					Debug.Log ("Rotation = (" + a + "," + b + "," + c + ")");
					//家具の種別の格納
					int furniture_item_id = int.Parse (test ["furniture_item_id"].ToString ());
					Debug.Log ("item id = " + furniture_item_id);

					//家具のロードと配置
					GameObject instance = null;
					string furniture_name = null;
					switch (furniture_item_id) {
					case 1:
						furniture_name = "Chair";
						break;
					case 2:
						furniture_name = "table";
						break;
					case 3:
						furniture_name = "Glass_table";
						break;
					case 4:
						furniture_name = "bed1";
						break;
					case 5:
						furniture_name = "bed2";
						break;
					case 6:
						furniture_name = "sek";
						break;
					case 7:
						furniture_name = "bed3";
						break;
					case 8:
						furniture_name = "bed5";
						break;
					case 9:
						furniture_name = "Bookself1";
						break;
					case 10:
						furniture_name = "table3";
						break;
					case 11:
						furniture_name = "sofa1";
						break;
					case 12:
						furniture_name = "TV";
						break;
					default:
						furniture_name = null;
						break;
					}
					if (furniture_name != null) {
						instance = Instantiate (Resources.Load (furniture_name)) as GameObject;
						furnitureInstanceList.Add (instance);
						Vector3 p = new Vector3 (x, y, z);
						instance.transform.position = p;
						instance.transform.rotation = Quaternion.Euler (a, b, c);
					}
				}
			}
		}
	}
}
