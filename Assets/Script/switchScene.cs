using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {

    }

    public string sceneName;

    public void ChangementScene()
    {
        SceneManager.LoadScene(sceneName);
    }


}
