using System;
using TMPro;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{

   


    // Ad Soyad: Emirhan Sabancıoğlu
    // Öğrenci Numarası: 232011022

    // Soru 1: Karakteri yön tuşları ile hareket ettiren kodu, HareketEt fonksiyonu içerisine yazınız.
    // Soru 2: Karakterin zıplamasını sağlaması beklenen Zipla metodu doğru bir şekilde çalışmıyor, koddaki hatayı düzeltin.
    // Soru 3: Karakterin 'Engel' tag'ine sahip objeye temas ettiğinde metin objesine "Oyun Bitti!" yazısını yazdırınız.
    // Soru 4: Karakterin 'Puan' tag'ine sahip objeye temas ettiğinde skoru 1 arttırınız ve metin objesine yazdırınız.

    // Not: Engel ve Puan nesnelerinin isTrigger özelliği aktiftir.
    
  

    public TMP_Text metin;
    private Rigidbody2D karakterRb;

    public float hiz = 5f;
    public float ziplamaGucu = 5f;

    public int skor = 0;



    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Yazdığınız metodları çağırınız.
        HareketEt();
        Zipla();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Soru 3 ve soru 4 burada çözülecek.
        if (other.CompareTag("Engel"))
        {
            metin.text = "Oyun Bitti!";
        }
        else if (other.CompareTag("Puan"))
        {
            skor++;
            metin.text = "Skor: " + skor;
        }
    }

    void HareketEt()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            karakterRb.AddForce(Vector2.left * hiz * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            karakterRb.AddForce(Vector2.right * hiz * Time.deltaTime);
        }
    }



    void Zipla()
    {
        // Space tuşuna basınca karakter zıplamalı ancak aşağıdaki kod hatalı.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 ziplamaYonu = new Vector2(0, 1);
            karakterRb.AddForce(ziplamaYonu * ziplamaGucu, ForceMode2D.Impulse);
        }
    }
}
