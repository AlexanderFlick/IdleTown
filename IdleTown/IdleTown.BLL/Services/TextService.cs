using IdleTown.BLL.Models.Tools;

namespace IdleTown.BLL.Services
{
    public interface ITextService
    {
        string CountOfStonesIn(Minecart minecart);
    }

    public class TextService : ITextService
    {
        public string CountOfStonesIn(Minecart minecart)
        {
            return $"{minecart.Stones.Count}/{minecart.Max}";
        }
    }
}