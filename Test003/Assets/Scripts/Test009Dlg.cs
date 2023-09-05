using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    public Button resultBtn;
    public Button clearBtn;
    public Text resultTxt;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        resultBtn.onClick.AddListener(OnClicked_ResultBtn);
        clearBtn.onClick.AddListener(OnClicked_ClearBtn);
    }

    void OnClicked_ResultBtn()
    {
        resultTxt.text = string.Empty;
        string text = string.Empty;
        Actor master = new Actor(5000, 100);
        Actor enemy = new Actor(2000, 200);

        text += $"[기본 HP = {master.GetHp()}, Attack={master.GetAttack()}]\n";
        text += $"[Master HP = {master.GetHp()}]\n";
        text += $"데미지 50 생김\n";
        master.SetHp(master.GetHp() - 50);
        text += $"Master HP = {master.GetHp()}\n";
        text += "===================\n";
        text += $"적 HP = {enemy.GetHp()}, Attack = {enemy.GetAttack()}\n";
        text += $"Eneny HP = {enemy.GetHp()}\n";
        text += $"[적이 마스터에게 공격 당함]\n";
        enemy.SetHp(enemy.GetHp() - master.GetAttack());
        text += $"Enemy HP = {enemy.GetHp()}\n";
        text += $"===================\n";
        text += $"[마스터의 HP가 100 만큼 회복됨]\n";
        master.SetHp(master.GetHp() + 100);
        text += $"[Master HP = {master.GetHp()}]\n";
        text += $"[적의 HP가 200 만큼 회복됨]\n";
        enemy.SetHp(enemy.GetHp() + 200);
        text += $"<color=#123424>Eneny HP = {enemy.GetHp()}</color>";

        resultTxt.text = text;
    }

    void OnClicked_ClearBtn()
    {
        resultTxt.text = string.Empty;
    }
}
