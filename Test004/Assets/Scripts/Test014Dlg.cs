using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Test014Dlg : MonoBehaviour
{
    public Button btnResult, btnClear, btnAdd, btnFildOpen, btnFileSave;
    public InputField iptName, iptKor, iptEng, iptMath;
    public Text txtResult, txtTemp;
    List<Score14> scores = new List<Score14>();

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
        btnAdd.onClick.AddListener(OnClicked_BtnAdd);
        btnFileSave.onClick.AddListener(OnClicked_BtnFileSave);
        btnFildOpen.onClick.AddListener(OnClicked_BtnFileOpen);
    }

    void OnClicked_BtnResult()
    {
        scores.Sort((a, b) => a.Total < b.Total ? 1 : -1);
        if (scores.Count == 0) return;
        string text = string.Empty;
        txtResult.text = string.Empty;
        text += GetScores(scores);
        text += "=====================================\n";
        text += GetTotalScores(scores);
        txtResult.text = text;
    }

    string GetScores(List<Score14> scoreList)
    {
        string text = string.Empty;
        for(int i = 0; i < scoreList.Count; i++)
        {
            Score14 score = scoreList[i];
            text += $"{i + 1}. {score.name} : {score.kor}, {score.eng}, {score.math} | 합계:{score.Total}, 평군:{string.Format("{0:0.0}", score.Average)}\n";
        }
        return text;
    }

    string GetTotalScores(List<Score14> scoreList)
    {
        string text = string.Empty;
        int korTotal = 0;
        int engTotal = 0;
        int mathTotal = 0;
        for( int i = 0; i < scoreList.Count; i++)
        {
            Score14 score = scoreList[i];
            korTotal += score.kor;
            engTotal += score.eng;
            mathTotal += score.math;
        }
        text += $"과목별 통계 : \n[국어 : 합계={korTotal}, 평균={string.Format("{0:0.0}", (float)korTotal / scoreList.Count)}]\n[영어 : 합계={engTotal}, 평균={string.Format("{0:0.0}", (float)engTotal / scoreList.Count)}]\n[수학 : 합계={mathTotal}, 평균={string.Format("{0:0.0}", (float)mathTotal / scoreList.Count)}]";
        return text;
    }

    void OnClicked_BtnClear()
    {
        txtResult.text = string.Empty;
        txtTemp.text = string.Empty;
        scores.Clear();
        InputClear();
    }

    void OnClicked_BtnAdd()
    {
        if (iptName.text == string.Empty || iptKor.text == string.Empty || iptEng.text == string.Empty || iptMath.text == string.Empty) return;
        string name = iptName.text;
        int kor = int.Parse(iptKor.text); 
        int eng = int.Parse(iptEng.text);
        int math = int.Parse(iptMath.text);
        if (kor > 100 || kor < 0 || eng > 100 || eng < 0 || math > 100 || math < 0) return;
        Score14 score = new Score14(name , kor, eng, math);
        scores.Add(score);
        txtTemp.text += $"{name} : {kor}, {eng}, {math}\n";
        InputClear();
    }

    void InputClear()
    {
        iptName.text = string.Empty;
        iptEng.text = string.Empty;
        iptKor.text = string.Empty;
        iptMath.text = string.Empty;
    }

    void OnClicked_BtnFileSave()
    {
        StreamWriter sw = new StreamWriter("Score.txt");
        sw.WriteLine(scores.Count);
        for(int i = 0; i < scores.Count; i++)
        {
            Score14 score = scores[i];
            sw.WriteLine(score.name);
            sw.WriteLine(score.kor);
            sw.WriteLine(score.eng);
            sw.WriteLine(score.math);
        }
        sw.Close();
    }

    void OnClicked_BtnFileOpen()
    {
        StreamReader sr = new StreamReader("Score.txt");
        scores.Clear();
        int count = int.Parse(sr.ReadLine());
        for (int i =  0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score14 score = new Score14(name, kor, eng, math);
            scores.Add(score);
        }
        sr.Close();
        txtTemp.text = string.Empty;
        for (int i = 0; i < scores.Count; i++)
        {
            Score14 score = scores[i];
            txtTemp.text += $"{score.name} : {score.kor}, {score.eng}, {score.math}\n";
        }
    }
}

public class Score14
{
    public string name;
    public int kor;
    public int eng;
    public int math;
    public int Total
    {
        get { return kor + eng + math; }
    }
    public float Average
    {
        get { return (float)Total / 3; }
    }
    public Score14(string _Name, int _Kor, int _Eng, int _Math)
    {
        name = _Name;
        kor = _Kor;
        eng = _Eng;
        math = _Math;
    }
}
