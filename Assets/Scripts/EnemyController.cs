using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed , TimeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;

    private Rigidbody2D rb;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;
    private const float DEATH_STATE = 3;

    public float currentState , currentTimeToRevert;

    // Start is called before the first frame update
    void Start()
    {
        currentState = WALK_STATE;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }

        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                rb.velocity = Vector2.left * Speed;
                break;
            case REVERT_STATE:
                sp.flipX = !sp.flipX;
                Speed *= -1;
                currentState = WALK_STATE;
                break;     
        }
        if (currentState != DEATH_STATE)
        {
            anim.SetFloat("Velocity", rb.velocity.magnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
        {
            currentState = IDLE_STATE;
        }
    }

    public void DeathEnemy()
    {
        currentState = DEATH_STATE;
        Debug.Log(currentState);
        StartCoroutine(ActiveDeathEnemy());
        anim.SetBool("isDeath", true);
    }

    IEnumerator ActiveDeathEnemy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }
}
