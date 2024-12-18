using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GetScore : MonoBehaviour
{
    public IGA iga;

    //各ドロップダウンを取得
    public TMP_Dropdown dd1;
    public TMP_Dropdown dd2;
    public TMP_Dropdown dd3;
    public TMP_Dropdown dd4;
    public TMP_Dropdown dd5;
    public TMP_Dropdown dd6;

    //各ボタン
    public GameObject NextGenButton;
    public GameObject GoConSkillButton;

    //カウント
    int count = 1;
    public TextMeshProUGUI countText;

    //chord progression(度数のみ，M行N列)
    public int[,] cp;

    //エリート個体
    public int[] elitecp = new int[8];
    public int elite;


    void Start()
    {
        cp = new int[iga.M, iga.N];

        //初期解生成
        iga.initial(cp);
    }


    public void OnClickNextGen()
    {
        //各スコアを取得
        int[] rank = new int[iga.M];
        
        //valueの値は0スタートのため + 1
        rank[0] = dd1.value + 1;
        rank[1] = dd2.value + 1;
        rank[2] = dd3.value + 1;
        rank[3] = dd4.value + 1;
        rank[4] = dd5.value + 1;
        rank[5] = dd6.value + 1;

        //GA実行
        iga.GAmain(rank, cp);


        // for (int i = 0;i < cp.GetLength(0);i++)
        // {
        //     for (int j = 0; j < cp.GetLength(1); j++)
        //     {
        //         Debug.Log(cp[i, j]);
        //     }
        // }

        //カウント表示
        count++;
        countText.SetText("Generation {0}", count);

        //ドロップダウンの表示をリセット
        dd1.value = 0;
        dd2.value = 0;
        dd3.value = 0;
        dd4.value = 0;
        dd5.value = 0;
        dd6.value = 0;

        //10世代目で次フェーズへ
        if(count == 10){
            NextGenButton.SetActive(false);
            GoConSkillButton.SetActive(true);
        }
    }


    public void OnClickGoConSkill()
    {
        //最終世代のvalueを配列に保存
        int[] musicvalue = {dd1.value, dd2.value, dd3.value, dd4.value, dd5.value, dd6.value}; 
        // for(int i = 0; i < 6; i++){
        //     Debug.Log(musicvalue[i]);
        // }

        //musicvalueを降順にソート
        var sortedIndices = musicvalue
            .Select((value, index) => new { Value = value, Index = index })
            .OrderByDescending(x => x.Value)
            .Select(x => x.Index)
            .ToArray();

        //エリート個体の番号を保存
        elite = sortedIndices[0];

        //エリート個体を保存
        for(int i = 0; i < cp.GetLength(1); i++){ //cpの2次元の要素数分回す
            elitecp[i] = cp[elite, i];

            //エリート個体をDataに保存
            Data.instance.elicp[i] = elitecp[i];
        }

        // for(int i = 0; i < 6; i++){
        //     Debug.Log(sortedIndices[i]);
        // }

        // for (int j = 0; j < cp.GetLength(1); j++)
        // {
        //     Debug.Log(elitecp[j]);
        // }
        
        SceneManager.LoadScene("ConSkill"); //ConSkillSceneを呼び出す
    }
}