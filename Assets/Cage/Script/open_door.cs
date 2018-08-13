using UnityEngine;
using System.Collections;

public class open_door : MonoBehaviour {


public Texture2D myCursor; // cursor texture
public int id; 
int cursorSizeX = 48;  // set to width of your cursor texture
int cursorSizeY = 48;  // set to height of your cursor texture
public bool condition = true;
	GameObject thedoor;

void Start (){
		id = 0;
	}

void OnMouseEnter (){
	condition = false;
	//show the cursor when it is detected
	//Screen.showCursor = true;
}

void OnMouseExit (){
	condition = true;
	//hide cursor
   	//Screen.showCursor = false;
}

void OnGUI (){
    // display custom cursor
	if(!condition){
    GUI.DrawTexture ( new Rect(Input.mousePosition.x-cursorSizeX/2+ cursorSizeX/2, (Screen.height-Input.mousePosition.y)-cursorSizeY/2+ cursorSizeY/2, cursorSizeX, cursorSizeY),myCursor);
    }
}

void OnMouseDown (){
id++;
	
	thedoor= GameObject.FindWithTag("cage_door");
	
if (id == 1){
		thedoor.GetComponent<Animation>().Play("open_door");
	 }
			 
	 else if (id == 2){
		id = 0;
		thedoor.GetComponent<Animation>().Play("close_door");
			
	 }
		
}

 
}