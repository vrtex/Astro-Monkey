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
                playerListener.Position = new Vector3(_playerTransorm.position, 0);
            }
        }
        public AudioListener playerListener = new AudioListener();

        private AudioManager()
        {
        }
    }
}
