using UnityEngine;
using System.Collections;

public class OSTController : MonoBehaviour {

	public AudioClip demonClip;
	public AudioClip ambientMusic;

	private AudioSource source;

	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource> ();

	
	}


	public void PlayDemonMusic()
	{
		source.clip = demonClip;
		source.Play ();
	}

	public void PlayAmbientMusic()
	{
		source.clip = ambientMusic;
		source.Play ();
	}

}
