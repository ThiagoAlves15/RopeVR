using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowDistancePoints : MonoBehaviour
{
    [SerializeField] Transform player;
    private TMP_Text pointsText;

    private float points = 0f;

    void Awake()
    {
        pointsText = gameObject.GetComponent<TextMeshProUGUI>();
        
        pointsText.SetText("0 M");
    }

    void Update()
    {
        points = Mathf.Round(Mathf.Abs(player.transform.position.z));

        pointsText.SetText($"{points} M");
    }
}
