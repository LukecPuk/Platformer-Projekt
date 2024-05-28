using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro;
    private TextMeshProUGUI txt;  // Replace Text with TextMeshProUGUI

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();  // Get the TextMeshProUGUI component
    }

    private void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat(volumeName) * 100;
        txt.text = textIntro + volumeValue.ToString("F1");  // Optionally format the float for better readability
    }
}
