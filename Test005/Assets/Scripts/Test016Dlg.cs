using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Test016Dlg : MonoBehaviour
{
    public Button btnResult, btnClear, btnAdd, btnSave, btnOpen;
    public InputField iptName, iptKor, iptEng, iptMath;
    public Text txtResult, txtTemp;
    List<Score16> scores = new List<Score16>();

    private void Start()
    {
        Initialize();
    }
    void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
        btnAdd.onClick.AddListener(OnClicked_BtnAdd);
        btnSave.onClick.AddListener(OnClicked_BtnSave);
        btnOpen.onClick.AddListener(OnClicked_BtnOpen);
    }

    void OnClicked_BtnResult()
    {
        if (scores.Count == 0) return;
        scores.Sort((a,b) => a.Total < b.Total ? 1 : -1);
        txtResult.text = string.Empty;
        string text = string.Empty;
        for(int i = 0; i < scores.Count; i++)
        {
            Score16 score = scores[i];
            text += $"{i + 1}. ";
            text += GetScoreInfo(score);
        }
        text += $"==============================\n";
        text += GetTotalScoreInfo(scores);
        txtResult.text = text;
    }

    void OnClicked_BtnClear()
    {
        InputField_Clear();
        scores.Clear();
        txtTemp.text = string.Empty;
        txtResult.text = string.Empty;
    }

    void OnClicked_BtnAdd()
    {
        if (IsInputNull()) return;
        string name = iptName.text;
        int kor = int.Parse(iptKor.text);
        int eng = int.Parse(iptEng.text);
        int math = int.Parse(iptMath.text);
        if (IsOver9000(kor, eng, math)) return;
        Score16 score = new Score16(name, kor, eng, math);
        scores.Add(score);
        txtTemp.text += GetScoreTemp(score);
        InputField_Clear();
    }

    bool IsOver9000(int kor, int eng, int math)
    {
        if (kor > 100 || kor < 0 || eng > 100 || eng < 0 || math > 100 || math < 0)
            return false;
        else
            return true;
    }

    bool IsInputNull()
    {
        if (iptName.text == string.Empty || iptKor.text == string.Empty || iptEng.text == string.Empty || iptMath.text == string.Empty)
            return false;
        else
            return true;
    }

    string GetTotalScoreInfo(List<Score16> scoreList)
    {
        string text = string.Empty;
        int kor = 0;
        int eng = 0;
        int math = 0;
        for( int i = 0; i < scoreList.Count; i++)
        {
            Score16 score = scoreList[i];
            kor += score.kor;
            eng += score.eng;
            math += score.math;
        }

        text = $"과목별 합계 : [국어:{kor},{string.Format("{0:0.00}", (float)kor / 3)}], [영어:{eng},{string.Format("{0:0.00}", (float)eng / 3)}], [수학:{math},{string.Format("{0:0.00}", (float)math / 3)}]";
        return text;
    }

    string GetScoreTemp(Score16 score)
    {
        string text = string.Empty;
        text = $"{score.name} : {score.kor}, {score.eng}, {score.math}\n";
        return text;
    }

    string GetScoreInfo(Score16 score)
    {
        string text = string.Empty;
        text = $"{score.name} : {score.kor}, {score.eng}, {score.math} | 합계:{score.Total}, 평균:{score.Average}\n";
        return text;
    }

    void InputField_Clear()
    {
        iptName.text = string.Empty;
        iptKor.text = string.Empty;
        iptEng.text = string.Empty;
        iptMath.text = string.Empty;
    }

    void OnClicked_BtnSave()
    {
        StreamWriter sw = new StreamWriter("Score16.txt");
        sw.WriteLine(scores.Count);
        for(int i = 0 ; i < scores.Count; i++)
        {
            Score16 score = scores[i];
            sw.WriteLine(score.name);
            sw.WriteLine(score.kor);
            sw.WriteLine(score.eng);
            sw.WriteLine(score.math);
        }
        sw.Close();
    }

    void OnClicked_BtnOpen()
    {
        StreamReader sr = new StreamReader("Score16.text");
        scores.Clear();
        txtTemp.text = string.Empty;
        string text = string.Empty;
        int count = int.Parse(sr.ReadLine());
        for( int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine()); 
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score16 score = new Score16(name, kor, eng, math);
            scores.Add(score);
        }
        sr.Close();
        for(int i = 0; i < scores.Count; i++)
        {
            Score16 score = scores[i];
            text += GetScoreTemp(score);
        }
        txtTemp.text = text;
    }
}

public class Score16
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
    public Score16(string _Name, int _Kor, int _Eng, int _Math)
    {
        name = _Name;
        kor = _Kor;
        eng = _Eng;
        math = _Math;
    }
}
