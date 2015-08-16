using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CopyText : MonoBehaviour {
	
	public Text MomText;
	public Text ChildText;
	public Text ChildText2;
	
	void Update () {
		
		ChildText.text = MomText.text;
	}
}
