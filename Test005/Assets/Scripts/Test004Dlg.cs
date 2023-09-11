using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public Button btnResult = null;
    public Button btnClear = null;
    public Text resultTxt = null;
    public InputField input;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        btnResult.onClick.AddListener(OnClicked_BtnResult);
        btnClear.onClick.AddListener(OnClicked_BtnClear);
    }

    void OnClicked_BtnResult()
    {
        if (input.text == string.Empty) return;
        int i = int.Parse(input.text);
        input.text = string.Empty;
        resultTxt.text = string.Empty;
        string sign = string.Empty;
        for (int j = 1; j < i + 1; j++)
        {
            if (j == i)
                sign += $"{string.Format("{0:00}", j)}";
            else
                sign += $"{string.Format("{0:00}", j)} * ";
        }
        resultTxt.text += $"{sign} = \n{Factorial(i)}";
    }

    void OnClicked_BtnClear()
    {
        input.text = string.Empty;
        resultTxt.text = string.Empty;
    }

    uint Factorial(int factorial)
    {
        uint num = (uint)Mathf.Abs(factorial);
        uint total = 1;
        for (uint i = 0; i < factorial; i++)
        {
            total *= i + 1;
        }
        return total;
    }
}
