using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test011Dlg : MonoBehaviour
{
    public Button resultBtn, clearBtn, addBtn;
    public InputField nameInput, hpInput;
    public Text resultTxt, tempTxt;
    List<Monster> monsters = new List<Monster>();

    void Start()
    {
        Initialize();
    }
    
    void Initialize()
    {
        resultBtn.onClick.AddListener(OnClicked_ResultBtn);
        clearBtn.onClick.AddListener(OnClicked_ClearBtn);
        addBtn.onClick.AddListener(OnClicked_AddBtn);
    }

    void OnClicked_ResultBtn()
    {
        if (monsters.Count != 4) return;
        resultTxt.text = string.Empty;
        string text = string.Empty;
        for(int i = 0; i < monsters.Count; i++)
            monsters[i].Damage(80);

        for (int i = 0; i < monsters.Count; i++)
            text += $"{i + 1}. Name : {monsters[i].name}, Hp : {monsters[i].hp}\n";

        resultTxt.text = text;
    }
    
    void OnClicked_ClearBtn()
    {
        nameInput.text = string.Empty;
        hpInput.text = string.Empty; 
        monsters.Clear();
        tempTxt.text = string.Empty;
        resultTxt.text = string.Empty;
    }

    void OnClicked_AddBtn()
    {
        string name = nameInput.text;
        int hp = int.Parse(hpInput.text);
        if (name == string.Empty || hp <= 0 || hp > 100 || monsters.Count >= 4) return;
        Monster monster = new Monster(name, hp);
        monsters.Add(monster);
        tempTxt.text += $"[{name},{hp}], \n";
        nameInput.text = string.Empty;
        hpInput.text = string.Empty;
    }
}

public class Monster
{
    public string name;
    public int hp;
    public Monster(string _Name, int _Hp)
    {
        name = _Name;
        hp = _Hp;
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if(hp < 0) hp = 0;
    }
}
