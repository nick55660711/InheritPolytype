﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("遊戲場景");

        }

    }
}
