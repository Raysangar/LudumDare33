using UnityEngine;
using System.Collections;

public class Summoner : MonoBehaviour {
    [SerializeField]
    private GameObject player, demon, lightning, demonModeCamera;

    [SerializeField]
    Animator lightningAnimation;


    [SerializeField]
    ParticleSystem smoke;

    [SerializeField]
    private float maximunTimeOnDemon;

    private float currentTimeOnDemon;
    public bool playerIsADemon;
	// Use this for initialization
	void Start () {
        demonModeCamera.SetActive(false);
        playerIsADemon = false;
        currentTimeOnDemon = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerIsADemon)
        {
            currentTimeOnDemon += Time.deltaTime;
            if (currentTimeOnDemon >= maximunTimeOnDemon)
            {
                changeModel();
                playerIsADemon = false;
                currentTimeOnDemon = 0;
                demonModeCamera.SetActive(false);
				Camera.main.SendMessage("PlayAmbientMusic");
				//DESTRANSFORMAR DEMONIO, CAMBIAr MÚSICA
            }
        }
	}

    public void summonDemon()
    {
        changeModel();
        playerIsADemon = true;
        currentTimeOnDemon = 0;
        demonModeCamera.SetActive(true);
		Camera.main.SendMessage("PlayDemonMusic");
	}

    private void changeModel()
    {
        if (playerIsADemon)
        {
            player.GetComponent<HealthSystem>().updateLifeBar(demon.GetComponent<HealthSystem>().currentHealth);
            BloodCollector bloodCollector = player.GetComponent<BloodCollector>();
            bloodCollector.resetBar();
            bloodCollector.scoreBlood = demon.GetComponent<BloodCollector>().scoreBlood;
            bloodCollector.summonBar.gameObject.SetActive(true);
            player.transform.position = demon.transform.position;
            player.transform.rotation = demon.transform.rotation;
            player.SetActive(true);
            demon.SetActive(false);
        }
        else
        {
            demon.GetComponent<HealthSystem>().updateLifeBar(player.GetComponent<HealthSystem>().currentHealth);
            demon.GetComponent<BloodCollector>().scoreBlood = player.GetComponent<BloodCollector>().scoreBlood;
            player.GetComponent<BloodCollector>().summonBar.gameObject.SetActive(false);
            demon.transform.position = player.transform.position;
            demon.transform.rotation = player.transform.rotation;
            player.SetActive(false);
            demon.SetActive(true);
        }
        StartCoroutine("InvokeTheDemon");
    }

    private IEnumerator InvokeTheDemon()
    {
        lightning.SetActive(true);
        smoke.Play();
        lightningAnimation.SetTrigger("Lightning");
        yield return new WaitForSeconds(0.25f);
        lightning.SetActive(false);
        
    }
}
