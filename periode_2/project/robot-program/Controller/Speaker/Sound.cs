using SoundLibrary;

namespace Speaker.Sound 
{
    public class Music : MusicLibrary {
        private WavSpeaker? _sound {get; set;}
        public async Task PlayMusic(Mentions mentionType) {
            if (soundLibrary.ContainsKey(mentionType))
            {
                _sound = new WavSpeaker(soundLibrary[mentionType], true);
                await _sound.PlayAsync();
            }
            else
            {
                throw new ArgumentException("Invalid mention type", nameof(mentionType)); // Foutmelding als mentionType niet bestaat
            }
        }
        
        public void StopMusic() {
            if(_sound != null)
            {
                _sound.Stop();
            }
            else 
            {
                throw new InvalidOperationException("No music is currently playing.");
            }
        }
    }
}