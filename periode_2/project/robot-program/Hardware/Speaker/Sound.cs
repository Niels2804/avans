using Speaker;
using Speaker.Library;

namespace Speaker.Sound 
{
    public class Music {
        private readonly WavSpeaker _wavSpeaker = new WavSpeaker(SoundLibrary.generalMentions[GeneralMentions.TutorialStep4], true);
        public async Task PlayMusic() {
            await _wavSpeaker.PlayAsync();
        }
    }
}