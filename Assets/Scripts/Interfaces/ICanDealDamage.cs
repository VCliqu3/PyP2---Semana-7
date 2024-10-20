using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanDealDamage
{
    public int GetDamage();
    public void DoDamage(IHasHealth iHasHealth);
}
