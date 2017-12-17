using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using HoroscopeController;

namespace MyFacebookApp
{
    public partial class MainForm : Form
    {
        private readonly LoginForm r_LoginForm = new LoginForm();
        private readonly CheckInOnMapForm r_CheckInsOnMapForm = new CheckInOnMapForm();
        private readonly CreateNewAlbumForm r_CreateNewAlbumForm = new CreateNewAlbumForm();
        private readonly PlaylistForm r_PlaylistForm = new PlaylistForm();
        private readonly PartnerZodiacSignForm r_PartnerSignForm = new PartnerZodiacSignForm();
        private readonly SetBirthdayForm r_SetBirthdayForm = new SetBirthdayForm();
        private ZodiacSign m_UserZodiacSign = null;
        private User m_LoggedInUser;
        private string m_UserPartnerSign = null;

        public MainForm()
        {
            InitializeComponent();

            if (r_LoginForm.ShowDialog() == DialogResult.OK)
            {
                if (r_LoginForm.LoginResult.LoggedInUser != null)
                {
                    m_LoggedInUser = r_LoginForm.LoginResult.LoggedInUser;

                    updateInfo();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void mainForm_Load(object i_Sender, EventArgs i_EventArgs)
        {
            this.CenterToScreen();
            this.Location = new Point(this.Location.X, 0);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override void OnShown(EventArgs i_EventArgs)
        {
            fetchEvents(m_LoggedInUser.EventsCreated);
        }

        private void updateInfo()
        {
            setTimeAndDate();
            setCoverPicture();
            UserNameLabel.Text = m_LoggedInUser.Name;
            UserProfilePictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            UserBirthdayLabel.Text = getBirthdayDate();
            UserEmailLabel.Text = getEmail();
            UserLivesInLabel.Text = getLocationName();
            UserGenderLabel.Text = getUserGender();
            UserInterestedInLabel.Text = getUserInterstedIn();
            HoroscopeBirthdayLabel.Text = "Birthday: " + getBirthdayDate();
            if (m_LoggedInUser.Birthday != null)
            {
                updateHoroscopeTabInfo(m_LoggedInUser.Birthday);
            }
            else
            {
                fetchUserBirthday();
            }
        }

        private void setCoverPicture()
        {
            if(m_LoggedInUser.Cover.SourceURL != null)
            {
                CoverPictureBox.LoadAsync(m_LoggedInUser.Cover.SourceURL);
            }
            else
            {
                CoverPictureBox.BackColor = Color.Turquoise;
            }
        }

        private string getUserInterstedIn()
        {
            string interstedIn = null;

            try
            {
                interstedIn = m_LoggedInUser.InterestedIn[0].ToString();
            }
            catch(Exception ex)
            {
            }

            return interstedIn;
        }

        private string getUserGender()
        {
            string gender = null;

            try
            {
                gender = m_LoggedInUser.Gender.ToString();
            }
            catch (Exception ex)
            {
            }

            return gender;
        }

        private void setTimeAndDate()
        {
            DateUiLabel.Text = DateTime.Now.ToShortDateString(); 
        }

        private void updateHoroscopeTabInfo(string i_Birthday)
        {
            m_UserZodiacSign = ZodiacSignFactory.GetZodiacSignByDate(i_Birthday);
            ZodiacSignLabel.Text = "Zodiac Sign: " + m_UserZodiacSign.SignName;
            SignPictureBox.Image = Image.FromFile(m_UserZodiacSign.SignPhotoUrl);
        }

        private void fetchUserBirthday()
        {
            this.Hide();
            
            if (r_SetBirthdayForm.ShowDialog() == DialogResult.OK)
            {
                updateHoroscopeTabInfo(r_SetBirthdayForm.UserBirthday);
                this.Show();
            }
        }

        private string getLocationName()
        {
            string location = null;

            try
            {
                location = m_LoggedInUser.Location.Name;
            }
            catch (NullReferenceException ex)
            {
            }

            return location;
        }

        private string getEmail()
        {
            string email = null;

            try
            {
                email = m_LoggedInUser.Email;
            }
            catch(NullReferenceException ex)
            {
            }

            return email;
        }

        private string getBirthdayDate()
        {
            string userBirthdayStr = null;

            try
            {
                string[] splitBirthday = m_LoggedInUser.Birthday.Split(new char[] { '/' });

                StringBuilder userBirthday = new StringBuilder();
                userBirthday.Append(splitBirthday[1] + "/"); /// day
                userBirthday.Append(splitBirthday[0] + "/"); /// month
                userBirthday.Append(splitBirthday[2]); /// year
                userBirthdayStr = userBirthday.ToString();
            }
            catch(NullReferenceException ex)
            {
            }
            
            return userBirthdayStr;
        }

        private void friendsFirstNameOrderCheckBox_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (FriendsFirstNameOrderCheckBox.Checked)
            {
                FriendsLastNameOrderCheckBox.Checked = false;
            }
        }

        private void friendsLastNameOrderCheckBox_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
        {
            if (FriendsLastNameOrderCheckBox.Checked)
            {
                FriendsFirstNameOrderCheckBox.Checked = false;
            }
        }
        
        private void attendingRadioButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchEvents(m_LoggedInUser.EventsCreated);
        }

        private void notAttendingRadioButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchEvents(m_LoggedInUser.EventsDeclined);
        }

        private void maybeRadioButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchEvents(m_LoggedInUser.EventsMaybe);
        }

        private void notRepliedRadioButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchEvents(m_LoggedInUser.EventsNotYetReplied);
        }

        private void fetchEvents(FacebookObjectCollection<Event> i_Events)
        {
            if (m_LoggedInUser != null)
            {
                EventsListBox.Items.Clear();
                EventsListBox.DisplayMember = "Name";
                foreach (Event fbEvent in i_Events)
                {
                    EventsListBox.Items.Add(fbEvent);
                }

                if (i_Events.Count == 0)
                {
                    MessageBox.Show("There isn't events to show.", "Not registered to events");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private void fetchFriendButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchFriendList();
        }

        private void fetchFriendList()
        {
            List<User> friends = null;

            if (m_LoggedInUser != null)
            {
                if (!FriendsFirstNameOrderCheckBox.Checked && !FriendsLastNameOrderCheckBox.Checked)
                {
                    friends = SortingAndCopyService.CopyFriendsToList(m_LoggedInUser.Friends);
                }
                else
                {
                    if (FriendsFirstNameOrderCheckBox.Checked)
                    {
                        friends = fetchFriendsByFirstNameOrder();
                    }

                    if (FriendsLastNameOrderCheckBox.Checked)
                    {
                        friends = fetchFriendsByLastNameOrder();
                    }
                }

                if (friends != null)
                {
                    showFrinedsOnListBox(friends);
                }

                if (m_LoggedInUser.Friends.Count == 0)
                {
                    MessageBox.Show("There isn't friends to show.");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }
        
        private List<User> fetchFriendsByFirstNameOrder()
        {
            return SortingAndCopyService.SortFriendsByFirstName(m_LoggedInUser.Friends);
        }

        private List<User> fetchFriendsByLastNameOrder()
        {
            return SortingAndCopyService.SortFriendsByLastName(m_LoggedInUser.Friends);
        }

        private void showFrinedsOnListBox(List<User> i_UserFriends)
        {
            FriendsListBox.Items.Clear();
            FriendsListBox.DisplayMember = "Name";
            foreach (User friend in i_UserFriends)
            {
                FriendsListBox.Items.Add(friend);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }
        }

        private void fetchPostsButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchPosts();
        }

        private void fetchPosts()
        {
            if (m_LoggedInUser != null)
            {
                foreach (Post post in m_LoggedInUser.Posts)
                {
                    if (post.Message != null)
                    {
                        PostsListBox.Items.Add(post.Message);
                    }
                    else if (post.Caption != null)
                    {
                        PostsListBox.Items.Add(post.Caption);
                    }
                    else
                    {
                        PostsListBox.Items.Add(string.Format("[{0}]", post.Type));
                    }
                }

                if (m_LoggedInUser.Posts.Count == 0)
                {
                    MessageBox.Show("No Posts to show");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private void fetchCheckInsButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchCheckIns();
        }

        private void fetchCheckIns()
        {
            if (m_LoggedInUser != null)
            {
                foreach (Checkin checkin in m_LoggedInUser.Checkins)
                {
                    CheckInsListBox.Items.Add(checkin.Place.Name);
                }

                if (m_LoggedInUser.Checkins.Count == 0)
                {
                    MessageBox.Show("No Checkins to show");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private void postStatusButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (m_LoggedInUser != null)
            {
                Status postedStatus = m_LoggedInUser.PostStatus(StatusTextBox.Text);

                StatusTextBox.Clear();
                MessageBox.Show("Status Posted! " + postedStatus.Id);
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private void fetchLikedPagesButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchLikedPages();
        }

        private void fetchLikedPages()
        {
            List<Page> pages = null;

            if (m_LoggedInUser != null)
            {
                if (!LikedPagesInOrderCheckBox.Checked)
                {
                    pages = SortingAndCopyService.CopyPagesToList(m_LoggedInUser.LikedPages);
                }
                else
                {
                    pages = fetchLikedPagesInOrder();
                }

                if(pages != null)
                {
                    showLikedPagesListOnListBox(pages);
                }

                if (m_LoggedInUser.LikedPages.Count == 0)
                {
                    MessageBox.Show("No liked pages to show");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private List<Page> fetchLikedPagesInOrder()
        {
            return SortingAndCopyService.SortPages(m_LoggedInUser.LikedPages);
        }

        private void showLikedPagesListOnListBox(List<Page> i_UserLikedPages)
        {
            LikedPagesListBox.Items.Clear();
            LikedPagesListBox.DisplayMember = "Name";
            foreach (Page page in i_UserLikedPages)
            {
                LikedPagesListBox.Items.Add(page);
            }
        }
        
        private void likedPagesListBox_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            displaySelectedPagePicture();
        }
        
        private void displaySelectedPagePicture()
        {
            if (LikedPagesListBox.SelectedItems.Count == 1)
            {
                Page selectedPage = LikedPagesListBox.SelectedItem as Page;

                if (selectedPage.PictureNormalURL != null)
                {
                    LikedPagePictureBox.LoadAsync(selectedPage.PictureNormalURL);
                }
            }
        }
        
        private void friendsListBox_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            displaySelectedFriendPicture(FriendsListBox, FriendCheckedPictureBox);
        }

        private void displaySelectedFriendPicture(Control i_SelectedListBox, Control i_SelectedPictureBox)
        {
            ListBox selectedListBox = i_SelectedListBox as ListBox;
            PictureBox selectedPictureBox = i_SelectedPictureBox as PictureBox;

            if (selectedListBox.SelectedItems.Count == 1)
            {
                User selectedFriend = selectedListBox.SelectedItem as User;

                if (selectedFriend.PictureNormalURL != null)
                {
                    selectedPictureBox.LoadAsync(selectedFriend.PictureNormalURL);
                }
            }
        }

        private void fetchAlbumsButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchAlbums();
        }

        private void fetchAlbums()
        {
            List<Album> albums = null;

            if (m_LoggedInUser != null)
            {
                if (!AlbumsOrderCheckBox.Checked)
                {
                    albums = SortingAndCopyService.CopyAlbumsToList(m_LoggedInUser.Albums);
                }
                else
                {
                    albums = fetchAlbumsInOrder();
                }

                if(albums != null)
                {
                    showAlbumsListOnListBox(albums);
                }

                if (m_LoggedInUser.Albums.Count == 0)
                {
                    MessageBox.Show("No albums to show");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private List<Album> fetchAlbumsInOrder()
        {
            return SortingAndCopyService.SortAlbums(m_LoggedInUser.Albums);
        }

        private void showAlbumsListOnListBox(List<Album> i_UserAlbums)
        {
            AlbumsListBox.Items.Clear();
            AlbumsListBox.DisplayMember = "Name";
            foreach (Album album in i_UserAlbums)
            {
                AlbumsListBox.Items.Add(album);
            }
        }

        private void albumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbumPicture();
            fetchAlbumInfo();
        }

        private void displaySelectedAlbumPicture()
        {
            if (AlbumsListBox.SelectedItems.Count == 1)
            {
                Album selectedAlbum = AlbumsListBox.SelectedItem as Album;

                if (selectedAlbum.PictureAlbumURL != null)
                {
                    SelectedAlbumPictureBox.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
            }
        }

        private void fetchAlbumInfo()
        {
            Album selectedAlbum = AlbumsListBox.SelectedItem as Album;

            AlbumDescriptionTextBox.Text = selectedAlbum.Description;
            AlbumCreatedDateTimePicker.Value = selectedAlbum.CreatedTime ?? new DateTime(9998, 12, 31);
        }

        private void fetchSingelsFriendsButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            fetchSingelsFriends();
        }

        private void fetchSingelsFriends()
        {
            if (m_LoggedInUser != null)
            {
                if (GenderComboBox.Text != string.Empty)
                {
                    if (!(m_LoggedInUser.Friends.Count == 0))
                    {
                        List<User> singelsFriends = getSingelsFriends(m_LoggedInUser.Friends, GenderComboBox.Text);
                        showSingelsFriendOnListBox(singelsFriends);
                    }
                    else
                    {
                        MessageBox.Show("There isn't friends in your friends list.");
                    }
                }
                else
                {
                    MessageBox.Show(
@"You didn't choose your desired gender,
Please try again.",
                  "Error");
                }
            }
            else
            {
                MessageBox.Show("Your not logged in", "Error");
            }
        }

        private List<User> getSingelsFriends(FacebookObjectCollection<User> i_UserFriends, string i_UserDesiredGender)
        {
            List<User> singelsFriends = new List<User>();

            foreach (User friend in i_UserFriends)
            {
                if (friend.Gender.ToString() == i_UserDesiredGender && friend.RelationshipStatus == User.eRelationshipStatus.Single)
                {
                    singelsFriends.Add(friend);
                }
            }

            return singelsFriends;
        }

        private void showSingelsFriendOnListBox(List<User> i_SingelsFriends)
        {
            if (i_SingelsFriends.Count != 0)
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    SingelsFriendsListBox.Items.Add(friend.Name);
                }
            }
            else
            {
                MessageBox.Show("There isn't singels friends in that gender.");
            }
        }

        private void logoutButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            FacebookService.Logout(onLogOut);
        }

        private void onLogOut()
        {
            this.Hide();

            if(r_LoginForm.ShowDialog() == DialogResult.OK)
            {
                m_LoggedInUser = r_LoginForm.LoginResult.LoggedInUser;
                updateInfo();
                this.Show();
            }
        }

        private void fetchHoroscopeButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (m_UserZodiacSign != null)
            {
                HoroscopeTextBox.Text = m_UserZodiacSign.SetWebUrlBySignAndGetDailyHoroscope();
            }
        }

        private void createAlbumButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            r_CreateNewAlbumForm.CurrentUser = m_LoggedInUser;
            this.Hide();

            if (r_CreateNewAlbumForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void showCheckInsButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            this.Hide();
            r_CheckInsOnMapForm.UserCheckIns = m_LoggedInUser.Checkins;

            if (r_CheckInsOnMapForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void getPlaylistButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            this.Hide();
            r_PlaylistForm.UserLinks = m_LoggedInUser.PostedLinks;
            r_PlaylistForm.m_LoggedInUser = m_LoggedInUser;

            if (r_PlaylistForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void mainForm_FormClosed(object i_Sender, FormClosedEventArgs i_EventArgs)
        {
            Application.Exit();
        }

        private void singelsFriendsListBox_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            displaySelectedFriendPicture(SingelsFriendsListBox, GetInThouchPictureBox);
        }

        private void eventsListBox_SelectedIndexChanged(object i_Sender, EventArgs i_EventArgs)
        {
            displaySelectedEventPicture();
            fetchEventInfo();
        }

        private void fetchEventInfo()
        {
            Event selectedEvent = EventsListBox.SelectedItem as Event;

            EventDescriptionTextBox.Text = selectedEvent.Description;
            StartDateTimePicker.Value = selectedEvent.StartTime ?? new DateTime(9998, 12, 31);
            EndDateTimePicker.Value = selectedEvent.EndTime ?? new DateTime(9998, 12, 31);
            OwnerNameLabel.Text = selectedEvent.Owner.Name;
        }

        private void displaySelectedEventPicture()
        {
            if (EventsListBox.SelectedItems.Count == 1)
            {
                Event selectedEvent = EventsListBox.SelectedItem as Event;

                if (selectedEvent.PictureNormalURL != null)
                {
                    SelectedEventPictureBox.LoadAsync(selectedEvent.PictureNormalURL);
                }
            }
        }

        private void selectsPartnerButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            this.Hide();

            if (r_PartnerSignForm.ShowDialog() == DialogResult.OK)
            {
                m_UserPartnerSign = r_PartnerSignForm.PartnerSign;
                this.Show();
                if (m_UserPartnerSign != null)
                {
                    showDescriptionOnMatch();
                }
                else
                {
                    MessageBox.Show(
@"You didn't choose your partner sign,
Please try again.",
                  "Error");
                }
            }
        }

        private void showDescriptionOnMatch()
        {
            HoroscopeTextBox.Text = m_UserZodiacSign.SetWebUrlBySignAndGetDescriptionOnMatch(m_UserPartnerSign);
        }

        private void getMathcesButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            List<string> userMatches = m_UserZodiacSign.MatchPartners;
            StringBuilder textToShow = new StringBuilder();

            textToShow.AppendLine("Your matches zodiac signs are:");
            foreach(string sign in userMatches)
            {
                textToShow.AppendLine(sign);
            }

            HoroscopeTextBox.Text = textToShow.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeUILabel.Text = DateTime.Now.ToLongTimeString();
            Timer.Start();
        }
    }
}