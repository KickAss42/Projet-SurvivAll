using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSteup : NetworkBehaviour {

    [SerializeField] GameObject fpscam;
    [SerializeField] FirstPersonController scriptctrl;

    void Start ()
    {
        if(isLocalPlayer)
        {
            fpscam.SetActive(true);
            scriptctrl.enabled = true;
        }

	}
}
