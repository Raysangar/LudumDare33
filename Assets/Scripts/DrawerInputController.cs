using UnityEngine;
using System.Collections;

public class DrawerInputController : MonoBehaviour {
    private float raycastDistance;
    private bool sealStarted;
    private SealDrawer sealDrawer;
    private SealPatternChecker sealPatternChecker;

    [SerializeField]
    private LayerMask patternLayerMask;

    [SerializeField]
    private LayerMask sealLayerMask;

    

	// Use this for initialization
	void Start () {
        sealStarted = false;
        raycastDistance = 400;
        SetSeal(GameObject.Find("Seal"));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistance, patternLayerMask))
            {
                if (sealStarted == false)
                {
                    sealStarted = sealPatternChecker.sealStarted(hit.point);
                    Debug.Log(sealStarted);
                }
                
                if (sealStarted)
                    sealDrawer.drawOn(getTextureCoordinate());
            }
            else
                cancelSeal();
        }
        else if (sealStarted)
            finishSeal();
	}

    private void cancelSeal()
    {
        sealStarted = false;
        sealDrawer.setOriginalTexture();
    }

    private Vector2 getTextureCoordinate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, raycastDistance, sealLayerMask);
        return hit.textureCoord;
    }

    private void SetSeal(GameObject seal)
    {
        sealDrawer = seal.GetComponent<SealDrawer>();
        sealPatternChecker = seal.GetComponent<SealPatternChecker>();
    }

    private void finishSeal()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance, patternLayerMask))
            Debug.Log(sealPatternChecker.checkSealCompleted(hit.point));
        cancelSeal();
    }
}
