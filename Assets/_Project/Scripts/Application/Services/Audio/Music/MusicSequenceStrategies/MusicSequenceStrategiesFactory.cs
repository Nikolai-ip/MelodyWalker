using _Game.Scripts.Services.Audio.Music.Abstract;

namespace _Game.Scripts.Services.Audio.Music.MusicSequenceStrategies
{
    public class MusicSequenceStrategiesFactory
    {
        public IMusicSequenceStrategy GetMusicSequenceStrategy(MusicPackSequenceType type)
        {
            switch (type)
            {
                case MusicPackSequenceType.Forward: return new ForwardOrder();
                case MusicPackSequenceType.Inverse: return new InverseOrder();
                default: return new ForwardOrder();
            }
        }
    }
}