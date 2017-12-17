using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace MyFacebookApp
{
    public static class SortingAndCopyService
    {
        public static List<User> SortFriendsByFirstName(FacebookObjectCollection<User> i_Friends)
        {
            List<User> friends = CopyFriendsToList(i_Friends);

            friends.Sort(delegate(User frined1, User frined2) { return frined1.Name.CompareTo(frined2.Name); });

            return friends;
        }

        public static List<User> SortFriendsByLastName(FacebookObjectCollection<User> i_Friends)
        {
            List<User> friends = CopyFriendsToList(i_Friends);

            friends.Sort(delegate(User frined1, User frined2) { return frined1.LastName.CompareTo(frined2.LastName); });

            return friends;
        }

        public static List<Page> SortPages(FacebookObjectCollection<Page> i_Pages)
        {
            List<Page> pages = CopyPagesToList(i_Pages);
            
            pages.Sort(delegate(Page page1, Page page2) { return page1.Name.CompareTo(page2.Name); });

            return pages;
        }

        public static List<Album> SortAlbums(FacebookObjectCollection<Album> i_Albums)
        {
            List<Album> albums = CopyAlbumsToList(i_Albums);

            albums.Sort(delegate(Album album1, Album album2) { return album1.Name.CompareTo(album2.Name); });

            return albums;
        }

        public static List<Page> CopyPagesToList(FacebookObjectCollection<Page> i_CopyFromPages)
        {
            List<Page> copyPagesList = new List<Page>();

            foreach (Page page in i_CopyFromPages)
            {
                copyPagesList.Add(page);
            }

            return copyPagesList;
        }

        public static List<User> CopyFriendsToList(FacebookObjectCollection<User> i_CopyFromFriends)
        {
            List<User> copyFriendsList = new List<User>();

            foreach (User friend in i_CopyFromFriends)
            {
                copyFriendsList.Add(friend);
            }

            return copyFriendsList;
        }

        public static List<Album> CopyAlbumsToList(FacebookObjectCollection<Album> i_CopyFromAlbums)
        {
            List<Album> copyAlbumsList = new List<Album>();

            foreach (Album album in i_CopyFromAlbums)
            {
                copyAlbumsList.Add(album);
            }

            return copyAlbumsList;
        }
    }
}