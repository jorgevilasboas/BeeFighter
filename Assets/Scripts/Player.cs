using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	




    public Rigidbody2D rb;
    public bool Analogico = true;
    public float Velocity = 5;
    public GameObject gm;
    Grid grid;

    
    // Use this for initialization
    void Start()
    {
      
        grid = (Grid)gm.GetComponent(typeof(Grid));
     
    }

    // Update is called once per frame
    void Update()
    {

     //   Debug.Log(coletados.Count);



        float v; float h;


        bool moverCima = Input.GetKey(KeyCode.W);
        bool moverBaixo = Input.GetKey(KeyCode.S);
        bool moverDireita = Input.GetKey(KeyCode.D);
        bool moverEsquerda = Input.GetKey(KeyCode.A);

        //Analogico

        if (Analogico)
        {

            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
        }

        //Digital
        else
        {

            if (moverCima)
            {
                v = 1;
            }
            else if (moverBaixo)
            {
                v = -1;
            }
            else
            {
                v = 0;
            }

            if (moverDireita)
            {
                h = 1;
            }
            else if (moverEsquerda)
            {
                h = -1;
            }
            else
            {
                h = 0;
            }
        }
        this.rb.velocity = new Vector2(h * Velocity, v * Velocity);



        //Identifica SpaceBar

     
    






    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
       
        grid.trataColisao(collider.gameObject);
       
        

    }
}
