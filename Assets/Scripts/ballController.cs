using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour
{
public int force;
int scoreMerah;
int scoreBiru;
Text scoreUIMerahA;
Text scoreUIMerahB;
Text scoreUIBiruA;
Text scoreUIBiruB;
Rigidbody2D rigid;
GameObject panelSelesai;
Text txPemenang;
    // Start is called before the first frame update
    void Start()
    {
    rigid = GetComponent<Rigidbody2D>();
    Vector2 arah = new Vector2(0,2).normalized;
    rigid.AddForce(arah*force);
    scoreBiru=0;
    scoreMerah=0;
    scoreUIBiruA = GameObject.Find("scoreBiruA").GetComponent<Text>();
    scoreUIBiruB = GameObject.Find("scoreBiruB").GetComponent<Text>();
    scoreUIMerahA = GameObject.Find("scoreMerahA").GetComponent<Text>();
    scoreUIMerahB = GameObject.Find("scoreMerahB").GetComponent<Text>();
    panelSelesai = GameObject.Find("panelSelesai");
    panelSelesai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tampilScore(){
        Debug.Log("Score Merah: "+ scoreMerah + "Score Biru: "+ scoreBiru);
        scoreUIBiruA.text = scoreBiru + "";
        scoreUIBiruB.text = scoreBiru + "";
        scoreUIMerahA.text = scoreMerah + "";
        scoreUIMerahB.text = scoreMerah + "";
    }

    private void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "gawangAtas"){
            scoreBiru += 1;
            tampilScore();
            if(scoreBiru == 5){
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("winInfo").GetComponent<Text>();
                txPemenang.text = "Player Biru Menang!";
                Destroy(gameObject);
                return;
            }
            resetBall();
            Vector2 arah = new Vector2(0,2).normalized;
            rigid.AddForce(arah*force);
        }
        if(coll.gameObject.name == "gawangBawah"){
            scoreMerah += 1;
            tampilScore();
            if(scoreMerah == 5){
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("winInfo").GetComponent<Text>();
                txPemenang.text = "Player Merah Menang!";
                Destroy(gameObject);
                return;
            }
            resetBall();
            Vector2 arah = new Vector2(0,-2).normalized;
            rigid.AddForce(arah*force);
        }
        if(coll.gameObject.name == "pemukulAtas" || coll.gameObject.name == "pemukulBawah"){
            float sudut = (transform.position.x - coll.transform.position.x)*5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(arah * force * 2);
        }
    }

    void resetBall(){
        transform.localPosition = new Vector2(0,0);
        rigid.velocity = new Vector2(0,0);
    }
}
