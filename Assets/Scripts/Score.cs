using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public BoidVicinityManager boidVicinityManager;

    private TextMeshProUGUI scoreText;

    void Start(){
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        scoreText.text = boidVicinityManager.Score.ToString();
    }
}
