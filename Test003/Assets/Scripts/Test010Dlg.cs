using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public Button resultBtn;
    public Button clearBtn;
    public Button addBtn;
    public Text resultTxt;
    public InputField nameInput;
    public InputField weightInput;
    List<Animal> animals = new List<Animal>();

    private void Start()
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
        resultTxt.text = string.Empty;
        switch (animals.Count)
        {
            case 1:
                resultTxt.text = $"{animals[0].name}�� ���Դ� {animals[0].weight}Kg �Դϴ�.";
                break;
            case 2:
                resultTxt.text = $"{animals[0].name}��(��) {animals[1].name}�� ������ ���� {animals[0].weight + animals[1].weight}Kg �Դϴ�.";
                break;
            default:
                return;
        }
    }

    void OnClicked_AddBtn()
    {
        string name = nameInput.text;
        int weight = int.Parse(weightInput.text);
        if (name == string.Empty || weight > 2000 || weight <= 0) return;
        Animal animal = new Animal(name, weight);
        animals.Add(animal);
        nameInput.text = string.Empty;
        weightInput.text = string.Empty;
    }

    void OnClicked_ClearBtn()
    {
        animals.Clear();
        resultTxt.text = string.Empty;
    }
}

public class Animal
{
    public string name;
    public int weight;

    public Animal(string _Name, int _Weight)
    {
        name = _Name;
        weight = _Weight;
    }
}
