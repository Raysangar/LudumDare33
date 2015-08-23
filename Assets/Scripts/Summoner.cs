using UnityEngine;
using System.Collections;

public class Summoner : MonoBehaviour {
    [SerializeField]
    private GameObject player, demon;

    [SerializeField]
    private int bloodNeeded;

    [SerializeField]
    private float maximunTimeOnDemon;

    private float currentTimeOnDemon;
    public bool playerIsADemon;
	// Use this for initialization
	void Start () {
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
            }
        }
	}

    public int getNecessaryBlood()
    {
        return bloodNeeded;
    }

    public void summonDemon()
    {
        changeModel();
        playerIsADemon = true;
        currentTimeOnDemon = 0;
    }

    private void changeModel()
    {
        if (playerIsADemon)
        {
            player.GetComponent<HealthSystem>().currentHealth = demon.GetComponent<HealthSystem>().currentHealth;
            player.transform.position = demon.transform.position;
            player.transform.rotation = demon.transform.rotation;
            player.SetActive(true);
            demon.SetActive(false);
        }
        else
        {
            demon.GetComponent<HealthSystem>().currentHealth = player.GetComponent<HealthSystem>().currentHealth;
            demon.transform.position = player.transform.position;
            demon.transform.rotation = player.transform.rotation;
            player.SetActive(false);
            demon.SetActive(true);
        }
        //efectito chulo taquicuá?
    }
}
