using System;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MyFacebookApp
{
    internal class CheckInWrapper
    {
        private readonly string r_CheckInName = null;
        private readonly string r_CheckInPhotoUrl = null;
        private readonly string r_CheckInLink = null;
        private readonly PointLatLng r_CheckInLocation;
        private readonly DateTime r_CreatedTime;
        private GMapMarker m_CheckInMarkerOnMap;

        public string Name
        {
            get { return r_CheckInName; }
        }

        public string PhotoUrl
        {
            get { return r_CheckInPhotoUrl; }
        }

        public string Link
        {
            get { return r_CheckInLink; }
        }

        public GMapMarker CheckInMarkerOnMap
        {
            get { return m_CheckInMarkerOnMap; }
        }

        public CheckInWrapper(string i_Name, PointLatLng i_Location, string i_PhotoUrl, string i_CheckInLike, DateTime i_CreatedTime)
        {
            r_CheckInName = i_Name;
            r_CheckInLocation = i_Location;
            r_CheckInPhotoUrl = i_PhotoUrl;
            r_CheckInLink = i_CheckInLike;
            r_CreatedTime = i_CreatedTime;
            
            StringBuilder descriptionToToolTip = new StringBuilder();
            descriptionToToolTip.AppendLine("Name: " + i_Name);
            descriptionToToolTip.AppendLine("You Been there on: " + i_CreatedTime.ToString());

            m_CheckInMarkerOnMap = new GMarkerGoogle(i_Location, GMarkerGoogleType.pink);
            m_CheckInMarkerOnMap.ToolTipText = descriptionToToolTip.ToString();
        }
    }
}