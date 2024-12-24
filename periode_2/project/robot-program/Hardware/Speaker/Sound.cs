using Speaker;

namespace Speaker.Sound 
{
    public class Music {
        // private readonly WavSpeaker _wavSpeaker = new WavSpeaker("/mnt/usb/SoundLibrary/Music/Francis-Wells-Live-a-Little.wav", true);
        private readonly WavSpeaker _wavSpeaker = new WavSpeaker("/mnt/usb/SoundLibrary/Music/Portal-4000-Degrees-Kelvin.wav", true);
        public async Task PlayMusic() {
            await _wavSpeaker.PlayAsync();
        }
    }
}