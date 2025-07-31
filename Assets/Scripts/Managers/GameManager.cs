using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Health playerHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        playerHealth = GetComponent<Health>();
    }
}
