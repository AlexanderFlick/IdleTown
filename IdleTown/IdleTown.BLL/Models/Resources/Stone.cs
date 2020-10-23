namespace IdleTown.BLL.Models.Resources
{
    public enum Qualities
    {
        Good, Great
    }

    public class Stone : Resource
    {
        public Stone()
        {
            Quality = Qualities.Good;
        }

        public Qualities Quality { get; set; }
    }

    public static class StoneExtensionMethods
    {
        public static Qualities ImproveQualityOf(this Stone stone)
        {
            return stone.Quality == Qualities.Good ? Qualities.Great : Qualities.Great;
        }
    }
}