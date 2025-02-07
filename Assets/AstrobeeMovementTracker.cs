using System.IO;
using UnityEngine;

public class AstrobeeMovementTracker : MonoBehaviour
{
    private string directoryPath;
    private float lastUpdateTime;
    private float updateInterval = 0.5f; // Update every 0.5 seconds

    private Vector3 lastPosition;
    private Vector3 lastVelocity;

    void Start()
    {
        // Set directory path for storing CSV files
        directoryPath = Application.persistentDataPath + "/TrackingData";
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        // Initialize data headers for each file
        InitializeCSV("Astrobee_X");
        InitializeCSV("Astrobee_Y");
        InitializeCSV("Astrobee_Z");

        // Initialize previous values
        lastPosition = transform.position;
    }

    void Update()
    {
        if (Time.time - lastUpdateTime >= updateInterval)
        {
            float timestamp = Mathf.Round(Time.time * 100) / 100f; // Limit to 2 decimal places

            // Calculate velocity (change in position over time)
            Vector3 velocity = (transform.position - lastPosition) / updateInterval;

            // Calculate acceleration (change in velocity over time)
            Vector3 acceleration = (velocity - lastVelocity) / updateInterval;

            // Save data to CSV files
            SaveData("Astrobee_X", timestamp, transform.position.x, velocity.x, acceleration.x);
            SaveData("Astrobee_Y", timestamp, transform.position.y, velocity.y, acceleration.y);
            SaveData("Astrobee_Z", timestamp, transform.position.z, velocity.z, acceleration.z);

            // Update last recorded values
            lastPosition = transform.position;
            lastVelocity = velocity;

            lastUpdateTime = Time.time;
        }
    }

    void InitializeCSV(string filename)
    {
        string filePath = Path.Combine(directoryPath, filename + ".csv");
        File.WriteAllText(filePath, "Timestamp, Position, Velocity, Acceleration\n"); // Set CSV headers
    }

    void SaveData(string filename, float timestamp, float position, float velocity, float acceleration)
    {
        string filePath = Path.Combine(directoryPath, filename + ".csv");
        string data = $"{timestamp:F2}, {position:F4}, {velocity:F4}, {acceleration:F4}\n";
        File.AppendAllText(filePath, data);
    }
}