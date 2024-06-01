using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WavyText : MonoBehaviour
{
    public Text dialogueText; // Unity Text ÄÄÆ÷³ÍÆ®
    public float amplitude = 5f; // Èçµé¸²ÀÇ Å©±â
    public float frequency = 5f; // Èçµé¸²ÀÇ ºóµµ

    private string originalText;

    void Start()
    {
        if (dialogueText == null)
        {
            dialogueText = GetComponent<Text>();
        }

        originalText = dialogueText.text;
        StartCoroutine(WaveEffect());
    }

    IEnumerator WaveEffect()
    {
        while (true)
        {
            string newText = "";
            for (int i = 0; i < originalText.Length; i++)
            {
                char c = originalText[i];
                float offset = Mathf.Sin(Time.time * frequency + i) * amplitude;
                newText += $"<color=#00000000>{c}</color><voffset={offset}px>{c}</voffset>";
            }
            dialogueText.text = newText;
            yield return null;
        }
    }
}
