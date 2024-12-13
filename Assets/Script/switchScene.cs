using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator switchBoutiqueForet;
    public int Scene = 0;





    public void ChangementScene()
    {
        if (Scene == 0)
        {
            Debug.Log("Spawn");
            switchBoutiqueForet.SetInteger("Scene", 1);
            Scene = 1;
        }
        else
        {
            if (Scene == 1)
            {
                Debug.Log("Despawn");
                switchBoutiqueForet.SetInteger("Scene", 0);
                Scene = 0;




            }
        }


    }
}