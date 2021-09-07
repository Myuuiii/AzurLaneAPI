namespace AzurLaneAPI
{
    public static class StaticHelpers
    {
        public static int CheckStatfieldContent(this string value) 
        {
            if (string.IsNullOrWhiteSpace(value) || value == "TBD") return 0;
            else return int.Parse(value);
        }
    }
}