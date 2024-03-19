using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    //public float maxLeft = -10;
    //public float maxRight = 10;
    public Transform leftBoundary;
    public Transform rightBoundary;

    public LayerMask mask;

    public int score = 0;
    public float speed = 0.2f;

    private Vector3 cachedMovementVector;
    private Rigidbody rb;
    private GameManager gm;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //Mi prendo il valore dell'input
        float xMove = Input.GetAxis("Horizontal");
        //float a = Input.GetAxisRaw("Horizontal");

        float zMove = Input.GetAxis("Vertical");
        //Costruisco il vettore movimento
        cachedMovementVector = new Vector3(xMove, 0, zMove).normalized;


        //Applico il movimento
        //transform.Translate(movementVector * speed * Time.deltaTime);
        //transform.position += movementVector * speed * Time.deltaTime;

        //if (transform.position.x < leftBoundary.position.x)
        //{
        //    transform.position = new Vector3(leftBoundary.position.x, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x > rightBoundary.position.x)
        //{
        //    transform.position = new Vector3(rightBoundary.position.x, transform.position.y, transform.position.z);
        //}

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 5, Color.magenta);
        
        if (Physics.Raycast(ray, out hit, 5, mask))
        {
            
        }
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(transform.position + cachedMovementVector * speed);
        rb.velocity = cachedMovementVector * speed;
    }

    int MyFunction(int value, float a, bool b)
    {
        //Qua dentro va il codice
        Debug.Log("Il valore è " + value);

        return value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Trap"))
        {
            //Chiamo Game Over
            //gm.GameOver();
            //if(OnPlayerDeath != null)
            OnPlayerDeath?.Invoke();
        }
    }
}

