using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    public Button resultBtn, clearBtn;
    public Text resultTxt;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        resultBtn.onClick.AddListener(OnClicked_ResultBtn);
        clearBtn.onClick.AddListener(OnClicked_ClearBtn);
    }

    void OnClicked_ResultBtn()
    {
        Dictionary<int, string> dic = new Dictionary<int, string>();
        resultTxt.text = string.Empty;
        string text = string.Empty;
        dic.Add(1, "���");
        dic.Add(2, "��");
        dic.Add(3, "����");

        text += PrintDic(dic);
        text += "\n===============\n";

        dic[1] = "���ִ� ���";
        dic[2] = "���ִ� ��";
        dic[3] = "����̸Ӹ����� ����";

        text += PrintDic(dic);
        text += "\n===============\n";

        dic.Remove(1);
        text += PrintDic(dic);

        resultTxt.text = $"{text}";
    }

    void OnClicked_ClearBtn()
    {
        resultTxt.text = string.Empty;
    }

    string PrintDic(Dictionary<int, string> dic)
    {
        string text = string.Empty; 
        foreach(KeyValuePair<int, string> item in dic)
            text += $"{item.Key} : {item.Value}, ";
        return text;
    }
}
