using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessFaller
{
	public interface IHealth
	{
		int health { get; set; }
		int maxHealth { get; set; }
		void ReduceHealth();
		void RestoreHealth();
	}

	public class Health : IHealth
	{
		public int health { get; set; }
		public int maxHealth { get; set; }

		public Health()
		{
			health = 3;
			maxHealth = 3;
		}

		public virtual void ReduceHealth()
		{
			health = health--;
		}

		public virtual void RestoreHealth()
		{
			health = maxHealth;
		}
	}
}
