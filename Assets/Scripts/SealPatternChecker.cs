using UnityEngine;
using System.Collections;

public class SealPatternChecker : MonoBehaviour {
    [SerializeField]
    private Transform startingPoint, finishPoint;

    [SerializeField]
    private float thresHold = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool checkSealCompleted(Vector3 mousePoint)
    {
        return Vector3.Distance(mousePoint, finishPoint.position) <= thresHold;
    }

    public bool sealStarted(Vector3 mousePoint)
    {
        return Vector3.Distance(mousePoint, startingPoint.position) <= thresHold;
    }
}
