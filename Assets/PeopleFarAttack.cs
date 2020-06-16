using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleFarAttack : PeopleTrack
{
    [Header("停止距離"), Range(1, 10)]
    public float stop = 3f;
    [Header("子彈")]
    public GameObject bullet;
    public float timer;
    public float cd = 1.5f;

    protected override void Track()
    {
        agent.SetDestination(target.position);
        if (agent.remainingDistance <= stop) Attack();
        transform.LookAt(target);

    }

    private void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= cd)
        {
            timer = 0;
            ani.SetTrigger("攻擊");
            GameObject temp = Instantiate(bullet, transform.position + transform.right * 0.5f + transform.forward * 0.5f + transform.up * 0.8f, transform.rotation);
            Rigidbody rig = temp.AddComponent<Rigidbody>();
            rig.AddForce(transform.forward * 500);
            Destroy(temp, 5f);
        }

    }







    protected override void Start()
    {
        agent.stoppingDistance = stop;
        target = GameObject.Find("殭屍").transform;
    }


}
