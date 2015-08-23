using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {
	private bool alive = true;
	private AudioSource audio;

	public float maxHealth = 100f;
	public float currentHealth;
	public AudioClip damageClip;
	public AudioClip dieClip;



	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		audio = GetComponent<AudioSource> ();
	}

	public void ReceiveDamage(float damage){
		if (!alive) {
			return;
		}
		currentHealth -= damage;
		SendMessage ("UpdateFloatingHealthBar",currentHealth/maxHealth, SendMessageOptions.DontRequireReceiver);
		SendMessage("HitBleed", SendMessageOptions.DontRequireReceiver);

		if (currentHealth <= 0) {
			alive = false;
			StartCoroutine (Die ());
		} else {
			audio.clip=damageClip;
			audio.Play ();
		}
	}

	private IEnumerator Die(){
        SendMessage("stopPermanently", SendMessageOptions.DontRequireReceiver);
		SendMessage ("DeadBleed", SendMessageOptions.DontRequireReceiver);
		audio.clip = dieClip;
		audio.Play ();
        if (tag == "Player" || tag == "Altar")
            GameObject.Find("GameManager").SendMessage("GameOver");
        else
        {
            GetComponent<Animator>().SetTrigger("Die");
            GameObject.Find("Player").SendMessage("CollectBlood", maxHealth);
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }
		
	}
}
