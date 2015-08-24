using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SummonAreaController : MonoBehaviour {
    private bool playerOnSummonArea;
    private BloodCollector bloodCollector;
    private Summoner summoner;

    [SerializeField]
    private Text textHint;

    [SerializeField]
    private GameObject hint;

	// Use this for initialization
	void Start () {
        playerOnSummonArea = false;
        hint.SetActive(false);
        bloodCollector = GameObject.Find("Player").GetComponent<BloodCollector>();
        summoner = GameObject.Find("Altar").GetComponent<Summoner>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerOnSummonArea && !summoner.playerIsADemon)
        {
            textHint.text = (bloodCollector.maxBloodForSummon <= bloodCollector.currentBloodForSummon) ?
                "Press Space to Summon the Demon" : "Collect Blood for Summoning the Demon";
            if (bloodCollector.currentBloodForSummon >= bloodCollector.maxBloodForSummon && Input.GetButtonDown("Use"))
            {
                summoner.summonDemon();
                bloodCollector.UseBlood(bloodCollector.currentBloodForSummon);
            }
            hint.SetActive(true);
        }
        else
            hint.SetActive(false);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 10)
            playerOnSummonArea = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == 10)
            playerOnSummonArea = false;
    }
}