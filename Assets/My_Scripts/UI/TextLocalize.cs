
using UnityEngine;
using TMPro;
using GamePush;

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
        Language lang = GP_Language.Current();
        switch (lang)
        {
            case Language.English:
                text.text = textENG;
                break;
            case Language.Russian:
                text.text = textRUS;
                break;
            case Language.Turkish:
                text.text = textTUR;
                break;
            default:
                text.text = textENG;
                break;
        }
    }
}
