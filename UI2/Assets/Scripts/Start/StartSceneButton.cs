using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    public void OnClickStartButton(){
        SceneManager.LoadScene("Input(new)"); //IGASceneを呼び出す
    }
}
