using UnityEngine;
using System.Collections;

public class LaderClimbing : MonoBehaviour {

    public Transform CharController;
    public bool inside = false;
    public float height = 3.2f;
    private Player FPSInput;
    

    // Use this for initialization
    void Start ()
    {
        FPSInput = GetComponent<Player>() ;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inside == true && Input.GetKey("w"))
        {
            CharController.transform.position += Vector3.up / height;
        }
	}

    void OnTriggerEnter(Collider col)//entree echelle
    {
        if (col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = false;
            inside =! inside;
        }
    }
    void OnTriggerExit(Collider col)//sortie echelle
    {
        if (col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = true;
            inside = !inside;
        }
    }
}
