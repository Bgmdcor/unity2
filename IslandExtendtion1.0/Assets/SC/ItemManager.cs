using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public Text scoreText;
	public Text scoreText2;
	public GameObject[] item;
	int num;
	public float Speed = 50;
	public GameObject CenterPos;
	public GameObject PanelOver;
	public GameObject PanelOver2;
	bool isShowPanel2;
	public AudioClip sound;
	public AudioClip sound2;
	AudioSource player;
	void Start(){
		player = gameObject.GetComponent<AudioSource> ();
		PlayerPrefs.SetInt ("over", 0);
		PlayerPrefs.SetInt ("score", 0);
	}
	void FixedUpdate () {
	    if (PlayerPrefs.GetInt ("over") == 0 && PlayerPrefs.GetInt("start")==1) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 1 * Time.deltaTime * Speed, 0);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
			
		if (col.gameObject.tag == "over") {
			Debug.Log ("Over");		
			player.PlayOneShot(sound2);
			PlayerPrefs.SetInt("over",1);
			Invoke("wait",0.75f);
		} else {					
			PlayerPrefs.SetInt ("score", PlayerPrefs.GetInt ("score") + 1);
			player.PlayOneShot(sound);
			if(PlayerPrefs.GetInt("score")> PlayerPrefs.GetInt("best")){

				PlayerPrefs.SetInt("best",PlayerPrefs.GetInt("score"));
			}
			num = Random.Range (0, 3);
			transform.position = item[num].transform.position;
			scoreText.text = PlayerPrefs.GetInt ("score").ToString();
			scoreText2.text = PlayerPrefs.GetInt ("best").ToString();

		}

	}

	void Update(){

		if (PlayerPrefs.GetInt ("over") == 1) {
			PanelOver.transform.position = Vector3.Lerp(PanelOver.transform.position,CenterPos.transform.position , Time.deltaTime * 2.5f);
			if(isShowPanel2){
				PanelOver2.transform.position = Vector3.Lerp(PanelOver2.transform.position,CenterPos.transform.position , Time.deltaTime * 2.5f);
			}
		}
	}

	void wait(){

		isShowPanel2 = true;
		Invoke ("wait2", 1.5f);
	}
	void wait2(){

		isShowPanel2 = false;
	}
}
