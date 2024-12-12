using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class clicker : MonoBehaviour
{
    public TextMeshProUGUI monTextUI;
    public Image monImage;
    public Image imageWin;
    public TextMeshProUGUI texteWin;
    public TextMeshProUGUI textScore;

    private IEnumerator coroutine;

    public float degatinfiger = 0; 
    public int ScoreTotal;
    public float dead = 0;
    public float hp;
    public float hpMax = 1;
    public float sauvDegatAuto = 0;
    public float chanceCritique = 0;
    public bool Auto;
    public float degatinfigerclic = 0;

    // Start is called before the first frame update
    void Start()
    {
        Auto = true;
        hp = hpMax;
        monTextUI.color = Color.white;
        imageWin.enabled = false;
        texteWin.enabled = false;
        coroutine = WaitAndPrint();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        monImage.color = Color.Lerp(Color.red,Color.blue,hp/hpMax);
        Score();
        if(hp <= 0)
        {
            imageWin.enabled = true;
            texteWin.enabled = true;
        }

    }

    public void Score()
    {
        ScoreTotal++;
        textScore.text = "Score : " + ScoreTotal.ToString("00");
    }
    public void degat()
    {
   
        hp -= degatinfiger;
        monTextUI.text = "HP : " + hp.ToString("00");
        monImage.fillAmount = hp / hpMax;
    }

    public void degatclic()
    {
        chanceCritique = Random.Range(0, 100);

        if (chanceCritique <= 25)
        {
            hp -= degatinfigerclic * 2;
            Debug.Log("critique");
        }
        else
        {
            hp -= degatinfigerclic;
        }

        monTextUI.text = "HP : " + hp.ToString("00");
        monImage.fillAmount = hp / hpMax;
    }

    public void Albedo()
    {
        degatclic();
        monTextUI.text = "HP : " + hp.ToString("00");
        monImage.fillAmount = hp / hpMax;

        //Debug.Log("cc");
    }

    public void clicPlusUn()
    {
        degatinfigerclic++;
    }

    private IEnumerator WaitAndPrint()
    {
        while (hp > 0)
        {
            
            degat();
            yield return new WaitForSeconds(1);
            
        }
    }

    public void AutoDegat()
    {
        //Debug.Log("plus de dégat");
        degatinfiger++;
    }

    public void Automatique()
    {
        if (Auto == true)
        {
            Auto = false;
            //Debug.Log("Fin Auto");
            sauvDegatAuto = degatinfiger;
            //Debug.Log(sauvDegatAuto);
            degatinfiger = 0;
        }
        else if (Auto == false)
        {
            Auto = true;
            //Debug.Log("Retour Auto");
            degatinfiger = sauvDegatAuto;
            //Debug.Log(degatinfiger);
        }  
    }
}
