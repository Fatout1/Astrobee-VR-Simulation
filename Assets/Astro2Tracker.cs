using UnityEngine;
using TMPro;

public class AstrobeeDataDisplay : MonoBehaviour
{
    public Transform astrobeeTransform; // Reference to the Astrobee object
    public TMP_Text displayText; // Reference to the TextMeshPro UI element

    void Update()
    {
        if (astrobeeTransform != null && displayText != null)
        {
            Vector3 position = astrobeeTransform.position;
            Quaternion rotation = astrobeeTransform.rotation;
            displayText.text = $"Astrobee Position: {position}\nAstrobee Rotation: {rotation.eulerAngles}";
        }
    }
}