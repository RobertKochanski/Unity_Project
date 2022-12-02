using System;

public partial class Ammo
{
    [Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;

        public AmmoSlot(AmmoType ammoType, int ammoAmount)
        {
            this.ammoType = ammoType;
            this.ammoAmount = ammoAmount;
        }
    }
}
