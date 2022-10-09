namespace CameraTrackerApp.Models
{
    public class Confirmation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CameraID { get; set; }
        public string Description { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
        public DateTime ConfirmationDateTime { get; set; }
    }
}
