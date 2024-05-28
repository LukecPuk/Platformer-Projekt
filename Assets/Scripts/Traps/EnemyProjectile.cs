using UnityEngine;

public class EnemyProjectile : EnemyDamage // Will damage the player every time they touch
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private void OnTriggerEnter2D(Collider2D collision)
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    {
        hit = true;
        base.OnTriggerEnter2D(collision); // Execute logic from parent script first
        coll.enabled = false;

        if (anim != null)
            anim.SetTrigger("blood");
        else
            gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}