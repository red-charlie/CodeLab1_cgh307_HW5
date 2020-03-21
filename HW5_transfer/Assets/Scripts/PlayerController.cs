using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public static PlayerController instance;

    #region input keys
    public KeyCode forwardButton;
    public KeyCode backButton;
    public KeyCode leftButton;
    public KeyCode rightButton;
    public KeyCode jumpButton;

    #endregion
    Rigidbody rb;
    public float force = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(forwardButton))
        {
            rb.AddForce(Vector3.forward * force); 
        }

        if (Input.GetKey(backButton))
        {
            rb.AddForce(Vector3.back * force); 
        }

        if (Input.GetKey(leftButton))
        {
            rb.AddForce(Vector3.left * force); 
        }

        if (Input.GetKey(rightButton))
        {
            rb.AddForce(Vector3.right * force); //apply to the right mult by the "force" var
        }
        
        if (Input.GetKeyDown(jumpButton))
        {
            rb.AddForce(Vector3.up * (2 * force), ForceMode.Impulse);//jump a lil
        }
    }
}
