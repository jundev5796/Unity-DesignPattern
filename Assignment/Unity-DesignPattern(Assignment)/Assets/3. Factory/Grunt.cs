using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Grunt : EnemyBase
{
    public GameObject scorePopupPrefab;

    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        health = 50;
        speed = 3f;
        damage = 10f;
    }
    public override void Attack()
    {
        Debug.Log("Grunt가 근접 공격을 합니다.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure your player has the tag "Player"
        {
            GameManager.Instance.AddScore(10); // Add Score

            // Display Score Popup
            ShowScorePopup();

            // Destroy the Grunt after scoring
            Destroy(gameObject);
        }
    }

    private void ShowScorePopup()
    {
        if (scorePopupPrefab)
        {
            GameObject popup = Instantiate(scorePopupPrefab, transform.position, Quaternion.identity);
            Debug.Log("Score popup instantiated at: " + transform.position); // Debugging

            popup.GetComponent<TextMeshProUGUI>().text = "+10"; // Ensure using TMP

            Destroy(popup, 1f); // Destroy after 1 second
        }
        else
        {
            Debug.LogError("Score popup prefab is not assigned!");
        }
    }
}
