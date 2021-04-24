using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    public Transform Player;
    public Text scoreText;

    void Start()
    {
        scoreText.text = "HELL 0";
    }

    void Update()
    {
        scoreText.text = Mathf.Floor(Player.position.y).ToString();
    }
}
