using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleRun : People
{
    private Vector3 final;
    public float radius = 5;



    private void Flee()
    {
        if (agent.remainingDistance < 0.8f) 
        {




        // 隨機座標 = 隨機.球內隨機點 * 半徑 + 中心點座標
        Vector3 pointRan = Random.insideUnitSphere * radius + transform.position;
           

        // 導覽網格碰撞 碰撞點
        NavMeshHit hit;

        // 導覽網格.樣本座標(座標,碰撞點, 半徑,圖層)
        // out 執行方法會將結果直接儲存到傳入的參數內
        // 執行後會將取得的隨機點儲存在 hit 參數內


        NavMesh.SamplePosition(pointRan, out hit, radius, 1);



        // 最終座標 = 碰撞點.座標
         final = hit.position;


        //代理器.設定目的地 (座標)

        agent.SetDestination(final);
        }

    }

    private void Update()
    {
        Flee();
    }







}
