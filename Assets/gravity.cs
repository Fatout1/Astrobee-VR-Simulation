using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float moveIntensity = 0.1f;
    public float rotationSpeed = 5f;

    void Update()
    {
        // Simulate random movement
        transform.position += new Vector3(
            Mathf.PerlinNoise(Time.time, 0) - 0.5f,
            Mathf.PerlinNoise(0, Time.time) - 0.5f,
            Mathf.PerlinNoise(Time.time * 0.5f, Time.time * 0.5f) - 0.5f
        ) * moveIntensity * Time.deltaTime;

        // Slow random rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
