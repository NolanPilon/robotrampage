using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private string robotType;
    public int health;
    public int range;
    public float fireRate;
    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float timeLastFired;
    private bool isDead;
    public Animator robot;
    [SerializeField]
    GameObject missileprefab;
    void Start()
    {
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) 
        {
            return;
        }

        transform.LookAt(player);
        agent.SetDestination(player.position);

        if (Vector3.Distance(transform.position, player.position) < range && Time.time - timeLastFired > fireRate) 
        {
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire() 
    {
        GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
    }
}
