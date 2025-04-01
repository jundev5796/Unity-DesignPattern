using UnityEngine;

// �̺�Ʈ ������ (������)
public class UIHealthDisplay : MonoBehaviour
{
    void Start()
    {
        // �̺�Ʈ ����
        EventManager.Instance.AddListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }

    private void OnDestroy()
    {
        // ��ü�� �����ɶ� �����ϴ� �Լ�
        EventManager.Instance.RemoveListener("PlayerHealthChanged", OnPlayerHealthChanged);
        EventManager.Instance.RemoveListener("PlayerDied", OnPlayerDied);
    }

    private void OnPlayerHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI Update: Player health is changed to {health}");
        // �����δ� ���⼭ UI��Ҹ� ������Ʈ�մϴ�.
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI Update: Player Died!");
        // ���� ���� ȭ�� ǥ�� ���� ���� ����
    }

    void Update()
    {
        
    }
}
