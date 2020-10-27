namespace LazyLofi.Controllers
{
    public static class Counter
    {
        private static int hit;

        private static int size;

        public static int GetCounter()
        {
            return hit;
        }

        public static void HitCounter()
        {
            if (hit == size)
            {
                hit = 0;
            }
            else
            {
                hit++;
            }
        }

        public static void setSize(int incomingSize)
        {
            size = incomingSize;
        }
    }
}