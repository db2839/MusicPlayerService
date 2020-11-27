using System;
using System.Collections.Generic;

namespace LazyLofi.Backend.Manager.Constants
{
    public static class VideoSearchConstants
    {
        private const string AcceptFi = "Calm Lofi|Centered Lofi|Content Lofi|Fulfilled Lofi|Patient Lofi";
        private const string Angrfi = "Angry Lofi|Annoyed Lofi|Agitated Lofi|Aggravated Lofi|Bitter Lofi|Contempt Lofi|Cynical Lofi|Disdain Lofi|Disgruntled Lofi|Disturbed Lofi";
        private const string EdgyFi = "Edgy Lofi|Exasperated Lofi|Frustrated Lofi|Furious Lofi|Grouchy Lofi|Hostile Lofi|Impatient Lofi|Irritated Lofi|Irate Lofi|Moody Lofi|On edge Lofi|Outraged Lofi|Pissed Lofi|Resentful Lofi|Upset Lofi|Vindictive Lofi";

        private const string FreeFi = "Free Lofi|Happy Lofi|Inspired Lofi|Invigorated Lofi|Lively Lofi|Passionate Lofi|Playful " +
            "Lofi|Radiant Lofi|Refreshed Lofi|Rejuvenated Lofi|Renewed Lofi|Satisfied Lofi|Thrilled Lofi|Vibrant Lofi";

        private const string JoyFi = "Joy Lofi|Amazed Lofi|Awe Lofi|Bliss Lofi|Delighted Lofi|Eager Lofi|Ecstatic Lofi|Enchanted Lofi|Energized Lofi|Engaged Lofi|Enthusiastic Lofi|Excited Lofi";
        private const string PeaceFi = "Peaceful Lofi|Present Lofi|Relaxed Lofi|Serene Lofi|Trusting Lofi";
        private static int CurrentListItem = 0;

        private static List<string> SearchQueryList = new List<string>
        {
            ChristianLofi,
            Vibez,
            Chillhop,
            AcceptFi
        };

        private static void setCurrentListItem(int index)
        {
            CurrentListItem = index;
        }

        public const string Chillhop = "Chillhop";
        public const string ChillWave = "ChillWave|Lofi beats to study to|Chill Vibez";
        public const string ChristianLofi = "Christian Lofi|Lofi Bible Study";
        public const string Lofi = "Lofi|Lo-fi|lo-fi|College Music";
        public const string LofiSummer = "Lofi Summer";
        public const string LofiTacos = "Lofi tacos|Hip hop beats to study to";
        public const string Vibez = "Lofi R&B|Chill pop|Chillhop";
        public const string VideoGames = "Lofi VideoGames|Gaming Lofi";

        public static string GetRandomQuery()
        {
            Random r = new Random();

            var index = r.Next(SearchQueryList.Count);

            while (index == CurrentListItem)
            {
                index = r.Next(SearchQueryList.Count);
            }

            setCurrentListItem(index);

            return SearchQueryList[index];
        }
    }
}