namespace GeometriskaFigurer
{
    public static class NextFloatHelpers
    {
        public static float NextFloat(float min = 0.0f, float max = 10.0f)
        {
            Random random = new Random();
            float val = random.NextSingle() * (max - min) + min;
            return MathF.Round(val, 2);
        }
    }
}