using TMPro;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public bool state = true;
    public TextMeshProUGUI resultText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Applicatie is gestart!");
    }

    public void ToggleAction()
    {
        resultText.gameObject.SetActive(!state);
        state = !state;
    }
}
