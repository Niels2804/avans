using Speaker;

internal class Program {
    static readonly WavSpeaker _wavSpeaker = new WavSpeaker("/mnt/usb/Francis-Wells-Live-a-Little.wav", true);
    static async Task Main() {
        await _wavSpeaker.PlayAsync();
    }
}
 