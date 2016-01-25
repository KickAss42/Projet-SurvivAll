using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    void Start()
    {
        Destroy(this.gameObject, 4);
    }

}
