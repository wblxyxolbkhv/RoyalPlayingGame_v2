using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyalPlayingGame;
using RoyalPlayingGame.Units;
using RoyalPlayingGamev2.Globals;
using RoyalPlayingGamev2.Spells;

namespace RoyalPlayingGamev2.Units
{

    public class RPGUnit : RPGMovingObject
    {

        public GameObject defaultSpell;

        public string Name = "";

        protected virtual Unit unit
        {
            get;
            set;
        }

        // Use this for initialization
        protected override void Start()
        {
            base.Start();


            // TODO: отладное дерьмо - квест цепляется при создании любого юнита
            var quest = new DebugQuest();
            quest.LoadQuest(null);
            QuestManager.QuestRepository.Add(quest);
        }
        

        protected virtual void Cast()
        {
            if (defaultSpell != null)
            {
                GameObject spell = Instantiate(defaultSpell);

                switch (WalkDirection)
                {
                    case Directions.Left:
                    case Directions.NoneLeft:
                        spell.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
                        spell.transform.localScale = new Vector3(-1, 1, 1);
                        spell.GetComponent<RPGMovingSpell>().Launch(Directions.Left, gameObject);
                        break;
                    case Directions.Right:
                    case Directions.NoneRight:
                        spell.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
                        spell.GetComponent<RPGMovingSpell>().Launch(Directions.Right, gameObject);
                        break;
                }
            }
            else
            {

            }
        }

        public int GetHealth()
        {
            return unit.Health;
        }
        public int GetMaxHealth()
        {
            return unit.MaxHealth;
        }
        public virtual void GetDamage(int damage, DamageType damageType = DamageType.Physical)
        {
            unit.GotDamaged(damage, damageType);
        }
        
    }
}
