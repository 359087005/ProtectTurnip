using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UICard : MonoBehaviour,IPointerDownHandler
{
    public event Action<Card> OnClick;

    public Image ImgCard;
    public Image ImgLock;

    //卡牌属性
    Card m_Card = null;

    //是否半透
    private bool isTransparent = false;
    public bool IsTrannsparent
    {
        get { return isTransparent; }
        set
        {
            isTransparent = value;
            Image[] images = new Image[] { ImgCard , ImgLock };
            foreach (Image img in images)
            {
                Color c = img.color;
                c.a = value ? 0.5f : 1f;
                img.color = c;
            }
        }
    }

    public void DataBind(Card card)
    {
        m_Card = card;

        string cardFile = "file://" + Constant.CardsDir + card.CardName;
        StartCoroutine(Tools.LoadImage(cardFile,ImgCard));

        isTransparent = card.isLocked;

        ImgLock.gameObject.SetActive(card.isLocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnClick != null)
        {
            OnClick(m_Card);
        }
    }

     void OnDestroy()
    {
        while (OnClick != null)
            OnClick -= OnClick;
    }

}
