using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSpawn : NetworkBehaviour {

    public GameObject go;
	[Command]
	void CmdFire () {
        NetworkServer.Spawn(go);	
	}
}
