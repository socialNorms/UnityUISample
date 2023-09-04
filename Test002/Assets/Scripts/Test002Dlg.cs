using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public Text resultTxt;
    public InputField scoreInput;
    public Button btnResult, btnClear;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        btnResult.onClick.AddListener(() => OnClicked_BtnResult());
        btnClear.onClick.AddListener(() => OnClicked_BtnClear());
    }

    void OnClicked_BtnResult()
    {
        if (scoreInput.text == string.Empty)
            return;
        int r = Random.Range(1, 3);
        int score = int.Parse(scoreInput.text);
        if (score > 100 || score < 0)
            return;
        scoreInput.text = string.Empty;

        if (r == 1)
            resultTxt.text = $"당신의 점수는 {ReturnScoreToIf(score)} 입니다. (If)";
        else
            resultTxt.text = $"당신의 점수는 {ReturnScoreToSwitch(score)} 입니다. (Switch)";
    }

    void OnClicked_BtnClear()
    {
        scoreInput.text = string.Empty;
    }

    string ReturnScoreToIf(int score)
    {
        if (score > 89)
            return "A";
        else if (score > 79)
            return "B";
        else if (score > 69)
            return "C";
        else if (score > 59)
            return "D";
        else
            return "F";
    }

    string ReturnScoreToSwitch(int score)
    {
        switch (score)
        {
            case > 89:
                {
                    return "A";
                    break;
                }
            case > 79:
                {
                    return "B";
                    break;
                }
            case > 69:
                {
                    return "C";
                    break;
                }
            case > 59:
                {
                    return "D";
                    break;
                }
            default:
                {
                    return "F";
                    break;
                }
        }
    }
}
