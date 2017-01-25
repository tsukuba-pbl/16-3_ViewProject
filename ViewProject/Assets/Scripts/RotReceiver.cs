using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Threading;
using DG.Tweening;

public class RotReceiver : MonoBehaviour {
	WebSocket ws;
	public Text hoge ;
	public int huga;
	public string piyo;
	private Thread m_Thread;
	private Regex reg;
	private bool fuga = false;
	private Quaternion plpl;
	private Quaternion qqq;
	private string str;
	public GameObject objA;
	public float timeOut;
	private float timeElapsed;
	// Use this for initialization
	void Start () {
		timeOut = 0.1f;
		reg = new Regex ("sssss");
		bool ui = reg.IsMatch("111111aa");
		Debug.Log (ui);
		Debug.Log ("111111");
		huga = 0;
		hoge = GetComponent<Text> ();
		m_Thread = new Thread(threadWork);

		qqq = transform.rotation;
		str = qqq.w.ToString () + "j" + qqq.x.ToString () + "j" + qqq.y.ToString () + "j" + qqq.z.ToString () + "j";
		m_Thread.Start ();
		plpl = transform.rotation;
	}

	// Update is called once per frame
	void Update () {

		timeElapsed += Time.deltaTime;

		if(timeElapsed >= timeOut) {
			// Do anything
			string[] stAD = str.Split ('j');
			float wqq = float.Parse (stAD[0]);
			float xqq = float.Parse (stAD[1]);
			float yqq = float.Parse (stAD[2]);
			float zqq = float.Parse (stAD[3]);
			plpl = new Quaternion(xqq,yqq,zqq,wqq);
			objA.transform.DORotate (plpl.eulerAngles, 0.1f).SetEase(Ease.Linear);
			Debug.Log ("qqqggggggggggggggggggggggggggggggq");
			timeElapsed = 0.0f;
		}
	}

	void OnApplicationQuit(){
		m_Thread.Abort ();
		Debug.Log ("qqqqqqqqqqqqqqqqqq");
	}

	private void threadWork(){
		Debug.Log ("ggggggggggggggg");

		try{
			ws = new WebSocket("ws://boiling-ridge-83772.herokuapp.com/");
			ws.Connect();
			Debug.Log ("pppppppppppppppppppp");
			ws.OnMessage += (sender, e) => 
			{
				Debug.Log("aaa" + e.Data);
				huga = huga + 1;
				Debug.Log(huga);
				bool ui = reg.IsMatch(e.Data);

				str = e.Data;

				if(ui){
					fuga = true;
					Debug.Log("aaaaaaafffffff");
				}

			};

		}catch(System.InvalidOperationException){

		}
	}
}