using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    [Header("Sound")]
    [SerializeField] private AudioClip firetrapSound;
    

    private bool triggered; // when the trap gets triggered
    private bool active; // when the trap is active

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();

            if(!triggered)
                StartCoroutine(ActivateFireTrap());

            if(active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }

    private IEnumerator ActivateFireTrap()
    {
        // turn the sprite red to notify the player and trigger the trap
        triggered = true;
        spriteRend.color = Color.red;

        // wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(firetrapSound);
        spriteRend.color = Color.white; // turn the sprite back
        active = true;
        anim.SetBool("activated", true);

        // wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activationDelay);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}