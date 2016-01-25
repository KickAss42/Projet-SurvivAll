using UnityEngine;
using System.Collections;

public class MobMouve : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent agent;
    public static string nomObj;
    Animator anim;
    private bool fin = false;
    public static bool danger = false;

    public GameObject[] destinations;

    void Awake()
    {
        nomObj = "point1";
        agent = GetComponent<NavMeshAgent>();
        GameObject centre = GameObject.Find(nomObj);
        target = centre.transform;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        NavMeshPath path = new NavMeshPath();
        agent.destination = target.position;
    }

    void Update()
    {

        if (!Mob.isDead)
        {
            if (danger)
            {
                setNewDestination("point2");
            }

            else if (agent.pathStatus == NavMeshPathStatus.PathComplete &&
                agent.remainingDistance <= 0.5f)
            {
                anim.SetBool("isWalking", false);
                if (fin == false)
                {
                    fin = true;
                    string dest = destinations[Random.Range(0, destinations.Length)].name;
                    setNewDestination(dest);
                }
            }

        }
    }

    void setNewDestination(string d)
    {
        nomObj = d;
        GameObject centre = GameObject.Find(nomObj);
        target = centre.transform;
        anim.SetBool("isWalking", true);
        NavMeshPath path = new NavMeshPath();
        agent.destination = target.position;
        fin = false;
    }
}