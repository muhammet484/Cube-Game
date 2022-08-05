using UnityEngine;
/*
 * küplerin velocity'si y ekseninde -10 olsun. 
 * küpler player ile çarpışmışsa velocity'de y'si +10 olsun. 
 * çarpışan küple çarpışan küpler de aynı şekilde yukarı çıksınlar.
 * küpler 7de oluşsun. 7,5'a geldiklerinde yok olsunlar ve skor 1 artsın.
 * 
 * eğer can 0 ise bütün küplerin velocity'si (-5|5,-5|2,-5|5) olsun.
 * 
 * 
 */
public class HittingModeCubeManager : MonoBehaviour
{
    
    float cubeSpeed = 10f;

    float collidedVelocity;
    float collidedHorizontalVelocity;

    public float lossSpeed = 0.5f;

    public bool iscollided = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //collidedVelocity = cubeSpeed / 2;
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x, -cubeSpeed, rb.velocity.z);

        rb.angularVelocity = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
    }

    // Update is called once per frame
    void Update()
    {
        if (iscollided)
        {
            rb.velocity = new Vector3(rb.velocity.x, collidedVelocity, rb.velocity.z);
        }
        if (transform.position.y <= -4 || transform.position.y >= 7.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player" )
        {
            iscollided = true;
            //gameObject.tag = "collidedCube";
            collidedVelocity = rb.velocity.y;
            collidedHorizontalVelocity = (collision.gameObject.GetComponent<Rigidbody>().velocity.x / 3) + (rb.velocity.x / 2);
        }/*
        if (collision.gameObject.tag == "collidedCube")
        {
            iscollided = true;
            gameObject.tag = "collidedCube";
            //lossSpeed += collision.gameObject.GetComponent<HittingModeCubeManager>().lossSpeed;
            collidedVelocity = rb.velocity.y;
        }*/
    }
}
