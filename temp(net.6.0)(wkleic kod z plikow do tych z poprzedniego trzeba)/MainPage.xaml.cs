namespace Programowanie_w_parach_main_v2
{ 
    public partial class MainPage : ContentPage
    {
        public readonly List<string> moodHistory = new();
        public List<string> moodHistory2 = new();

        public readonly Dictionary<string, int> moodValues = new()
        {
            { "Okropny", -2 },
            { "Zły", -1 },
            { "Średni", 0 },
            { "Dobry", 1 },
            { "Fantastyczny", 2 }
        };
        public Dictionary<int, string[]> moodToQuote = new()
        {
            {   -2,
                new string[]
                {
                    "Jeden krok naraz, jedna góra, jedno zadanie, jeden oddech. Nie przestawaj, a dojdziesz.",
                    "W zyciu wygrywa, ten kto pokonal samego siebie, swoj strach, swoje lenistwo, swoja niesmialosc ...",
                    "Kiedy wydaje sie, ze caly swiate jest preciwko tobie, pamietaj, ze samolot startuje pod wiatr!"
                }
            },
            {   -1,
                new string[]
                {
                    "Jesli Bog cie do czegos prowadzi to da ci tez sile, zebys mogl to zrealizowac",
                    "Kazdy nowy dzien zaczyna sie gleboka noca.",
                    "Gdy gniew wzrasta, myśl o konsekwencjach"
                }
            },
            {   0,
                new string[]
                { 
                    "Kieruj swe oczy na ten wlasnie dzien, bo on jest zycia istota.",
                    "Wczoraj niczym innym jak snem, a jutro tylko wizja.",
                    "Nerwy to konserwy"
                }
            },
            {   1,
                new string[]
                {
                    "Najważniejszą decyzją, jaką podejmujesz, jest bycie w dobrym nastroju",
                    "This is kinda Positive2",
                    "This isn't Positive4 cause its kinda Positive3"
                }
            },
            {   2,
                new string[]
                {
                    "This is Positive1",
                    "This is Positive2",
                    "This isn't Positive4 cause its Positive3"
                }
            }

        };
        

        public MainPage()
        {
            InitializeComponent();
        }

        public void OnSaveMoodClicked(object sender, EventArgs e)
        {

            if (MoodPicker.SelectedIndex == -1)
            {
                DisplayAlert("Błąd", "Wybierz nastrój przed zapisem.", "OK");
                return;
            }

            string selectedMood = (string)MoodPicker.SelectedItem;
            moodHistory.Add(selectedMood);
            moodHistory2.Add(selectedMood);
            if (moodHistory.Count > 5)
                moodHistory.RemoveAt(0);

            UpdateMoodTrend();
            UpdateMoodHistory();
            UpdateQuotes();
        }

        public void UpdateMoodTrend()
        {
            int trend = 0;
            foreach (var mood in moodHistory)
                trend += moodValues[mood];

            string trendText = trend switch
            {
                < -5 => "Trend: Bardzo negatywny",
                >= -5 and < 0 => "Trend: Negatywny",
                0 => "Trend: Neutralny",
                > 0 and <= 5 => "Trend: Pozytywny",
                > 5 => "Trend: Bardzo pozytywny"
            };
            TrendLabel.Text = trendText;
        }
        public void UpdateMoodHistory()
        {
            MoodHistoryLabel.Text = string.Join(", ", moodHistory2);
        }
        public void UpdateQuotes()
        {
            Random rnd = new();
            string selectedMood = (string)MoodPicker.SelectedItem;
            var selectedValue = moodValues[selectedMood];
            var moodQoutePair = moodToQuote[selectedValue];
            Quotes.Text = moodQoutePair[rnd.Next(moodQoutePair.Length)];
            
        }
    }
}

