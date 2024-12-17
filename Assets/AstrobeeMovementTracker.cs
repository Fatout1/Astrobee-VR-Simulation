using System.IO;
using System;
using UnityEngine;

public class AstrobeeMovementTracker : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        // Set the file path to save data
        filePath = Application.persistentDataPath + "/AstrobeeMovementData.csv";

        // Create or clear the file at the start and write the header
        File.WriteAllText(filePath, "Timestamp,Position_X,Position_Y,Position_Z,Rotation_X,Rotation_Y,Rotation_Z\n");
    }

    void Update()
    {
        // Get the Astrobee's current position and rotation
        Vector3 position = transform.position;
        Vector3 rotation = transform.rotation.eulerAngles;

        // Format the data into CSV
        string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string data = $"{timeStamp},{position.x:F3},{position.y:F3},{position.z:F3}," +
                      $"{rotation.x:F3},{rotation.y:F3},{rotation.z:F3}";

        // Append data to the file
        File.AppendAllText(filePath, data + "\n");
    }
}