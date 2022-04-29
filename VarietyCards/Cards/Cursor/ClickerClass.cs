
using ClassesManagerReborn;
using System.Collections;
using UnboundLib.Cards;

namespace VarietyCards.Cards.Cursor
{
    class ClickerClass : ClassHandler
    {
        internal static string name = "Cursor";

        public override IEnumerator Init()
        {
            CardInfo classCard = null;
            while (!(Clicker.Card && Cursor.Card)) yield return null;
            ClassesRegistry.Register(Clicker.Card, CardType.Entry);
            ClassesRegistry.Register(Cursor.Card, CardType.Card, Clicker.Card);
        }
    }
}