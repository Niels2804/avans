using SoundLibrary;
using Speaker;
using SoundLibrary;

namespace Speaker.Sound 
{
    public class Music : MusicLibrary {
        private WavSpeaker _sound {get; set;}
        public async Task PlayMusic(Mentions mentionType) {
            _sound = new WavSpeaker(soundLibrary[mentionType], true);
            await _sound.PlayAsync();
        }
        
        public void StopMusic() {
            _sound.Stop();
        }
    }
}