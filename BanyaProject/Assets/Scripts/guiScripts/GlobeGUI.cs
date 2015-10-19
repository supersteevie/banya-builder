using UnityEngine;
using System.Collections;

public class GlobeGUI : MonoBehaviour {

	public float rotationSpeed = 10.0f;
	public float lerpSpeed = 1.0f;
	private bool dragging;

	private Vector3 speed;
	private Vector3 avgSpeed;
	private Vector3 targetSpeedX;

		//User has clicked on globe to move it around
		void OnMouseDown() 
		{
			dragging = true;
		}
		
		void Update () 
		{
			//Globe rotates according to user
			if (Input.GetMouseButton(0) && dragging) {
				speed = new Vector3(-Input.GetAxis ("Mouse X"), Input.GetAxis("Mouse Y"), 0);
				avgSpeed = Vector3.Lerp(avgSpeed,speed,Time.deltaTime * 5);
			} else {
				if (dragging) {
					speed = avgSpeed;
					dragging = false;
				}
				float i = Time.deltaTime * lerpSpeed;
				speed = Vector3.Lerp( speed, Vector3.zero, i);   
			}
			
			transform.Rotate( Camera.main.transform.up * speed.x * rotationSpeed, Space.World );
			transform.Rotate( Camera.main.transform.right * speed.y * rotationSpeed, Space.World );
			
		//Globe rotates on own when it's lost all friction from rotating from user
		if (speed.x <= 1 && speed.y <= 1)
			transform.Rotate(0, Time.smoothDeltaTime, 0, Space.Self);
			
		}

}
