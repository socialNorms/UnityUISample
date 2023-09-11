using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Test015Dlg : MonoBehaviour
{
    public Button btnResult, btnClear, btnAdd, btnSave, btnOpen;
    public InputField iptName, iptKor, iptEng, iptMath;
    public Text txtTemp, txtResult;
    public List<Score15> scores = new List<Score15>();

    void Start()
    {
        Initialize();
    }

    private void Initialize()
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
        txtResult.text = string.Empty;
        scores.Sort((a, b) => a.Total < b.Total ? 1 : -1);
        string text = string.Empty;
        text += GetScoreTxt(scores);
        text += "==============================\n";
        text += GetTotalScoreInfo(scores);
        txtResult.text = text;
    }

    string GetScoreTxt(List<Score15> scoreList)
    {
        string text = string.Empty;
        for (int i = 0; i < scoreList.Count; i++)
        {
            Score15 score = scoreList[i];
            text += $"{i + 1}. {score.name} : {score.kor}, {score.eng}, {score.math} | 합계:{score.Total}, 평군:{string.Format("{0:0.0}", score.Average)}\n";
        }
        return text;
    }

    string GetTotalScoreInfo(List<Score15> scoreList)
    {
        string text = string.Empty;
        int korTotal = 0;
        int engTotal = 0;
        int mathTotal = 0;
        for (int i = 0; i < scoreList.Count; i++)
        {
            Score15 score = scoreList[i];
            korTotal += score.kor;
            engTotal += score.eng;
            mathTotal += score.math;
        }
        text += $"과목별 통계 : \n[국어 : 합계={korTotal}, 평균={string.Format("{0:0.0}", (float)korTotal / scoreList.Count)}]\n[영어 : 합계={engTotal}, 평균={string.Format("{0:0.0}", (float)engTotal / scoreList.Count)}]\n[수학 : 합계={mathTotal}, 평균={string.Format("{0:0.0}", (float)mathTotal / scoreList.Count)}]";
        return text;
    }

    void OnClicked_BtnClear()
    {
        iptName.text = string.Empty;
        iptKor.text = string.Empty;
        iptEng.text = string.Empty;
        iptMath.text = string.Empty;
        scores.Clear();
        txtResult.text = string.Empty;
        txtTemp.text = string.Empty;
    }

    void OnClicked_BtnAdd()
    {
        if (iptName.text == string.Empty || iptKor.text == string.Empty || iptEng.text == string.Empty || iptMath.text == string.Empty) return;
        string name = iptName.text;
        int kor = int.Parse(iptKor.text);
        int eng = int.Parse(iptEng.text);
        int math = int.Parse(iptMath.text);
        if (kor > 100 || eng > 100 || math > 100 || kor < 0 || eng < 0 || math < 0) return;
        Score15 score = new Score15(name, kor, eng, math);
        scores.Add(score);
        txtTemp.text += $"{name} : {kor}, {eng}, {math}\n";
        iptName.text = string.Empty;
        iptKor.text = string.Empty;
        iptEng.text = string.Empty;
        iptMath.text = string.Empty;
    }

    void OnClicked_BtnSave()
    {
        StreamWriter sw = new StreamWriter("Score15.txt");
        sw.WriteLine(scores.Count);
        for(int i = 0; i < scores.Count; i++)
        {
            Score15 score = scores[i];
            sw.WriteLine(score.name);
            sw.WriteLine(score.kor);
            sw.WriteLine(score.eng);
            sw.WriteLine(score.math);
        }
        sw.Close();
    }

    void OnClicked_BtnOpen()
    {
        StreamReader sr = new StreamReader("Score15.txt");
        scores.Clear();
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score15 score = new Score15(name, kor, eng, math);
            scores.Add(score);
        }
        sr.Close();
        txtTemp.text = string.Empty;
        for (int i = 0; i < scores.Count; i++)
        {
            Score15 score = scores[i];
            txtTemp.text += $"{score.name} : {score.kor}, {score.eng}, {score.math}\n";
        }
    }
}

public class Score15
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
        get { return (float)Total / 3 ; }
    }

    public Score15(string _Name, int _Kor, int _Eng, int _Mathf)
    {
        name = _Name;
        kor = _Kor;
        eng = _Eng;
        math = _Mathf;
    }
}
