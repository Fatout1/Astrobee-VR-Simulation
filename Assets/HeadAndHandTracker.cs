using System.IO;
using UnityEngine;

public class HeadHandTracker : MonoBehaviour
{
    public Transform headTransform;
    public Transform leftHandTransform;
    public Transform rightHandTransform;

    private string directoryPath;
    private float lastUpdateTime;
    private float updateInterval = 0.5f; // Update every 0.5 seconds

    private Vector3 lastHeadPosition, lastLeftHandPosition, lastRightHandPosition;
    private Vector3 lastHeadVelocity, lastLeftHandVelocity, lastRightHandVelocity;

    void Start()
    {
        // Set directory path for storing CSV files
        directoryPath = Application.persistentDataPath + "/TrackingData";
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        // Initialize data headers for each file
        InitializeCSV("Head_X");
        InitializeCSV("Head_Y");
        InitializeCSV("Head_Z");
        InitializeCSV("Left_X");
        InitializeCSV("Left_Y");
        InitializeCSV("Left_Z");
        InitializeCSV("Right_X");
        InitializeCSV("Right_Y");
        InitializeCSV("Right_Z");

        // Initialize previous values
        lastHeadPosition = headTransform.position;
        lastLeftHandPosition = leftHandTransform.position;
        lastRightHandPosition = rightHandTransform.position;
    }

    void Update()
    {
        if (Time.time - lastUpdateTime >= updateInterval)
        {
            float timestamp = Mathf.Round(Time.time * 100) / 100f; // Limit to 2 decimal places

            // Calculate velocities (difference in position over time)
            Vector3 headVelocity = (headTransform.position - lastHeadPosition) / updateInterval;
            Vector3 leftHandVelocity = (leftHandTransform.position - lastLeftHandPosition) / updateInterval;
            Vector3 rightHandVelocity = (rightHandTransform.position - lastRightHandPosition) / updateInterval;

            // Calculate accelerations (difference in velocity over time)
            Vector3 headAcceleration = (headVelocity - lastHeadVelocity) / updateInterval;
            Vector3 leftHandAcceleration = (leftHandVelocity - lastLeftHandVelocity) / updateInterval;
            Vector3 rightHandAcceleration = (rightHandVelocity - lastRightHandVelocity) / updateInterval;

            // Save data to CSV files
            SaveData("Head_X", timestamp, headTransform.position.x, headVelocity.x, headAcceleration.x);
            SaveData("Head_Y", timestamp, headTransform.position.y, headVelocity.y, headAcceleration.y);
            SaveData("Head_Z", timestamp, headTransform.position.z, headVelocity.z, headAcceleration.z);
            SaveData("Left_X", timestamp, leftHandTransform.position.x, leftHandVelocity.x, leftHandAcceleration.x);
            SaveData("Left_Y", timestamp, leftHandTransform.position.y, leftHandVelocity.y, leftHandAcceleration.y);
            SaveData("Left_Z", timestamp, leftHandTransform.position.z, leftHandVelocity.z, leftHandAcceleration.z);
            SaveData("Right_X", timestamp, rightHandTransform.position.x, rightHandVelocity.x, rightHandAcceleration.x);
            SaveData("Right_Y", timestamp, rightHandTransform.position.y, rightHandVelocity.y, rightHandAcceleration.y);
            SaveData("Right_Z", timestamp, rightHandTransform.position.z, rightHandVelocity.z, rightHandAcceleration.z);

            // Update last recorded values
            lastHeadPosition = headTransform.position;
            lastLeftHandPosition = leftHandTransform.position;
            lastRightHandPosition = rightHandTransform.position;

            lastHeadVelocity = headVelocity;
            lastLeftHandVelocity = leftHandVelocity;
            lastRightHandVelocity = rightHandVelocity;

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