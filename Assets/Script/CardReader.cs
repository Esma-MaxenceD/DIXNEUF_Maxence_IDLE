using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class CardReader : MonoBehaviour
{

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

    private ScoreManager _scoreManager;
    public int ennemiNomber = 0;
    private float card = 0;

    public float hpMax = 1;
    public float degatinfigerclic = 1;
    public float chanceCritique = 0;
    public float degat = 0;

    public bool Auto;
    public float sauvDegatAuto;
    public float degatinfiger = 0;
    public float degatAuto;

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        ReadCard(_deck[ennemiNomber]);

        coroutine = WaitAndPrint();
        StartCoroutine(coroutine);

    }

    public void ReduceHp()
    {
        degatclic();
        _currentHp -= degat;
        _hpText.text = _currentHp.ToString("00");
        hpEnnemi.fillAmount = _currentHp / hpMax;
        if (_currentHp <= 0)
        {
            card = _currentCard.spellCard;
            _scoreManager.RiseSpellCard(card);
            if(_nameEnnemi == "Cirno")
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

            ennemiNomber++;
            ReadCard(_deck[ennemiNomber]);
        }
    }

    private void ReadCard(CreateEnnemi newCard)
    {
        _currentCard = newCard;

        _currentHp = _currentCard.hpBase;
        hpMax = _currentHp;
        hpEnnemi.fillAmount = _currentHp / hpMax;
        _nameEnnemi = _currentCard.ennemiName;

        _hpText.text = _currentCard.hpBase.ToString("00");
        _nameText.text = _currentCard.ennemiName.ToString();

        _cardImage.sprite = _currentCard.cardImage;

        
    }




    public void degatclic()
    {
        chanceCritique = Random.Range(0, 100);

        if (chanceCritique <= 25)
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
            yield return new WaitForSeconds(1);

        }
    }

    public void plusDegaAutomatique()
    {
        degatAuto++;
    }

    public void degaAutomatique()
    {
        if(Auto)
        {
            _currentHp -= degatAuto;
            _hpText.text = _currentHp.ToString("00");
            hpEnnemi.fillAmount = _currentHp / hpMax;
        }
    }
    public void Automatique()
    {
        Auto = ! Auto;
        
    }
}
