using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    public Button btnResult, btnClear;
    public InputField iptName, iptKor, iptEng, iptMath;
    public Text txtResult;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
    }

    void OnClicked_BtnResult()
    {
        txtResult.text = string.Empty;
        if (iptName.text == string.Empty || iptKor.text == string.Empty || iptEng.text == string.Empty || iptMath.text == string.Empty) return;
        string name = iptName.text;
        int kor = int.Parse(iptKor.text);
        int eng = int.Parse(iptEng.text);
        int math = int.Parse(iptMath.text);
        if (kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100) return;
        OnClicked_BtnClear();
        Score score = new Score(name, kor, eng, math);
        txtResult.text = $"{name} 의 점수 \n국어 : {kor}점, 영어 : {eng}점, 수학 : {math}점\n합계 : {score.Total}점, 평균 : {string.Format("{0:0.00}", score.Average)}점";
    }

    void OnClicked_BtnClear()
    {
        iptName.text = string.Empty;
        iptKor.text = string.Empty;
        iptEng.text = string.Empty;
        iptMath.text = string.Empty;
        txtResult.text = string.Empty;
    }
}


public class Score
{
    public string name;
    public int kor;
    public int eng;
    public int math;

    int total;
    public int Total
    {
        get { return kor + eng + math; }
    }

    float average;
    public float Average
    {
        get { return (float)Total / 3; }
    }

    public Score(string _Name, int _Kor, int _Eng, int _Math)
    {
        name = _Name;
        kor = _Kor;
        eng = _Eng;
        math = _Math;
    }
}
    