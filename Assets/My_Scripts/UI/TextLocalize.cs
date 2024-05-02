
using UnityEngine;
using TMPro;

public class TextLocalize : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string textENG;
    [TextArea]
    [SerializeField] private string textRUS;
    [TextArea]
    [SerializeField] private string textTUR;

    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        SetText();
    }

    void SetText()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                text.text = textENG;
                break;
            case SystemLanguage.Russian:
                text.text = textRUS;
                break;
            case SystemLanguage.Turkish:
                text.text = textTUR;
                break;
            default:
                text.text = textENG;
                break;
        }
    }
}
