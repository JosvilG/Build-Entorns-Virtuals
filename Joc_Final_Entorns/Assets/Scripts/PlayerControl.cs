using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    //Variables Control de Personaje

    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;
    public float playerSpeed;
    float sprint;
    private Vector3 movePlayer;
    public float gravity;
    public float fallVelocity;
    Rigidbody TheRigidbody;

    public Camera mainCamera;
    public GameObject jo;
    private Vector3 camForward;
    private Vector3 camRight;

    [SerializeField]
    private GameObject model;

    //Variables Vida 

    public GameObject GameOverText;
    public bool isDead = false;
    public bool invencible = false;
    public static bool hit = false;

    public static bool MenuActive = false;
    public GameObject MenuInGame;

    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private bool menuObert=false;
    public AudioClip itemsoundclip;
    public AudioClip dmgsoundclip;
    public float itemSoundVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sprint = playerSpeed * 2;
        Time.timeScale = 1;
        player = GetComponent<CharacterController>();
        TheRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //ActivaMenu
        if (Input.GetKeyDown(KeyCode.Escape) && MenuActive==true)
        {
            DesactivaMenu();
           
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && MenuActive == false)
        {

                ActivaMenu();
            
        }


        //Debug.Log(Vida.vida);
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();
        //depent de la posició de la camara + el input del jugador es mou cap a un lloc i rota
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        
        movePlayer = movePlayer * playerSpeed;
        
        //el jugador sempre mira cap a on esta apretant
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        player.Move(movePlayer * Time.deltaTime);
        

        

        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            visualTime = timer;
            timer = timer - waitTime;
        }
        
        if (hit == true)
        {
            perdreVida(EnemicControler.AtacEnemic);

        }
        if (isDead && Input.anyKeyDown)
        {
            StartCoroutine(HasMort());
            if (ControlEscena.currentScene == "Entorns_ExteriorCastell")
            {
                //Debug.Log("Control: " + ControlEscena.currentScene);
                Time.timeScale = 1;
                canviaEscena.darrera = true;
            }
            else
            {
                SceneManager.LoadScene(ControlEscena.currentScene);
                Time.timeScale = 1;
            }
            //SceneManager.LoadScene(ControlEscena.currentScene);
            
        }
        CheckLife();
        StartCoroutine(ReiniciaCaiguda());
    }

    private void DesactivaMenu()
    {
        Time.timeScale = 1;
        MenuInGame.SetActive(false);
        MenuActive = false;
        Debug.Log("desact");
    }

    private void ActivaMenu()
    {
        Debug.Log("Pausa");
        Time.timeScale = 0;
        MenuInGame.SetActive(true);
        MenuActive = true;

    }

    void perdreVida(int hp)
    {
        if (invencible) return;

        HUD.vida -= hp;
        StartCoroutine(BecomeTemporarilyInvincible());
        
        //Vida.vida -= 10;
        hit = false;
    }

    private IEnumerator HasMort()
    {
        hit = false;
        this.GetComponent<AttackControl>().enabled = true;
        jo.transform.position = posicioAlMon.proximaPosicio;
        HUD.vida = HUD.maxVida;
        yield return new WaitForSeconds(3.0f);
        StopCoroutine(HasMort());
    }

    private IEnumerator ReiniciaCaiguda()
    {
        yield return new WaitForSeconds(1.0f);
        fallVelocity = -20f;
        StopCoroutine(ReiniciaCaiguda());
    }

        //invencibilitat temporal
        private IEnumerator BecomeTemporarilyInvincible()
    {
        //Debug.Log("Player turned invincible!");
        invencible = true;

        for (float i = 0; i <= 1; i += 0.15f)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(0.15f);
        }

        //Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        invencible = false;
        StopCoroutine(BecomeTemporarilyInvincible());
    }

    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }

    //El que fa aqui es saber la posicio de la camara
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity()
    {
        if (player.isGrounded)//si esta tocant el terra mante una gravetat constant
        {
            fallVelocity = 0;
            movePlayer.y = fallVelocity;
        }
        else//si esta en el aire constantment aumenta la gravetat fent que aumenti la velocitat de caiguda
        {
            fallVelocity -= gravity * Time.deltaTime;//fallvelocity va augmentant el valor cada vegada, esta perque no es reinicii el valor
            movePlayer.y = fallVelocity;
        }
    }

    void CheckLife()
    {

        if (HUD.vida <= 0)
        {
            this.GetComponent<AttackControl>().enabled = false;

            isDead = true;
            GameOverText.SetActive(true);
            Time.timeScale = 0;
            EnemicControler.contadorMorts = 0;
            
            
            if (Input.anyKey)
            {
                Debug.Log("Aaaaaaaaaaaa");
                Debug.Log("Control: " + ControlEscena.currentScene);
                if (ControlEscena.currentScene == "Entorns_ExteriorCastell")
                {
                    //Debug.Log("Control: " + ControlEscena.currentScene);
                    Time.timeScale = 1;
                    canviaEscena.darrera = true;
                }
                else
                {
                    SceneManager.LoadScene(ControlEscena.currentScene);
                    Time.timeScale = 1;
                }
                
            }
            


        }
    }

}
