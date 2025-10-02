using UnityEngine;
using UnityEngine.UI;

public class BigHoops : MonoBehaviour {
    [Header("Set in Inspector")]
    public Text uitScore;  // The Score Text
    
    [Header("Set Dynamically")]
    public static int Score;

    // Singleton reference
    private static BigHoops instance;

    void Awake() {
        instance = this;  // Store the one active BigHoops instance
    }

    void Start() {
        Score = 0;
        UpdateGUI();
    }

    void UpdateGUI() {
        uitScore.text = "Score " + Score;
    }

    public static void PlayerScored() {
        Score++;
        if (instance != null) {
            instance.UpdateGUI();
        }
    }
}
