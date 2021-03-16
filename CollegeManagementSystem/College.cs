namespace Entities
{
    public class College
    {
        public string collegeId { get; set; }
        public string collegeName { get; set; }
        public string collegeLocation { get; set; }

        public int cutOffPercentage { get; set; }

        public int numberOfSeatsAvailable { get; set; }

        public College()
        {
        }
    }
}