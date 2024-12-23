using Speaker;

namespace Speaker.Sound 
{
    public class Music {
        private readonly WavSpeaker _wavSpeaker = new WavSpeaker("/mnt/usb/Francis-Wells-Live-a-Little.wav", true);
        public async Task PlayMusic() {
            await _wavSpeaker.PlayAsync();

        }
    }
}