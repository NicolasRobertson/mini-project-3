using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessFaller
{
	public class Player : IHealth
	{
		Health healthManager = new Health();

		public int health
		{
			get
			{
				return healthManager.health;
			}
			set
			{
				healthManager.health = value;
			}
		}

		public int maxHealth
		{
			get
			{
				return healthManager.maxHealth;
			}
			set
			{
				healthManager.maxHealth = value;
			}
		}

		public Player()
		{
			RestoreHealth();
		}

		public void ReduceHealth()
		{
			health--;
		}

		public void RestoreHealth()
		{

			for (int i = health; i <= maxHealth; i++)
			{
				health = i;
			}

		}

	}
}

