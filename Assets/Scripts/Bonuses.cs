using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public sealed class Bonuses : MonoBehaviour
    {
        [SerializeField] List<BadBonus> badBonuses;
        [SerializeField] List<GoodBonus> goodBonuses;

        void Start()
        {
            //для примера возможной ошибки возьму этот кусок кода
            try
            {
                GoodBonus.onGoodBonusTook += OnGoodBonusTook;
                BadBonus.onBadBonusTook += OnBadBonusTook;

                if (GoodBonus.onGoodBonusTook == null || BadBonus.onBadBonusTook == null) throw new MyNullException("Эти ивенты не могут быть null");

                OnGoodBonusTook();
                OnBadBonusTook();
            } catch (MyNullException ex) { Debug.LogException(ex); }
        }

        void ResetBonuses(bool isBadBonus)
        {
            if (isBadBonus)
            {
                foreach (var bonus in badBonuses)
                {
                    bonus.gameObject.SetActive(false);
                }
            } else
            {
                foreach (var bonus in goodBonuses)
                {
                    bonus.gameObject.SetActive(false);
                }
            }
        }

        void OnBadBonusTook()
        {
            ResetBonuses(true);
            badBonuses[Random.Range(0, badBonuses.Count-1)].gameObject.SetActive(true);
            //возможно повторение прошлого индекса
        }
        void OnGoodBonusTook()
        {
            ResetBonuses(false);
            goodBonuses[Random.Range(0, goodBonuses.Count-1)].gameObject.SetActive(true);
            //возможно повторение прошлого индекса
        }
        void OnDestroy()
        {
            GoodBonus.onGoodBonusTook -= OnGoodBonusTook;
            BadBonus.onBadBonusTook -= OnBadBonusTook;
        }
    }
}