using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class DelikKontrol : MonoBehaviour
{
    [SerializeField] float delikHiz = 0.05f;
    [SerializeField] int skor = 0;

    [SerializeField] Image skorBar;

    [SerializeField] Text congText;
    [SerializeField] Text toplananKüpText;

    [SerializeField] float skorBarScale = 0.8f;

    private Rigidbody delikFizik;

    bool hareketKontrol = true;

    private float minX = -8.9f, maxX = 8.8f, minZ = -24, maxZ = 25; // Deliğin belirli alanlar içerisinde kalması için min ve max değerleri girildi

    void Start()
    {
        delikFizik = GetComponent<Rigidbody>();
        congText.text = "";
    }

    void FixedUpdate()
    {
        if (hareketKontrol)
        {
            float yatay = CrossPlatformInputManager.GetAxisRaw("Horizontal"); // Joystick için input alındı
            float dikey = CrossPlatformInputManager.GetAxisRaw("Vertical");

            Vector3 pos = new Vector3(yatay, 0, dikey);

            delikFizik.AddForce(pos * delikHiz);

            delikFizik.position = new Vector3(
                Mathf.Clamp(delikFizik.position.x, minX, maxX),
                0.0f,
                Mathf.Clamp(delikFizik.position.z, minZ, maxZ)); // Delik, belirtilen alan dışına çıkamaz

        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "küp")
        {
            other.gameObject.SetActive(false); // Destroy komutuna göre daha az performan harcar

            skor++;
            toplananKüpText.text = "Collect Cubes: " + skor;

            skorBar.transform.localScale = new Vector3(skorBarScale, 0.82f, 0); //skorBarın boyutunu büyüterek ilerleme çubuğu yapıldı
            skorBarScale += 0.1f;

            if (skorBarScale >= 10.8f)
            {
                skorBarScale = 10.8f;

                hareketKontrol = false; // Bölüm sona erdikten sonra tuşlara basılmaması için boolean kullanıldı
                delikFizik.velocity = Vector3.zero;

                congText.text = "BÖLÜM TAMAMLANDI";
                Invoke("LevelDegis", 2f);

            }

        }

        if (other.gameObject.tag == "bonus")
        {
            gameObject.transform.localScale = new Vector3(4, 0.02f, 2); // bonus küp alındığı zaman deliğimizin boyutu büyür
            other.gameObject.SetActive(false);
        }

    }
    void LevelDegis()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

