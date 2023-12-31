using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

private Rigidbody2D myRigidbody;
public float characterSpeed = 10f;
public GameObject projectilePrefab;
private float jumpForce= 10;

private float launchVelocity=20f;
private bool isGround;
private bool lookRight;
public Text Can;
private int can;



    // Start is called before the first frame update
    void Start()
    {

       can=5;

        isGround= true;
        lookRight=true;
        myRigidbody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        basicMovements(horizontal);
        changeDirection(horizontal);
    }

void OnCollisionEnter2D(Collision2D other){
    if(other.gameObject.tag == "ground"){
        isGround=true;
    }
     if(other.gameObject.tag == "dusman"){
        canayar();
        if(can==0){
             Destroy(gameObject);//enemy
        }
    
    
     }

}
public void canayar()
	{ 
		can--;
		Can.text = "Kalan Canın:" + can.ToString();
	}



    public void basicMovements(float horizontal){
        myRigidbody.velocity= new Vector2(horizontal*characterSpeed, myRigidbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            myRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGround=false;
        }
        if(Input.GetKeyDown(KeyCode.T)){
ThrowKnife();

        }
    }
    public void changeDirection(float horizontal){
        if((horizontal > 0 && !lookRight) || (horizontal < 0 && lookRight)){
            Vector3 direction = transform.localScale;
            direction.x *= -1;
            transform.localScale=direction;
            lookRight = !lookRight;
        }
    }

    public void ThrowKnife(){
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();
        Vector2 launchDirection;

        if(lookRight)
        launchDirection = new Vector2(transform.right.x, transform.right.y ) * launchVelocity;
        else
         launchDirection = new Vector2(-transform.right.x, -transform.right.y ) * launchVelocity;

         rb. velocity = launchDirection;
    }
}
