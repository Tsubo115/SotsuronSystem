using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance;

    //高難易度コード
    public int[] DiffChord = new int[3];
    
    //エリート個体
    public int[] elicp = new int[8];

    void Awake()
    {
        //初めのみゲームオブジェクトが破壊されないように設定
        if (instance == null)
        {
            instance = this;
 
            //データの初期化
 
            Debug.Log("Don't destroy this gameObject!");
            DontDestroyOnLoad(gameObject);  //シーン変更時，指定オブジェクトを破壊しないように設定
        }
        //複数instanceが存在した場合破壊
        else
        {
            Debug.Log("Prevent multiple instances");
            Destroy(gameObject);  //複数存在するのを防ぐため破壊
        }
    }
    //Date.instance.BNB
}
