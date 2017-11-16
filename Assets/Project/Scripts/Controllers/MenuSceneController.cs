using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {


    public void OnStart()
    {
        SceneManager.LoadScene("Level1");
    }


}
