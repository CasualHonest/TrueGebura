namespace TrueGebura
{
    public class PassiveAbility_694029 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            owner.allyCardDetail.DrawCards(4);
        }

        public override void OnDrawCard()
        {
            CheckDeckForRMPages();
        }

        public void CheckDeckForRMPages()
        {
            foreach (BattleDiceCardModel model in owner.allyCardDetail.GetHand())
                if ((model.GetTextId() == 607003 || model.GetTextId() == 607004 || model.GetTextId() == 607005) && model.CurCost >= 2)
                    model.SetCurrentCost(model.CurCost - 1);
        }
    }
}
