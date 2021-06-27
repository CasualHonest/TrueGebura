using LOR_DiceSystem;

namespace TrueGebura
{
    public class PassiveAbility_694029 : PassiveAbilityBase
    {
        bool egoAwakened;
        public override void OnWaveStart()
        {
            if (!owner.personalEgoDetail.ExistsCard(607022))
                owner.personalEgoDetail.AddCard(607022);
            owner.allyCardDetail.DrawCards(4);
        }

        public override void OnDrawCard()
        {
            foreach (BattleDiceCardModel model in owner.allyCardDetail.GetHand())
                if ((model.GetTextId() == 607003 || model.GetTextId() == 607004 || model.GetTextId() == 607005) && model.CurCost >= 2)
                    model.SetCurrentCost(model.CurCost - 1);
        }

        public override void OnRoundStart()
        {
            UpdateResist();
            if (!egoAwakened && owner.emotionDetail.EmotionLevel >= 4)
            {
                egoAwakened = true;
                owner.allyCardDetail.AddNewCard(607008, false);
            }
        }

        public void UpdateResist()
        {
            BehaviourDetail detail = RandomUtil.SelectOne(new BehaviourDetail[]
            {
                BehaviourDetail.Slash,
                BehaviourDetail.Penetrate,
                BehaviourDetail.Hit
            });
            if (owner.passiveDetail.HasPassive<PassiveAbility_250422>())
            {
                owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Endure);
                owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Endure);
                owner.Book.SetResistHP(detail, AtkResist.Normal);
                owner.Book.SetResistBP(detail, AtkResist.Normal);
                return;
            }
            owner.Book.SetResistHP(BehaviourDetail.Slash, AtkResist.Normal);
            owner.Book.SetResistHP(BehaviourDetail.Penetrate, AtkResist.Normal);
            owner.Book.SetResistHP(BehaviourDetail.Hit, AtkResist.Normal);
            owner.Book.SetResistBP(BehaviourDetail.Slash, AtkResist.Normal);
            owner.Book.SetResistBP(BehaviourDetail.Penetrate, AtkResist.Normal);
            owner.Book.SetResistBP(BehaviourDetail.Hit, AtkResist.Normal);
            owner.Book.SetResistHP(detail, AtkResist.Endure);
            owner.Book.SetResistBP(detail, AtkResist.Endure);
        }
    }
}
