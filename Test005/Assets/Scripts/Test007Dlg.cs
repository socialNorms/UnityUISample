using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public Button btnResult, btnClaer, btnAdd;
    public InputField input;
    public Text txtResult, inputNums;
    public List<int> numList = new List<int>();

    private void Start()
    {
        Initialize();
    }


    private void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClaer.onClick.AddListener(OnClicked_BtnClear);
        btnAdd.onClick.AddListener(OnClicked_BtnAdd);
    }

    void OnClicked_BtnResult()
    {
        if (numList.Count <= 4) return;

        txtResult.text = string.Empty;
        numList.Sort((a, b) => a > b ? 1 : -1);
        for(int i = 0; i < numList.Count; i++)
        {
            if(i > 4)
                txtResult.text += $"{numList[i]}";
            else
                txtResult.text += $"{numList[i]}, ";
        }
    }

    void OnClicked_BtnAdd()
    {
        if (numList.Count >= 5)
            return;
        int temp = int.Parse(input.text);
        if (temp > 100 || temp < 0)
            return;
        numList.Add(temp);
        inputNums.text += $"{temp}, ";
        input.text = string.Empty;
    }

    void OnClicked_BtnClear()
    {
        numList.Clear();
        inputNums.text = string.Empty;
        txtResult.text = string.Empty;
    }
}
