using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Audio
{
    class AudioSource: Core.Component
    {
        private SoundEffectInstance soundEffect;
        private AudioEmitter emitter = new AudioEmitter();
        private float angle = 0f;
        private Vector3 offset = Vector3.Zero;
		private float pitch = 0f;

		private float distance = 0;

        public bool IsLooped
        {
            get => soundEffect.IsLooped;
            set => soundEffect.IsLooped = value;
        }

        public float Pitch
        {
            get => pitch;
            set => pitch = value;
        }

        public float Volume
        {
            get => soundEffect.Volume;
            set => soundEffect.Volume = value;
        }

		public SoundEffectInstance SoundEffect
		{
			get => soundEffect;
			set => soundEffect = value;
		}

        public AudioSource(Core.GameObject parent, SoundEffect sfx): base(parent)
        {
            if(sfx != null)
                soundEffect = sfx.CreateInstance();

		}

        public void Play()
        {
            if(soundEffect == null)
                return;
			RandPitch();

			if(AudioManager.Instance.PlayerTransform != null)
			{
				distance = Vector2.Distance(parent.transform.position, AudioManager.Instance.PlayerTransform.position);

				if(distance > AudioManager.Instance.maxSoundDistance) soundEffect.Volume = 0f;
				else
				{
					soundEffect.Volume = Util.Statics.soundVolume * (1f - (float)Math.Pow(distance / AudioManager.Instance.maxSoundDistance, 2));
				}
			}
			else soundEffect.Volume = Util.Statics.soundVolume;

			/*emitter.Position = new Vector3(parent.transform.position.X, 0f, parent.transform.position.Y) + offset;
			emitter.Forward = Vector3.Forward;
			emitter.Up = Vector3.Up;
			emitter.Velocity = Vector3.Zero;

			soundEffect.Volume = Util.Statics.soundVolume;
			soundEffect.Apply3D(AudioManager.Instance.playerListener, emitter);*/
			soundEffect.Play();
        }

		public void Stop()
		{
			if(soundEffect == null)
				return;
			soundEffect.Stop();
		}

        public override void Update(GameTime gameTime)
        {
            angle += 10f;
            offset.X = (float)Math.Cos(angle) * 100;
            offset.Z = -(float)Math.Sin(angle) * 100;
            emitter.Position = new Vector3(parent.transform.position, 0f) + offset;
        }

		public void RandPitch()
		{
			soundEffect.Pitch = pitch * (float)((Util.RNG.random.NextDouble() * 2.0) - 1.0);
		}
	}
}
