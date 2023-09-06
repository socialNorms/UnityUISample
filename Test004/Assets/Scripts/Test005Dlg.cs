using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    public Button btnResult, btnClear;
    public Text txtResult;
    int[] temp = new int[] { 100, 200, 300 };

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
    }

    void OnClicked_BtnResult()
    {
        txtResult.text = string.Empty;
        //string text = $"{Test_For()}\n{Test_While()}\n{Test_DoWhile()}";
        int[,] num1 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        int[,] num2 = new int[3, 2];
        string text = $"{PrintArray1(num1)}==============\n{PrintArray2(num2)}";
        txtResult.text = text;
    }

    void OnClicked_BtnClear()
    {
        txtResult.text = string.Empty;
    }

    string Test_For()
    {
        string text = $"For문 테스트\n";
        for (int i = 0; i < temp.Length; i++)
        {
            if (i > 1)
                text += $"{temp[i]}";
            else
                text += $"{temp[i]}, ";
        }
        return text;
    }

    string Test_While()
    {
        string text = $"While문 테스트\n";
        int tp = 0;
        while (tp<temp.Length)
        {
            if(tp > 1)
                text += $"{temp[tp]}";
            else
                text += $"{temp[tp]}, ";
            tp++;
        }
        return text;
    }

    string Test_DoWhile()
    {
        string text = $"Do While문 테스트\n";
        int tm = 0;
        do
        {
            if (tm > 1)
                text += $"{temp[tm]}";
            else
                text += $"{temp[tm]}, ";
            tm++;
        } while (tm < temp.Length);
        return text;
    }

    string PrintArray1(int[,] num)
    {
        string text = string.Empty;
        for(int i = 0; i < num.GetLength(0); i++)
        {
            for(int j = 0; j < num.GetLength(1); j++)
            {
                text += $"num({i},{j}) = {num[i, j]}\n";
            }
        }
        return text;
    }

    string PrintArray2(int[,] num)
    {
        string text = string.Empty;
        num[0, 0] = 4;
        num[0, 1] = 5;
        num[1, 0] = 6;
        num[1, 1] = 7;
        num[2, 0] = 8;
        num[2, 1] = 9;
        for (int i = 0; i < num.GetLength(0); i++)
        {
            for (int j = 0; j < num.GetLength(1); j++)
            {
                text += $"num({i},{j}) = {num[i, j]}\n";
            }
        }
        return text;
    }
}
