using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
* küplerin velocity 'si y ekseninde -10 olsun.
* eğer bir küp player ile çarpışırsa creater disable olsun ve sahne 5 saniye sonra yeniden yüklensin.
* küpler y ekseninde -5'e geldiklerinde yok olsun ve arayüzde gösterilecek olan score değişkeni 1 artsın.
*/
public class CubeManager : MonoBehaviour
{
    [SerializeField] GameObject creater;
    [SerializeField] GameObject player;

    //küplerin velocity 'si y ekseninde -10 olsun.
    [SerializeField] float kuphizi=10f;
    Rigidbody rb;
    GameObject panel;
    [SerializeField] float saydamlıkMiktari = 100f;

    checker Checker;

    bool isstoped = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Checker = (checker)FindObjectOfType(typeof(checker));

        rb.angularVelocity = new Vector3(Random.Range(1, 11), Random.Range(1, 11), Random.Range(1, 11));

        panel = GameObject.Find("/Canvas/Panel");
    }

    // Update is called once per frame
    void Update()
    {

        //eğer küp player ile çarpışmadıysa küplerin velocity 'si y ekseninde -10 olsun.
        if (!Checker.iscollided)
        {
            rb.velocity = new Vector3(rb.velocity.x, -kuphizi, rb.velocity.z);
        }
        else if (!isstoped)
        {
            AudioSource ses = GetComponent<AudioSource>();
            ses.Play();
            rb.velocity = Vector3.zero;
            rb.velocity = new Vector3(Random.Range(0, 6), -Random.Range(0, 8), 0);
            isstoped = true;
        }
        //küpler y ekseninde - 5'e geldiklerinde yok olsun ve arayüzde gösterilecek olan score değişkeni 1 artsın.
        if (GetComponent <Transform>().position.y<=-5 && !Checker.iscollided)
        {
            Checker.skorArttir();
            Debug.Log("skor değişti");

            Destroy(gameObject);
            Debug.Log("yokoldu");

        }
    }

    // eğer bir küp player ile çarpışırsa creater disable olsun ve sahne 5 saniye sonra yeniden yüklensin.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Checker.iscollided = true;
            Destroy(GameObject.Find("creater"));
            collision.gameObject.GetComponent<PlayerManager>().enabled = false;
            Invoke("reload", 5f);
            if (!Checker.iscalled)
            {
                InvokeRepeating("saydamligiArttir", 0f, 5f / saydamlıkMiktari);
                Checker.iscalled = true;
            }
        }
    }
    void reload()
    {
        Debug.Log(panel.GetComponent<Image>().color.a);
        //Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    void saydamligiArttir()
    {
        Color32 z = panel.GetComponent<Image>().color;

        panel.GetComponent<Image>().color = new Color32(z.r, z.g, z.b, (byte)(z.a+1));
    }

}
