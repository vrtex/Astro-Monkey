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
        private Vector3 offset = new Vector3();

        public bool IsLooped
        {
            get => soundEffect.IsLooped;
            set => soundEffect.IsLooped = value;
        }

        public float Pitch
        {
            get => soundEffect.Pitch;
            set => soundEffect.Pitch = value;
        }

        public float Volume
        {
            get => soundEffect.Volume;
            set => soundEffect.Volume = value;
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
            emitter.Position = new Vector3(parent.transform.position, 0f) + offset;
            soundEffect.Apply3D(AudioManager.Instance.playerListener, emitter);
            soundEffect.Play();
        }

        public override void Update(GameTime gameTime)
        {
            angle += 10f;
            offset.X = (float)Math.Cos(angle) * 100;
            offset.Z = -(float)Math.Sin(angle) * 100;
            emitter.Position = new Vector3(parent.transform.position, 0f) + offset;
        }
    }
}
