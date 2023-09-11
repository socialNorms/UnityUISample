using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test013Dlg : MonoBehaviour
{
    public Button btnResult, btnClear, btnAdd;
    public Text txtResult, txtTemp;
    public InputField iptName, iptKor, iptEng, iptMath;
    List<Score13> scores = new List<Score13>();

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
        btnAdd.onClick.AddListener(OnClicked_BtnAdd);
    }

    void OnClicked_BtnResult()
    {
        scores.Sort((a, b) => a.Total <  b.Total ? 1 : -1);
        if (scores.Count == 0) return;
        txtResult.text = string.Empty;
        txtResult.text += "己利包府\n========================\n";
        for(int i = 0; i < scores.Count; i++)
        {
            Score13 score = scores[i];
            txtResult.text += $"{score.name} : {score.kor}, {score.eng}, {score.math} : 钦拌={score.Total}, 乞闭={string.Format("{0:0.0}", score.Average)}\n";
        }
    }

    void OnClicked_BtnClear()
    {
        txtTemp.text = string.Empty;
        txtResult.text = string.Empty;
        InputFieldClear();
        scores.Clear();
    }

    void OnClicked_BtnAdd()
    {
        if (iptKor.text == string.Empty || iptName.text == string.Empty || iptMath.text == string.Empty || iptEng.text == string.Empty) return;
        string name = iptName.text;
        int kor = int.Parse(iptKor.text);
        int eng = int.Parse(iptEng.text);
        int math = int.Parse(iptMath.text);
        if(kor < 0 || kor > 100 || eng < 0 || eng > 100 || math < 0 || math > 100) return;
        Score13 score = new Score13(name, kor, eng, math);
        scores.Add(score);
        txtTemp.text += $"{name} : {kor}, {eng}, {math}\n";
        InputFieldClear();
    }

    public void InputFieldClear()
    {
        iptName.text = string.Empty;
        iptKor.text = string.Empty;
        iptEng.text = string.Empty;
        iptMath.text = string.Empty;
    }
}

public class Score13
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
    public Score13(string _Name, int _Kor, int _Eng, int _Math)
    {
        name = _Name;
        kor = _Kor;
        eng = _Eng;
        math = _Math;

    }
}
