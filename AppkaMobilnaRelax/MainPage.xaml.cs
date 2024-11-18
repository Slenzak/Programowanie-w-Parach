namespace AppkaMobilnaRelax
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
	}
}
