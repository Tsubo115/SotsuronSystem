using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackNextButton : MonoBehaviour
{
    public ChordButton CB;
    public inputChord IC;

    //高難易度コード
    public int[] DifficultChord = new int[3];


    //BackButtonが押されたとき
    public void OnClickBack(){
        if(CB.i == 1){ //現在Cのとき
            ; //何もしない
        }
        else if(CB.i == 2){ //Dmのとき
            CB.OnClickC(); //Cに戻る
        }
        else if(CB.i == 3){ //Emのとき
            CB.OnClickDm(); //Dmに戻る
        }
        else if(CB.i == 4){ //Fのとき
            CB.OnClickEm(); //Emに戻る
        }
        else if(CB.i == 5){ //Gのとき
            CB.OnClickF(); //Fに戻る
        }
        else if(CB.i == 6){ //Amのとき
            CB.OnClickG(); //Gに戻る
        }
        else if(CB.i == 7){ //Bmのとき
            CB.OnClickAm(); //Amに戻る
        }
    }

    //NextButtonが押されたとき
    public void OnClickNext(){
        if(CB.i == 1){ //現在Cのとき
            CB.OnClickDm(); //Dmに進む
        }
        else if(CB.i == 2){ //Dm
            CB.OnClickEm();
        }
        else if(CB.i == 3){ //Em
            CB.OnClickF();
        }
        else if(CB.i == 4){ //F
            CB.OnClickG();
        }
        else if(CB.i == 5){ //G
            CB.OnClickAm();
        }
        else if(CB.i == 6){ //Am
            CB.OnClickBm();
        }
        else if(CB.i == 7){ //Bm
            ; //何もしない
        }
    }


    //次のシーンへ移動
    public void OnClickNextScene()
    {
        //難易度の高いコードを3つ保存
        // インデックス順をソート
        var sortedIndices = IC.ChordPoint
            .Select((value, index) => new { Value = value, Index = index })
            .OrderBy(x => x.Value)
            .Select(x => x.Index)
            .ToArray();
        //難しい順にインデックス(コード)を保存
        for(int j = 0; j < 3; j++){
            DifficultChord[j] = sortedIndices[j];

            //Dataに難しいコードを保存
            Data.instance.DiffChord[j] = DifficultChord[j];
        }


        // foreach (var index in DifficultChord)
        // {
        //     Debug.Log(index);
        // }

        SceneManager.LoadScene("IGA"); //IGASceneを呼び出す
    }
}