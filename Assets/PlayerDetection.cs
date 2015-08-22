using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 10)
            transform.parent.SendMessage("PlayerDetected", collider.gameObject);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == 10)
            transform.parent.SendMessage("PlayerOutOfRange", collider.gameObject);
    }
}
