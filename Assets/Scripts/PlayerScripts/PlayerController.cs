using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string AnimAttack = "Attack", AnimRun = "Run", AnimDeath = "Death";
    [SerializeField] private Animator animator;
    [SerializeField] private MovementJoystick movementJoystick;
    [SerializeField] private float speed;
    [SerializeField] private GameObject panelLost;
    [SerializeField] private float health;

    private Rigidbody2D _rigidbody;
    private bool Right = true;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            animator.SetBool(AnimRun, true);
            _rigidbody.velocity = new Vector2(movementJoystick.joystickVec.x * speed, movementJoystick.joystickVec.y * speed);
        }
        else
        {
            animator.SetBool(AnimRun, false);
            _rigidbody.velocity = Vector2.zero;
        }

        if (Right == false && movementJoystick.joystickVec.x > 0)
        {
            Flip();
        }
        else if (Right == true && movementJoystick.joystickVec.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Right = !Right;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            if (health == 0)
            {
                animator.SetBool(AnimDeath, true);
                panelLost.SetActive(true);
            }
        }
    }
}
