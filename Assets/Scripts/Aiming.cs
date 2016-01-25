using UnityEngine;
using System.Collections;

public class Aiming : MonoBehaviour {

    public Vector3 NormalPos;
    public Vector3 AimPos;

	void Start () {
        transform.localPosition = NormalPos;
	}
	
	void Update () {
	    if(Input.GetButton("Fire2"))
        {
            transform.localPosition = AimPos;
        }

        if (!Input.GetButton("Fire2"))
        {
            transform.localPosition = NormalPos;
        }
    }
}
