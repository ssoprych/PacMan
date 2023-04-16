using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagMan : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Animator Anim;
    public Transform movePoint;
    public float Speed = 5f;
    public LayerMask whatStopsMovement;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _ghostEat;
    [SerializeField] private GameObject _particlesPlayer, _particlesYellow, _particlesRed, _particlesOrange, _particlesBlue, _particlesGreen;

    private void Start()
    {
        movePoint.parent = null;
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

    }

    public void Move()
    {
        Rb.position = Vector3.MoveTowards(Rb.position, movePoint.position, Speed * Time.deltaTime);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
          if (Vector3.Distance(Rb.position, movePoint.position) <= .01f)
          {
            if (vertical == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .1f, whatStopsMovement))
                    movePoint.position += new Vector3(0f, 1f, 0f);
                Anim.SetFloat("MoveX", 0);
                Anim.SetFloat("MoveY", 1);
            }
            else if (vertical == -1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, whatStopsMovement))
                    movePoint.position += new Vector3(0f, -1f, 0f);
                Anim.SetFloat("MoveX", 0);
                Anim.SetFloat("MoveY", -1);
            }
            else if (horizontal == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .1f, whatStopsMovement))
                    movePoint.position += new Vector3(1f, 0f, 0f);
                Anim.SetFloat("MoveY", 0);
                Anim.SetFloat("MoveX", 1);
            }
            else if (horizontal == -1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, whatStopsMovement))
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                Anim.SetFloat("MoveY", 0);
                Anim.SetFloat("MoveX", -1);
            }
          }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("GreenGhost"))
            {
                if (GameManager.Instance.ChaseMode == true)
                {
                    Destroy(collision.gameObject);
                    AudioManager.Instance.PlaySound2(_ghostEat);
                    GameManager.Instance.GhostEaten++;
                    GameManager.Instance.Score += 200;
                    GameManager.Instance.IsGreen = true;
                    Instantiate(_particlesGreen, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                
                }
                else
                {
                    Deth();
                }
            }
            if (collision.gameObject.CompareTag("YellowGhost"))
            {
                if (GameManager.Instance.ChaseMode == true)
                {
                    Destroy(collision.gameObject);
                    AudioManager.Instance.PlaySound2(_ghostEat);
                    GameManager.Instance.GhostEaten++;
                    GameManager.Instance.Score += 200;
                    GameManager.Instance.IsYellow = true;
                    Instantiate(_particlesYellow, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }
                else
                {
                    Deth();
                }
                
            }
            if (collision.gameObject.CompareTag("BlueGhost"))
            {
                if (GameManager.Instance.ChaseMode == true)
                {
                    Destroy(collision.gameObject);
                    AudioManager.Instance.PlaySound2(_ghostEat);
                    GameManager.Instance.GhostEaten++;
                    GameManager.Instance.Score += 200;
                    GameManager.Instance.IsBlue = true;
                    Instantiate(_particlesBlue, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
                else
                {
                    Deth();
                }

            }
            if (collision.gameObject.CompareTag("RedGhost"))
            {
                if (GameManager.Instance.ChaseMode == true)
                {
                    Destroy(collision.gameObject);
                    AudioManager.Instance.PlaySound2(_ghostEat);
                    GameManager.Instance.GhostEaten++;
                    GameManager.Instance.Score += 200;
                    GameManager.Instance.IsRed = true;
                    Instantiate(_particlesRed, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }
                else
                {
                    Deth();
                }
            }
            if (collision.gameObject.CompareTag("OrangeGhost"))
            {
                if (GameManager.Instance.ChaseMode == true)
                {
                    Destroy(collision.gameObject);
                    AudioManager.Instance.PlaySound2(_ghostEat);
                    GameManager.Instance.GhostEaten++;
                    GameManager.Instance.Score += 200;
                    GameManager.Instance.IsOrange = true;
                    Instantiate(_particlesOrange, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }
                else
                {
                    Deth();
                }
            }
        }
    

    private void Deth()
    {
        GameManager.Instance.Death = true;
        AudioManager.Instance.PlaySound(_deathSound);
        GameManager.Instance.PacHealth--;
        Instantiate(_particlesPlayer, transform.position, transform.rotation);
        GameManager.Instance.Score -= 100;
    }

    private void Update()
    {
        Move();
    }
}
