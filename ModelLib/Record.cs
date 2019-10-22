using System;

namespace ModelLib
{
    public class Record
    {
        private string _title;
        private string _artist;
        private double _duration;
        private int _yearOfPublication;
        private string _album;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Artist
        {
            get => _artist;
            set => _artist = value;
        }

        public double Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public int YearOfPublication
        {
            get => _yearOfPublication;
            set => _yearOfPublication = value;
        }

        public string Album
        {
            get => _album;
            set => _album = value;
        }

        public Record()
        {
            
        }

        public Record(string title, string artist, double duration, int yearOfPublication, string album)
        {
            _title = title;
            _artist = artist;
            _duration = duration;
            _yearOfPublication = yearOfPublication;
            _album = album;
        }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title}, {nameof(Artist)}: {Artist}, {nameof(Duration)}: {Duration}, {nameof(YearOfPublication)}: {YearOfPublication}, {nameof(Album)}: {Album}";
        }

        public override bool Equals(object obj)
        {
            if (obj != null &&((Record)obj).Title == Title && ((Record)obj).Artist == Artist && ((Record)obj).Duration == Duration && ((Record)obj).YearOfPublication == YearOfPublication && ((Record)obj).Album == Album)
            {
                return true;
            }

            return false;
        }
    }
}
