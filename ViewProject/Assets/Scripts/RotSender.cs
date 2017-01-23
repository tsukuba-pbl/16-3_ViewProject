using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Threading;

public class RotSender : MonoBehaviour {
	WebSocket ws;
	public GameObject objCam;
	private Quaternion qqq;
	private string str;
	private Thread m_Thread;
	public int huga;
	private Regex reg;
	private bool fuga = false;
	// Use this for initialization
	void Start () {
		reg = new Regex ("sssss");
		m_Thread = new Thread(threadWork);
		m_Thread.Start ();
	}

	// Update is called once per frame
	void Update () {
		qqq = objCam.transform.rotation;
		str = qqq.w.ToString () + "j" + qqq.x.ToString () + "j" + qqq.y.ToString () + "j" + qqq.z.ToString () + "j";
		if (fuga) {
			Debug.Log ("rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr");
			GameObject setfurnobj = GameObject.Find("SetFurniture");
			LoadFurniture loader = setfurnobj.GetComponent<LoadFurniture> ();
			loader.clearlayout ();
			loader.reloadlayout ();
			fuga = false;
		}
	}

	void OnApplicationQuit(){
		ws.Close ();
		m_Thread.Abort ();
		Debug.Log ("qqqqqqqqqqqqqqqqqq");
	}
	private void threadWork(){
		Debug.Log ("ggggggggggggggg");

		try{
			ws = new WebSocket("ws://boiling-ridge-83772.herokuapp.com/");
			ws.Connect();
			Debug.Log ("pppppppppppvvvvvvvvvvvvvvvvvvvvvvppppppppp");
			ws.OnMessage += (sender, e) => 
			{
				Debug.Log("aaa" + e.Data);
				bool ui = reg.IsMatch(e.Data);
				if(ui){
					fuga = true;
					Debug.Log("aaaaaaafffffff");
				}

			};

		}catch(System.InvalidOperationException){

		}

		while (true) {
			ws.Send(str);
			Thread.Sleep (100);
		}
	}
}