using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroMonkey.Core;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace AstroMonkey.Audio
{
    class AudioManager
    {
        public static AudioManager Instance = new AudioManager();
        private Transform _playerTransorm;
        public Transform PlayerTransform
        {
            get { return _playerTransorm; }

            set
            {
                _playerTransorm = value;
                if(_playerTransorm != null)
                    playerListener.Position = new Vector3(_playerTransorm.position.X, 0, _playerTransorm.position.Y);
                else
                    playerListener.Position = new Vector3();
            }
        }
        public AudioListener playerListener = new AudioListener();

		public float maxSoundDistance = 8f * 32f * SceneManager.scale;

		private AudioManager()
        {
        }
    }
}
