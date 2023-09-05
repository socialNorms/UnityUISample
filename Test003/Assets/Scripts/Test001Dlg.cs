using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    public Text reslutTxt;
    public Button btnReslut, btnClear;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        btnReslut.onClick.AddListener(() => OnClicked_BtnResult());
        btnClear.onClick.AddListener(() => OnClicked_BtnClear());
    }

    void OnClicked_BtnResult()
    {
        reslutTxt.text = string.Empty;

        int sum = Sum(10, 20);

        int a = 100;
        int b = 200;

        reslutTxt.text += $"Sum = {sum}\n============\n";

        reslutTxt.text += $"a = {a}, b = {b}\n";

        Swap(a, b);
        reslutTxt.text += $"a = {a}, b = {b}\n";

        RefSwap(ref a, ref b);
        reslutTxt.text += $"a = {a}, b = {b}\n============";
    }

    void OnClicked_BtnClear()
    {
        reslutTxt.text = string.Empty;
    }

    int Sum(int a, int b)
    {
        return a + b;
    }

    void Swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void RefSwap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
