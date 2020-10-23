using IdleTown.BLL.Models.Resources;
using IdleTown.BLL.Models.Tools;
using System.Collections.Generic;

namespace IdleTown.BLL.Services
{
    public interface ITextService
    {
        string CountOfStonesIn(Minecart minecart);

        List<string> ContentsOf(Chest chest);
    }

    public class TextService : ITextService
    {
        public string CountOfStonesIn(Minecart minecart)
        {
            return $"{minecart.Stones.Count}/{minecart.Max}";
        }

        public List<string> ContentsOf(Chest chest)
        {
            var contents = new List<string>();
            contents.Add(StoneWithGoodQualityIn(chest));
            contents.Add(StoneWithGreatQualityIn(chest));
            return contents;
        }

        private string StoneWithGoodQualityIn(Chest chest)
        {
            var count = 0;
            foreach (Stone stone in chest.Contents)
            {
                if (stone.Quality == Qualities.Good)
                {
                    count++;
                }
            }
            return $"Good Stone: {count}";
        }

        private string StoneWithGreatQualityIn(Chest chest)
        {
            var count = 0;
            foreach (Stone stone in chest.Contents)
            {
                if (stone.Quality == Qualities.Great)
                {
                    count++;
                }
            }
            return $"Good Stone: {count}";
        }
    }
}