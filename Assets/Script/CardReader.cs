using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using static UnityEngine.GraphicsBuffer;
//using namespace System.Random;

public class CardReader : MonoBehaviour
{

    public ScoreManager scoreManager;
    public int ennemiR;

    public int PrixUpgardeAutoAttack = 20;
    [SerializeField]
    private TextMeshProUGUI prixAutoAttack;
    public TextMeshProUGUI autoAttack;

    public int PrixUpgardAttackCritique = 20;
    private int PourcentageDeCritique = 2;
    [SerializeField]
    private TextMeshProUGUI prixAttackCritique;
    public TextMeshProUGUI attackCritique;

    public int PrixUpgardeAttack = 20;
    [SerializeField]
    private TextMeshProUGUI prixAttack;
    public TextMeshProUGUI attack;



    private float _currentHp;
    private string _nameEnnemi;
    
    [SerializeField]
    private TextMeshProUGUI _hpText, _nameText;
    [SerializeField]
    private Image _cardImage;

    private IEnumerator coroutine;

    [SerializeField]
    private CreateEnnemi _currentCard;

    [SerializeField]
    private CreateEnnemi[] _deck;

    public Image hpEnnemi;
    public float _score;
    public float score;

    private ScoreManager _scoreManager;
    public int ennemiNomber = 0;
    private float cardSpell = 0;
    private float cardScore = 0;

    public float hpMax = 1;
    public float degatinfigerclic = 1;
    public float chanceCritique = 0;
    public float degat = 0;

    public bool Auto;
    public float degatinfiger = 0;
    public float degatAuto;

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        ReadCard(_deck[ennemiNomber]);
        ennemiNomber++; 

        prixAutoAttack.text = PrixUpgardeAutoAttack + "$".ToString();
        autoAttack.text = "Amelioration Auto-Attack (" + degatAuto + ")".ToString();
        prixAttackCritique.text = PrixUpgardAttackCritique + "$".ToString();
        attackCritique.text = "Amelioration du Pourcentage Attack Critique (" + PourcentageDeCritique + "% )".ToString();
        prixAttack.text = PrixUpgardeAttack + "$".ToString(); attack.text = "Amelioration Attack (" + degatinfigerclic + ")".ToString();


        coroutine = WaitAndPrint();
        StartCoroutine(coroutine);

    }

    public void changementCard()
    {
        if (_currentHp <= 0)
        {
            cardSpell = _currentCard.spellCard;
            Debug.Log(cardSpell);
            _scoreManager.RiseSpellCard(cardSpell);
            cardScore = _currentCard.score;
            Debug.Log(cardScore);
            _scoreManager.RiseScoreCard(cardScore);


            if (_nameEnnemi == "Cirno")
            {
                _scoreManager.TrueCirno();
                //Debug.Log("sa peut marcher");
            }
            if (_nameEnnemi == "Aya")
            {
                _scoreManager.TrueAya();
                //Debug.Log("sa peut marcher");
            }
            if (_nameEnnemi == "Suika")
            {
                _scoreManager.TrueSuika();
                //Debug.Log("sa peut marcher");
            }
            if (_nameEnnemi == "Reimu")
            {
                _scoreManager.TrueReimu();
                //Debug.Log("sa peut marcher");
            }
            if (_nameEnnemi == "Kaguya")
            {
                _scoreManager.TrueKaguya();
                //Debug.Log("sa peut marcher");
            }
            if (_nameEnnemi == "Yukari")
            {
                _scoreManager.TrueYukari();
                //Debug.Log("sa peut marcher");
            }
            if (_nameEnnemi == "Remilia")
            {
                _scoreManager.TrueRemilia();
                //Debug.Log("sa peut marcher");
            }

            

            ennemiR = Random.Range(0, ennemiNomber);
            ReadCard(_deck[ennemiR]);

            
        }
    }

    public void ReduceHp()
    {
        degatclic();
        _currentHp -= degat;
        _hpText.text = "HP : " + _currentHp.ToString("00");
        hpEnnemi.fillAmount = _currentHp / hpMax;
        changementCard();
        
    }

    public void EnnemiPlus()
    {
        ennemiNomber++;
        //Debug.Log(ennemiNomber);
    }

    private void ReadCard(CreateEnnemi newCard)
    {
        _currentCard = newCard;

        _currentHp = _currentCard.hpBase;
        hpMax = _currentHp;
        hpEnnemi.fillAmount = _currentHp / hpMax;
        _nameEnnemi = _currentCard.ennemiName;

        _hpText.text = "HP : " + _currentCard.hpBase.ToString("00");
        _nameText.text = _currentCard.ennemiName.ToString();

        _cardImage.sprite = _currentCard.cardImage;

        _score = _currentCard.score;
        score = _score;

        
    }

    public void degatclic()
    {
        chanceCritique = (UnityEngine.Random.Range(PourcentageDeCritique, 100));
        

        if (chanceCritique >= 75)
        {
            degat = degatinfigerclic * 2;
            //Debug.Log("critique");
        }
        else
        {
            degat = degatinfigerclic;
        }
    }

    private IEnumerator WaitAndPrint()
    {
        while (true)
        {

            degaAutomatique();
            ennemiR = Random.Range(0, ennemiNomber);
            yield return new WaitForSeconds(1);

        }
    }

    public void PlusDegaAutomatique()
    {
        if (Manager.Instance.scoreManager.argent >= PrixUpgardeAutoAttack)
        {
            Manager.Instance.scoreManager.argent -= PrixUpgardeAutoAttack;
            Manager.Instance.scoreManager.ChangeArgentAmelioration(Manager.Instance.scoreManager.argent);
            //Manager.Instance.scoreManager.argentText.text = "Argent : " + Manager.Instance.scoreManager.argent.ToString();
            PrixUpgardeAutoAttack += (PrixUpgardeAutoAttack/2);
            prixAutoAttack.text = PrixUpgardeAutoAttack + "$".ToString();
            degatAuto++;
            autoAttack.text = "Amelioration Auto-Attack (" + degatAuto + ")".ToString();
        }
        else
        {
            Debug.Log("PK?");
        }
    }

    public void PlusDega()
    {
        if (Manager.Instance.scoreManager.argent >= PrixUpgardeAttack)
        {
            Manager.Instance.scoreManager.argent -= PrixUpgardeAttack;
            Manager.Instance.scoreManager.ChangeArgentAmelioration(Manager.Instance.scoreManager.argent);
            //Manager.Instance.scoreManager.argentText.text = "Argent : " + Manager.Instance.scoreManager.argent.ToString();
            PrixUpgardeAttack += (PrixUpgardeAttack/2);
            prixAttack.text = PrixUpgardeAttack + "$".ToString();
            degatinfigerclic++;
            attack.text = "Amelioration Attack (" + degatinfigerclic + ")".ToString();

        }
        else
        {
        
        }
    }

    public void PlusChanceDegatCritique()
    {
        if (Manager.Instance.scoreManager.argent >= PrixUpgardAttackCritique)
        {
            Manager.Instance.scoreManager.argent -= PrixUpgardAttackCritique;
            Manager.Instance.scoreManager.ChangeArgentAmelioration(Manager.Instance.scoreManager.argent);
            //Manager.Instance.scoreManager.argentText.text = "Argent : " + Manager.Instance.scoreManager.argent.ToString();
            PrixUpgardAttackCritique += (PrixUpgardAttackCritique/2);
            prixAttackCritique.text = PrixUpgardAttackCritique + "$".ToString();
            PourcentageDeCritique += 2;
            attackCritique.text = "Amelioration du Pourcentage Attack Critique (" + PourcentageDeCritique + "% )".ToString();
        }
        else
        {

        }
    }

    public void degaAutomatique()
    {
        if(Auto)
        {
            _currentHp -= degatAuto;
            Debug.Log("Boom");
            _hpText.text = "HP : " + _currentHp.ToString("00");
            hpEnnemi.fillAmount = _currentHp / hpMax;
            changementCard();
        }
    }
    public void Automatique()
    {
        Auto = ! Auto;
        
    }
}
