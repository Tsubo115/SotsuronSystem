using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class PlayAudio : MonoBehaviour
{
    public GetScore GS;
    public IGA iga;

    //ボタンが押されているか
    private bool[] isClick;

    //再生ボタンのObject
    public GameObject[] ButtonObjects = new GameObject[6];
    //再生ボタンのImage
    private Image[] ButtonImages = new Image[6];

    //再生中の音楽
    private int currentMusic;


    //再生ボタン，停止ボタン
    public Sprite StartButton;
    public Sprite StopButton;


    private AudioSource audioS;
    private List<AudioClip> audioClips = new List<AudioClip>();
    private int currentClipIndex = 0; //再生している音源
    private string[] chordName = {"C", "Dm", "Em", "F", "G", "Am", "Bm♭5"};

    //現在のコルーチン
    private Coroutine currentCoroutine;



    void Start()
    {
        //Chord(image)のコンポーネントを取得
        for(int i = 0; i < iga.M; i++){
            ButtonImages[i] = ButtonObjects[i].GetComponent<Image>();
        }

        //再生フラグの初期化
        isClick = new bool[ButtonObjects.Length];
    }


    //各ボタンに対してオーディオ再生
    public void M0()
    {
        OnClick(0, currentMusic);
        currentMusic = 0;
    }

    public void M1()
    {
        OnClick(1, currentMusic);
        currentMusic = 1;
    }

    public void M2()
    {
        OnClick(2, currentMusic);
        currentMusic = 2;
    }

    public void M3()
    {
        OnClick(3, currentMusic);
        currentMusic = 3;
    }

    public void M4()
    {
        OnClick(4, currentMusic);
        currentMusic = 4;
    }

    public void M5()
    {
        OnClick(5, currentMusic);
        currentMusic = 5;
    }


    //各ボタンにするボタンの処理
    public void OnClick(int musicNum, int currentMusic)
    {
        //現在再生中のオーディオ，コルーチンを停止
        if(currentCoroutine != null){
            audioS.Stop();
            StopCoroutine(currentCoroutine);

            if(musicNum != currentMusic){
                //現在再生中のボタンを変更
                ButtonImages[currentMusic].sprite = StartButton;
                //現在再生中の再生ボタンフラグを変更
                isClick[currentMusic] = false;
            }
        }


        if(isClick[musicNum] == false){ //再生開始
            isClick[musicNum] = true;

            ButtonImages[musicNum].sprite = StopButton; //停止ボタンに変更(再生中)

            //Audio再生
            AddAudioClips(musicNum);
        }
        else { //再生停止
            isClick[musicNum] = false;

            ButtonImages[musicNum].sprite = StartButton; //再生ボタンに戻す(停止中)
        }
    }



    //配列にAudioClipを格納し再生
    void AddAudioClips(int musicNum)
    {
        //現在再生クリップ番号およびリストをリセット
        currentClipIndex = 0;
        audioClips.Clear();

        audioS = GetComponent<AudioSource>(); //Audioコンポーネントを取得

        //遺伝子列に従ってリストにAudioClipを格納
        for(int i = 0; i < 8; i++){
            AudioClip clip = Resources.Load<AudioClip>("AudioClips/" + chordName[GS.cp[musicNum, i] - 1]); //ChordName[musicNum曲目のi番目のコード]
            audioClips.Add(clip);

            Debug.Log(GS.cp[musicNum, i]);
        }

        currentCoroutine = StartCoroutine(PlayAudioSequentially(musicNum)); //コルーチンの実行(引数はコルーチンの関数名)
    }
 
    private IEnumerator PlayAudioSequentially(int musicNum) //コルーチンの処理
    {
        Debug.Log(audioClips.Count);
        while (true)
        {
            // 現在のクリップを再生
            audioS.clip = audioClips[currentClipIndex];
            audioS.Play();
 
            // 再生が終了するまで待機
            yield return new WaitForSeconds(audioS.clip.length);
 
            // 次のクリップに進む
            currentClipIndex++;

            //1周したら終了
            if(currentClipIndex >= audioClips.Count){
                isClick[musicNum] = false;
                ButtonImages[musicNum].sprite = StartButton; //ボタン変更
                yield break; //コルーチンの終了
            }
        }
    }
}