using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {

	public bool text = false;
	public string Text;
	public Texture aTexture;

	public int textWidth = 500;
	public int textHeight = 100;

	void OnTriggerEnter2D(Collider2D other)
	{
		print ("collision");
		if(other.gameObject.tag == "Player"){
			print ("collision Panda");
			text = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		print ("collision");
		if(other.gameObject.tag == "Player"){
			print ("collision Panda");
			text = false;
		}
	}

	void OnGUI () 
	{
		if (text == true) 
		{
			GUI.DrawTexture (new Rect(Screen.width/2 - (textWidth/2), Screen.height/4 - (textHeight/2), textWidth, textHeight), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
			GUI.Label(new Rect(Screen.width/2 - (textWidth/2), Screen.height/4 - (textHeight/2), textWidth, textHeight), Text);
		}
	}
}
