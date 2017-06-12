using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {    

    public Rigidbody2D rb;
    public GameObject gm;
    Grid grid;

    public float speed = 3.5f;
    public float currentRotation;
    public float rotationSensitivity = 50.0f;

    
    // Use this for initialization
    void Start()
    {
      
        grid = (Grid)gm.GetComponent(typeof(Grid));
     
    }

    void FixedUpdate()
    {
        MoveForward();
        Rotate();
    }

    void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }

    // Update is called once per frame
    void Update()
    {
        float h;        
        h = Input.GetAxis("Horizontal");
        currentRotation -= rotationSensitivity * Time.deltaTime * h;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
       
        grid.trataColisao(collider.gameObject);
       
        

    }
}
