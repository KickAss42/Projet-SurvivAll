using UnityEngine;
using System.Collections;

public class BulletHole : MonoBehaviour
{

    public GameObject bullethole;
    public GameObject[] blood;
    public float delayTime = 0.5f;
    private float counter = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd * 10, Color.green);

        if (Input.GetButton("Fire1") && Time.time >= counter)
        {
            counter = Time.time + delayTime;

            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, 900000f))
            {
                if (hit.collider.tag == "Enemy")
                {
                    Instantiate(blood[Random.Range(0, 16)], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
                else
                {
                    Instantiate(bullethole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }
        }
    }
}
