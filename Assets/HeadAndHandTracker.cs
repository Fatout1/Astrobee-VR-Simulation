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
        filePath = Application.persistentDataPath + "/HeadHandData.csv";

        // Create or clear the file at the start and write the header
        File.WriteAllText(filePath, "Timestamp,Head_X,Head_Y,Head_Z,Left_X,Left_Y,Left_Z,Right_X,Right_Y,Right_Z\n");
    }

    void Update()
    {
        if (displayText != null && headTransform != null && leftHandTransform != null && rightHandTransform != null)
        {
            // Get the positions
            Vector3 headPos = headTransform.position;
            Vector3 leftPos = leftHandTransform.position;
            Vector3 rightPos = rightHandTransform.position;

            // Format the data into CSV
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string data = $"{timeStamp},{headPos.x:F3},{headPos.y:F3},{headPos.z:F3}," +
                          $"{leftPos.x:F3},{leftPos.y:F3},{leftPos.z:F3}," +
                          $"{rightPos.x:F3},{rightPos.y:F3},{rightPos.z:F3}";

            // Update display text
            displayText.text = $"Head: {headPos}\nLeft: {leftPos}\nRight: {rightPos}";

            // Append data to the file
            File.AppendAllText(filePath, data + "\n");
        }
    }
}