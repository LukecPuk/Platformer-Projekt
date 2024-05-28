using UnityEngine;

public class EnemyDaggerHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        // Get the current local scale of the dagger holder
        Vector3 localScale = transform.localScale;

        // Match the direction of the enemy without changing the size
        localScale.x = Mathf.Sign(enemy.localScale.x) * Mathf.Abs(localScale.x);

        // Apply the adjusted local scale back to the dagger holder
        transform.localScale = localScale;
    }
}