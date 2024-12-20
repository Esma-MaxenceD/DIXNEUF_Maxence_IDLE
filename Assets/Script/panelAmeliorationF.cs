using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelAmeliorationF : MonoBehaviour
{

    public Animator animator;
    public int spawn = 0;

    // Start is called before the first frame update
    public void spawnPanelF()
    {
        if (spawn == 0)
        {
            Debug.Log("Spawn");
            animator.SetInteger("spawn", 1);
            spawn = 1;
        }
        else
        {
            if (spawn == 1)
            {
                Debug.Log("Despawn");
                animator.SetInteger("spawn", 0);
                spawn = 0;




            }
        }
    }

    
}
