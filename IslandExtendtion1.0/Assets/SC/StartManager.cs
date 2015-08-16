
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {


	public GameObject PanelStart;
	public GameObject TopPos;
	public GameObject TextScore;
	public GameObject BestScoreText;
	public GameObject Player;
	public bool IsMove;
	Color32 col;

	// Use this for initialization
	void Start () {
		col.a = 255;
		col.r = 59;
		col.g = 255;
		col.b = 255;
		col.a = 225;
		PlayerPrefs.SetInt ("start", 0);
		Invoke ("StartMove", 2f);
		Invoke ("StartPlay", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (col.a > 4) {
			col.a -= 4;
		}
		gameObject.GetComponent<Image> ().color = col;

		if (IsMove) {
		
			PanelStart.transform.position = Vector3.Lerp(PanelStart.transform.position,TopPos.transform.position,Time.deltaTime * 2f);
		
		}
	
	}

	void StartPlay(){


		TextScore.SetActive (true);
		Player.SetActive (true);
		BestScoreText.SetActive (true);
		PlayerPrefs.SetInt ("start", 1);
	}
	void StartMove(){
		IsMove = true;

	}
}
