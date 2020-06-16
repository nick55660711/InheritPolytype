using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // 引用 系統.查詢語言 Lin Query


public class PeopleTrack : People
{
    protected Transform target;

    public People[] people;
    public float[] distance;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "火球")
            Dead();


    }



    protected virtual void Track()
    {

        for (int i = 0; i < people.Length; i++)
        {
            if (people[i] == null || people[i].name == "殭屍" || people[i].name == "警察") 
            {
                distance[i] = 999;
                continue; // 繼續 -  跳過並執行下一次迴圈 
            }
            distance[i] = Vector3.Distance(transform.position, people[i].transform.position);

        }

        float min = distance.Min(); // min = 距離.最小值
        int index = distance.ToList().IndexOf(min); // index = 距離.轉清單().取得索引值(min)
        target = people[index].transform; // 目標 = 人類[index].變形

        agent.SetDestination(target.position);

        transform.LookAt(target);

        if (agent.remainingDistance <= 1.2f && Time.timeSinceLevelLoad > 0.1f) HitPeople();

        print("最近的距離" + distance.Min());

    }

    private void HitPeople()
    {

        target.GetComponent<People>().Dead();

    }






    protected virtual void Start()
    {

        people = FindObjectsOfType<People>();
        distance = new float[people.Length];

        agent.SetDestination(Vector3.zero);

    }

    private void Update()
    {

        Track();

    }





}
