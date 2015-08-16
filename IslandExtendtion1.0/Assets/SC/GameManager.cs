using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	int n ,y ;    // n = num y = score
	public GameObject[] p,t;  
	public GameObject panelOver;
	public GameObject panelOver2;
	public GameObject TopPos;
	public Text scoreText;
	public AudioClip sound;
	AudioSource player;
	void Start(){

		player = gameObject.GetComponent<AudioSource> ();
	}

	public void L(){ 
		player.PlayOneShot (sound);
		E (0);				   	 
	}
	public void R(){   //123  
		player.PlayOneShot (sound);
		E (1);
	}  
	void E(int s){   //103 
		A (n, 1);  //91
		if (s == 0) {
			if (n < 2)  //75    
				n++; 
		} else {
		    if (n > 0)  
				n--;		
		}
		A (n,0);
	}
	void A(int h ,int i){      //38
			p [h].SetActive (i==0);  
	}
	public void OnClickedRestart(){
		scoreText.text = "0";
		PlayerPrefs.SetInt ("over", 0);
		PlayerPrefs.SetInt ("score", 0);
		t[0].gameObject.transform.position = new Vector3(t[0].transform.position.x,5f,transform.position.z);
		t[1].gameObject.transform.position = new Vector3(t[1].transform.position.x,7.5f,transform.position.z);
		t[2].gameObject.transform.position = new Vector3(t[2].transform.position.x,10f,transform.position.z);
		t[3].gameObject.transform.position = new Vector3(t[2].transform.position.x,12.5f,transform.position.z);

	}
	void Update(){

		if (PlayerPrefs.GetInt ("over") == 0) {
		
			panelOver.transform.position = Vector3.Lerp(panelOver.transform.position,TopPos.transform.position,Time.deltaTime * 2f);
			panelOver2.transform.position = Vector3.Lerp(panelOver2.transform.position,TopPos.transform.position,Time.deltaTime * 2f);
		}
	}
}
