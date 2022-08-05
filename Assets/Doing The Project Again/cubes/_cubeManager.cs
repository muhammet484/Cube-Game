using UnityEngine;
using UnityEngine.SceneManagement;
/*
* küplerin velocity 'si y ekseninde -10 olsun.
* eğer bir küp player ile çarpışırsa creater disable olsun ve sahne 5 saniye sonra yeniden yüklensin.
* küpler y ekseninde -5'e geldiklerinde yok olsun ve arayüzde gösterilecek olan score değişkeni 1 artsın.
*/
/*
 * herhangi bir küp çarpıştığında bütün küpler rastgele hız alsın
 */

public class _cubeManager : MonoBehaviour
{
    Rigidbody rb;

    float kuphizi = 10f;

    kontrolEdici KontrolEdici;

    bool isStoped = false; 
    // Start is called before the first frame update
    void Start()
    {
        KontrolEdici = (kontrolEdici)FindObjectOfType(typeof(kontrolEdici));

        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x,-kuphizi,0);

        rb.angularVelocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KontrolEdici.iscollided && !isStoped)
        {
            rb.velocity = new Vector3(Random.Range(-5f,5f), Random.Range(-5f, 0f), Random.Range(-5f, 5f));
            isStoped = true;
            AudioSource ses = GetComponent<AudioSource>();
            ses.Play();
        }

        
        if (transform.position.y < -6)
        {
            //score'u 1 arttır
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            KontrolEdici.iscollided = true;
            Destroy(GameObject.Find("creater"));
            collision.gameObject.GetComponent<_playerManager>().enabled = false;
            Invoke("reload", 5f);

        }
    }

    void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
