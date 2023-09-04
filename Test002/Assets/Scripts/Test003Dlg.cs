using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    public Button btnResult, btnClear;
    public InputField[] inputNums;
    public Text resultTxt;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        btnResult.onClick.AddListener(() => OnClicked_BtnResult());
        btnClear.onClick.AddListener(() => OnClicked_BtnClear());
    }

    void OnClicked_BtnResult()
    {
        for (int i = 0; i < inputNums.Length; i++)
            if (inputNums[i].text == string.Empty)
                return;
        resultTxt.text = string.Empty;

        int num1 = int.Parse(inputNums[0].text);
        int num2 = int.Parse(inputNums[1].text);
        int num3 = int.Parse(inputNums[2].text);

        for (int i = 0; i < inputNums.Length; i++)
            inputNums[i].text = string.Empty;

        //for (int i = 0; i < num.Length; i++)
        //{
        //    for(int j = 0; j < num.Length; j++)
        //    {
        //        if(num[j] < num[i])
        //        {
        //            int temp = num[i];
        //            num[i] = num[j];
        //            num[j] = temp;
        //        }
        //    }
        //}


        // 1, 2, 3

        if (num1 < num2)
            Swap(ref num1, ref num2);
        if (num2 < num3)
            Swap(ref num2, ref num3);
        if (num1 < num2)

            Swap(ref num1, ref num2);

        resultTxt.text = $"{num1}, {num2}, {num3}\n제일 큰 숫자는 {num1} 입니다.";
    }

    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void OnClicked_BtnClear()
    {
        resultTxt.text = string.Empty;
    }
}
