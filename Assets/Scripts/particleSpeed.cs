using UnityEngine;
using System.Collections;

public class particleSpeed : MonoBehaviour {
	
	public float fireSpeed = 3.45f;
	public float dustSpeed = 3.45f;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag("FireElements").GetComponent<ParticleSystem>().playbackSpeed = fireSpeed;
		GameObject.FindGameObjectWithTag("DustElements").GetComponent<ParticleSystem>().playbackSpeed = fireSpeed;}
	
	// Update is called once per frame
	void Update () {
	
	}
}
