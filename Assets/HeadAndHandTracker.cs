using System.IO;
using System;
using UnityEngine;
using TMPro;

public class HeadAndHandTracker : MonoBehaviour
{
    public Transform headTransform;
    public Transform leftHandTransform;
    public Transform rightHandTransform;
    public TMP_Text displayText;

    private string filePath;

    void Start()
    {
        // Set the file path to save data
        filePath = Application.persistentDataPath + "/HeadHandData.txt";

        // Create or clear the file at the start
        File.WriteAllText(filePath, "Head and Hand Tracking Data\n\n");
    }

    void Update()
    {
        if (displayText != null && headTransform != null && leftHandTransform != null && rightHandTransform != null)
        {
            // Update the text on the canvas
            string data = $"Head Position: {headTransform.position}\n" +
                          $"Left Hand Position: {leftHandTransform.position}\n" +
                          $"Right Hand Position: {rightHandTransform.position}";
            displayText.text = data;

            // Save the data to the file
            SaveDataToFile(data);
        }
    }

    void SaveDataToFile(string data)
    {
        // Append data to the file
        string timeStamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        File.AppendAllText(filePath, $"{timeStamp}\n{data}\n\n");
    }
}