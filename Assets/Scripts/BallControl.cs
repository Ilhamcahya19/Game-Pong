using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

     // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

     // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
 
    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
 
        // Mulai game
        RestartGame();

    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
 
        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
     void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
 
        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        //float yrin = Random.Range(-xInitialForce, yInitialForce);
        float rd = Random.Range(0, 2);
        if (rd < 1.0f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-xInitialForce, yInitialForce));

        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(xInitialForce, yInitialForce));
        }
    }
     // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
