using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodCollector : MonoBehaviour {

	public Text bloodCounter;
	public Slider summonBar;

	public float scoreBlood;

	public float currentBloodForSummon;
	public float maxBloodForSummon;


    [SerializeField]
    private GameObject movingArrow;
	[SerializeField]
	private Animator bloodBar;


	// Use this for initialization
	void Start () {
        movingArrow.SetActive(false);
	}



	public void CollectBlood(float blood){
		scoreBlood += blood;
		currentBloodForSummon += blood;

		if (currentBloodForSummon > maxBloodForSummon) {
			currentBloodForSummon = maxBloodForSummon;
		}

		UpdateSummonBar ();
		UpdateCounter ();
	}

	public void UseBlood(float blood){
		currentBloodForSummon = 0;
		UpdateSummonBar ();
	}

	private void UpdateCounter(){
		bloodCounter.text = scoreBlood.ToString ();
	}

	private void UpdateSummonBar(){
		summonBar.value = currentBloodForSummon / maxBloodForSummon;
        activateSummonBarAnimationIfNeeded(summonBar.value);
	}

    private void activateSummonBarAnimationIfNeeded(float value)
    {
        if (value == 1 && summonBar.gameObject.activeInHierarchy)
        {
            movingArrow.SetActive(true);

        }
        else
        {
            movingArrow.SetActive(false);
        }
    }

    public void resetBar()
    {
        currentBloodForSummon = 0;
        UpdateSummonBar();
    }
}
