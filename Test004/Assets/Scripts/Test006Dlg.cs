using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Test006Dlg : MonoBehaviour
{
    public Button btnResult, btnClear;
    public Text resultTxt;
    public Dictionary<string, int> dick = new Dictionary<string, int>();

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
        DickTest();
    }
    
    void DickTest()
    {
        dick.Add("±èÀç¿ø", 17);
        dick.Add("ÀÓ°Ç", 18);
        dick.Add("¹Ú½ÂÇö", 50);
        foreach(KeyValuePair<string, int> item in dick)
        {
            Debug.Log($"{item.Key}, {item.Value}");
        }
    }

    void OnClicked_BtnResult()
    {
        List<int> nums = new List<int>();
        resultTxt.text = string.Empty;
        string text = string.Empty;

        nums.Add(10);
        nums.Add(20);
        nums.Add(30);

        text += $"{PrintFor(nums)}";
        text += $"\n==============\n";

        nums.Add(40);
        nums.Add(50);

        text += $"{PrintForeach(nums)}";
        text += $"\n==============\n";

        nums.Remove(10);
        nums.Remove(40);

        text += $"{PrintForeach(nums)}";
        text += $"\n==============\n";

        resultTxt.text = text;
    }

    void OnClicked_BtnClear()
    {
        resultTxt.text = string.Empty;
    }


    string PrintForeach(List<int> list)
    {
        string text = string.Empty;

        foreach (int i in list)
        {
            if (i == 50)
                text += $"{i}";
            else
                text += $"{i}, ";
        }

        return text;
    }

    string PrintFor(List<int> list)
    {
        string text = string.Empty;

        for (int i = 0; i < list.Count; i++)
        {
            if (i > list.Count - 2)
                text += $"[{i}] : {list[i]}";
            else
                text += $"[{i}] : {list[i]}, ";
        }

        return text;
    }
}
