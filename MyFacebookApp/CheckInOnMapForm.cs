using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;
using FacebookWrapper.ObjectModel;

namespace MyFacebookApp
{
    public partial class CheckInOnMapForm : Form
    {
        private readonly List<CheckInWrapper> r_CheckInsOnForm = new List<CheckInWrapper>();
        private FacebookObjectCollection<Checkin> m_UserCheckIns;

        public FacebookObjectCollection<Checkin> UserCheckIns
        {
            get { return m_UserCheckIns; }
            set { m_UserCheckIns = value; }
        }

        public CheckInOnMapForm()
        {
            InitializeComponent();
        }

        private void checkInOnMapForm_Load(object i_Sender, EventArgs i_EventArgs)
        {
            this.CenterToScreen();
            CheckInGMapControl.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            CheckInGMapControl.SetPositionByKeywords("Israel, Holon");
            CheckInGMapControl.RoutesEnabled = true;
            CheckInGMapControl.ShowCenter = false;
            CheckInGMapControl.DragButton = MouseButtons.Left;

            updateInfo();
        }

        private void updateInfo()
        {
            string eventName = string.Empty;

            CheckInsListBox.DisplayMember = "Name";
            foreach (Checkin curCheckIn in m_UserCheckIns)
            {
                try
                {
                    eventName = (curCheckIn.Place.Name == null) ? "[No Name]" : curCheckIn.Place.Name;
                    PointLatLng location = new PointLatLng((double)curCheckIn.Place.Location.Latitude, (double)curCheckIn.Place.Location.Longitude);
                    CheckInWrapper checkInWrapper = new CheckInWrapper(eventName, location, curCheckIn.PictureURL, curCheckIn.Link, (DateTime)curCheckIn.CreatedTime);

                    r_CheckInsOnForm.Add(checkInWrapper);
                    CheckInsListBox.Items.Add(checkInWrapper);
                }
                catch (Exception ex)
                {
                }
            }
            
            showAllCheckInsOnMap();
            CheckInGMapControl.Zoom = 11.5;
        }

        private void showAllCheckInsOnMap()
        {
            GMapOverlay mapMarkers = new GMapOverlay("markers");

            CurrentCheckInPictureBox.Image = null;
            foreach (CheckInWrapper curCheckIn in r_CheckInsOnForm)
            {
                mapMarkers.Markers.Add(curCheckIn.CheckInMarkerOnMap);
            }

            CheckInGMapControl.Overlays.Add(mapMarkers);
        }

        private void showLocationButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            CheckInLinkLabel.Text = string.Empty;
            CurrentCheckInPictureBox.InitialImage = null;
            CheckInGMapControl.Overlays.Clear();
            if (SingleCheckInRadioButton.Checked)
            {
                showSingleCheckInOnMap();
            }
            else
            {
                showAllCheckInsOnMap();
            }
        }

        private void showSingleCheckInOnMap()
        {
            GMapOverlay mapMarkers = new GMapOverlay("markers");

            CheckInLinkLabel.Text = string.Empty;
            CurrentCheckInPictureBox.InitialImage = null;

            if (CheckInsListBox.SelectedItems.Count == 1)
            {
                try
                {
                    CheckInWrapper curCheckIn = CheckInsListBox.SelectedItem as CheckInWrapper;

                    mapMarkers.Markers.Add(curCheckIn.CheckInMarkerOnMap);
                    CheckInLinkLabel.Text = (curCheckIn.Link != null) ? curCheckIn.Link : string.Empty;
                    if (curCheckIn.PhotoUrl != null)
                    {
                        CurrentCheckInPictureBox.LoadAsync(curCheckIn.PhotoUrl);
                    }
                    else
                    {
                        CurrentCheckInPictureBox.Image = null; // delete the last picture
                    }
                }
                catch(Exception ex)
                {
                }
            }

            CheckInGMapControl.Overlays.Add(mapMarkers);
        }

        private void checkInLinkLabel_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (CheckInLinkLabel.Text != string.Empty)
            {
                Process linkedUrl = Process.Start(CheckInLinkLabel.Text);

                linkedUrl.WaitForExit();
            }
        }

        private void checkInOnMapForm_FormClosing(object i_Sender, FormClosingEventArgs i_EventArgs)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}