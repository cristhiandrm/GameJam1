using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;

    public Transform spawnPosition;

    Animator anim;
    Rigidbody2D rb2d;   // Recuperamos el componente de Rigidbody, declarandolo. Al igual que con el de Animator
    Vector2 mov;

    CircleCollider2D attackCollider;


    public Image healthBar;

    public float initialLife = 251;
    public float Life;
    public float takeDmg;

    public bool gameOver = false;

    public GameObject gameOverUi;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();

        attackCollider.enabled = false;
        Life = initialLife;       

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            return;
        }
        Movement();
        Animations();
        SwordAttack();
        RestartPosition();
        healthBar.fillAmount = Life / initialLife;
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    void Animations()
    {
        if (moveInput != Vector2.zero)            // Comprobamos que el vector 'mov' es diferente de vacío y así solo actualizar la animación si
        {                                     // presiono uno de los botones
            anim.SetFloat("moveX", mov.x);
            anim.SetFloat("moveY", mov.y);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    void SwordAttack()
    {
        // Buscamos el estado actual mirando la información del animador
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attaking = stateInfo.IsName("Player_Attack");  // Nos da la información de si se esta reproduciendo la animación o no

        // Detectamos el ataque, tiene prioridad por lo que va abajo del todo
        //if (Input.GetKeyDown("space"))
        if (Input.GetKeyDown("space") && !attaking)
        {
            anim.SetTrigger("Attacking");
        }

        // Vamos actualizando la posición de la colisión de ataque
        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x / 4, mov.y / 4);

        // Activamos el colider a la mitan de la animación de ataque
        if (attaking)
        {
            float playbacktime = stateInfo.normalizedTime;  // Guardamos el tiempo que ha empezado la animación
            //print(playbacktime);
            if (playbacktime > 0.33 && playbacktime < 0.66) attackCollider.enabled = true;  // En el 2/3 se activa la colisión
            else attackCollider.enabled = false;
        }
    }

    public void RestartPosition()
    {
        if (Input.GetKeyDown("f"))
        {
            transform.position = spawnPosition.position;
        }
        
    }

    public void TakeDamage()
    {

        healthBar.fillAmount = Life / initialLife;

        if (Life <= 0)
            Destroy(gameObject);
    }

    public void damage()
    {
        Life -= 50;
        if (Life <= 0)
        {
            gameOver = true;
            gameOverUi.SetActive(true);
        }
    }
}
