namespace CameraTrackerApp.Models
{
    public class Camera
    {
        public int CameraID { get; set; }
        public string CameraName { get; set; }
        public int CameraType { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; }
        public int HangingLocation { get; set; }
        public bool PublicAimed { get; set; }
        public bool PrivateAimed { get; set; }
        public enum Type
        {
            DomeCamera,
            BulletCamera,
            HiddenCamera,
            MotorizedCamera
        }
        public enum Location
        {
            Front,
            Door,
            Window,
            Back,
            Tree,
            Pole
        }
    }
}
