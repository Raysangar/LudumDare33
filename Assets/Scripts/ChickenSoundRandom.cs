using UnityEngine;
using System.Collections;

public class ChickenSoundRandom : MonoBehaviour {


	public AudioClip[] clips;
	private AudioSource source;

	private float randomTime;
	private int randomClip;


	// Use this for initialization
	void Start () {
	
		source = this.GetComponent<AudioSource> ();
		PlaySound ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlaySound()
	{
		randomClip = Random.Range (0, clips.Length);
		source.clip = clips [randomClip];
		randomTime = Random.Range (3f, 8f);
		source.Play ();
		Invoke ("PlaySound", randomTime);
	}
}
