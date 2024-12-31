using SoundLibrary;

namespace Speaker.Sound 
{
    public class Music : MusicLibrary {
        private WavSpeaker? Sound {get; set;}
        public async Task PlayMusic(Mentions mentionType) {
            if (soundLibrary.ContainsKey(mentionType))
            {
                Sound = new WavSpeaker(soundLibrary[mentionType], true);
                await Sound.PlayAsync();
            }
            else
            {
                throw new ArgumentException("Invalid mention type", nameof(mentionType)); // Foutmelding als mentionType niet bestaat
            }
        }
        
        public void StopMusic() {
            if(Sound != null)
            {
                Sound.Stop();
            }
            else 
            {
                throw new InvalidOperationException("No music is currently playing.");
            }
        }
    }
}