using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    private Rigidbody2D rd;
    private Animator animator;
    private SpriteRenderer sr;
    
    public float velocityx=10;
    public float jumpFor = 30;

    private const int Animation_run = 0;
    private const int Animation_idle = 1;
    private const int Animation_deslizar = 3;
    private const int Animation_saltar = 4;

    // Start is called before the first frame update
    void Start()
    {
        //la primera vez se llama a cada objeto
        //Rigidbody2D peso fisica
        //solo una vez se ejeecuta
        sr= GetComponent<SpriteRenderer>();
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("iniciando .....game object");
    }

    // Update is called once per frame
    void Update()
    {
        //se llama constatemente a un objeto a varios

        // rd.velocity = new Vector2(2,0);

        //if (Input.GetKey())
        //{

        //}
        //  if (Input.GetKeyUp(KeyCode.LeftArrow))
        //   {
        //       sr.flipX = true;
        //   }
        //  if (Input.GetKeyUp(KeyCode.RightArrow))
        //  {
        //       sr.flipX = false;
        //   }


        //  Input.GetKey ->miestras oreciono
        //    down prreciono la tecla
        //  up ->boleano ->preciono la recla



        rd.velocity = new Vector2(0, rd.velocity.y);
        // animator.SetInteger("Estado", 1);
        changeAnimation(Animation_idle);
     

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
          // rd.velocity =Vector2.right *velocityx;
            rd.velocity = new Vector2(velocityx,rd.velocity.y);
            sr.flipX = false;
            //  animator.SetInteger("Estado",0);
            changeAnimation(Animation_run);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            // rd.velocity = Vector2.right * -velocityx;
            rd.velocity = new Vector2(-velocityx,rd.velocity.y);
            sr.flipX = true;
            // animator.SetInteger("Estado", 0);
            changeAnimation(Animation_run);
        }

        if (Input.GetKeyUp(KeyCode.Space))//apenas plaste
        {
            // rd.velocity = Vector2.up * 5;
            rd.AddForce(Vector2.up *jumpFor,ForceMode2D.Impulse);
            changeAnimation(Animation_saltar);
        }
    }
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado",animation);
    }
}
