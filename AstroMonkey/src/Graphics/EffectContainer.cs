using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroMonkey.Graphics
{
	class EffectContainer
	{
		public Dictionary<string, Effect>       effects = new Dictionary<string, Effect>();

		public static EffectContainer Instance { get; private set; } = new EffectContainer();

		static EffectContainer()
		{
		}

		public Effect GetEffect(String id)
		{
			Effect toReturn;
			effects.TryGetValue(id, out toReturn);
			if(toReturn == null)
			{
				Console.WriteLine("Unexisting effect: " + id);
				Console.WriteLine(new System.Diagnostics.StackTrace());
			}
			return toReturn;
		}

		public void LoadEffects(Game game)
		{
			effects.Add("LightOff", game.Content.Load<Effect>("effects/LightOff"));
            effects.Add("BloodScreen", game.Content.Load<Effect>("effects/BloodScreen"));
            effects.Add("HealthFX", game.Content.Load<Effect>("effects/HealthFx"));
        }
	}
}
