using System.IO;
using UnityEngine;

public class AstrobeeMovementTracker : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        // Set the file path to save data
        filePath = Application.persistentDataPath + "/AstrobeeMovementData.txt";
        // Create or clear the file at the start of the simulation
        File.WriteAllText(filePath, "Astrobee Movement Tracking Data\n");
    }

    void Update()
    {
        // Get the Astrobee's current position and rotation
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // Format the data to be saved
        string data = $"Time: {Time.time:F2}, Position: {position}, Rotation: {rotation.eulerAngles}\n";

        // Append the data to the file
        File.AppendAllText(filePath, data);

        // Optional Debug log to confirm the data is being written
        Debug.Log($"Astrobee data written: {data}");
    }
}