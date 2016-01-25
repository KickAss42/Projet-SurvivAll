using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

    public float bulletLife;

	void Start () {
        DestroyObject(gameObject, bulletLife);
	}

}
