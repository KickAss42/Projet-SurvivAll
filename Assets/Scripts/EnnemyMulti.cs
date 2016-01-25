using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnnemyMulti : NetworkBehaviour {

	public GameObject Enemy;
	public GameObject SpawnLoc;

	void Spawn()
	{
		GameObject clone;
		clone = Network.Instantiate(Enemy, SpawnLoc.transform.position, Quaternion.identity, 0) as GameObject;
	}
	[Command]
	void CmdOnGUI(){
		if(Network.isServer || Network.isClient)
		{
			Spawn();
		}
	}
}
