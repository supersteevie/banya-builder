using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public bool mouseScroll = true;
	public bool keyboardScroll = true;
	public float mapLength = 40;
	public float digLength = 0;
	public float smooth = 5f;

	void Start()
	{
		digLength = Mathf.Sqrt(mapLength * mapLength + mapLength * mapLength);
	}

	void Update () {

			if(keyboardScroll)
			{
				if(Input.GetKey(KeyCode.W))
					{
						if(Mathf.Abs(transform.position.x) + Mathf.Abs (transform.position.z  + 15f) <= digLength)
							transform.Translate(new Vector3(0,0,1));
					}
				if(Input.GetKey(KeyCode.A))
					{
						if(Mathf.Abs(transform.position.x   - 5f) + Mathf.Abs (transform.position.z) <= digLength)
							transform.Translate(new Vector3(-1,0,0));
					}
				if(Input.GetKey(KeyCode.S))
					{
						if(Mathf.Abs(transform.position.x) + Mathf.Abs (transform.position.z - 1f) <= digLength)
							transform.Translate(new Vector3(0,0,-1));
					}
				if(Input.GetKey(KeyCode.D))
					{
						if(Mathf.Abs(transform.position.x  + 5f) + Mathf.Abs (transform.position.z) <= digLength)
							transform.Translate(new Vector3(1,0,0));
					}

				if(Input.GetKey(KeyCode.Q))
					{
					if(transform.rotation.eulerAngles.y < 89f)
						transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 89, 0), .05f);;
					}

				else if(Input.GetKey(KeyCode.E))
					{
						if(transform.rotation.eulerAngles.y > 1f)
							transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 1, 0), .05f);
					}
			
				else transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), .05f);
				
			}
			
			if(mouseScroll)
			{
				if(Input.mousePosition.y > Screen.height*.9f)
					{
						if(Mathf.Abs(transform.position.x) + Mathf.Abs (transform.position.z  + 15f) <= digLength)
							transform.Translate(new Vector3(0,0,1));
					}
				if(Input.mousePosition.x < Screen.width*.1f)
					{
						if(Mathf.Abs(transform.position.x   - 5f) + Mathf.Abs (transform.position.z) <= digLength)
							transform.Translate(new Vector3(-1,0,0));
					}
				if(Input.mousePosition.y < Screen.height*.1f)
					{
						if(Mathf.Abs(transform.position.x) + Mathf.Abs (transform.position.z - 1f) <= digLength)
							transform.Translate(new Vector3(0,0,-1));
					}
				if(Input.mousePosition.x > Screen.width*.9f)
					{
						if(Mathf.Abs(transform.position.x  + 5f) + Mathf.Abs (transform.position.z) <= digLength)
							transform.Translate(new Vector3(1,0,0));
					}
			}

			if (Input.GetAxis ("Mouse ScrollWheel") < 0) { // back
				if(GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition.z <= 0)
					GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(new Vector3(0,0,1));
				
				}
			if (Input.GetAxis ("Mouse ScrollWheel") > 0) { // forward
			if(GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition.z >= -10)
				GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(new Vector3(0,0,-1));

			print (GameObject.FindGameObjectWithTag("MainCamera").transform.position.z);
			
		}
	}
}
