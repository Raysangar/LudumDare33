using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {

	public float swordDamage = 10;
	public Collider swordTrigger;
	AudioSource audio;
	public AudioClip attackClip;



	void Start()
	{
		audio = GetComponent<AudioSource> ();

	}
	public void EnableSwordTrigger(){
        Debug.Log("dadsa");
		audio.clip=attackClip;
		audio.Play();
		swordTrigger.enabled = true;
	}

	public void DisableSwordTrigger(){
        Debug.Log("dasdsa");
		swordTrigger.enabled = false;
	}

	public void ApplySwordDamage(Collider other){
        Debug.Log("dadsadsadsadadsdas");
		if (other.GetComponent<HealthSystem> () != null) {
			other.GetComponent<HealthSystem> ().ReceiveDamage (swordDamage);
		}
	}

}
