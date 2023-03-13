namespace Interactive_Quiz_By_Gurbir;

public partial class MainPage : ContentPage
{
	private Quiz quiz;
	private Question currentQuestion;

	public MainPage()
	{
		InitializeComponent();
		quiz = new Quiz("My quiz");
		currentQuestion = quiz.GetNextQuestion();
		ShowQuestion();
	}

	private void ShowQuestion()
	{
		
		quizTitle.Text = quiz.Title;
		quizQuestion.Text = currentQuestion.QuestionText;
		
		if (currentQuestion is TrueFalseQuestion tfq)
		{
			answerButton1.Text = "True";
			answerButton2.Text = "False";
			answerButton3.IsVisible = false;
            answerButton4.IsVisible = false;
        }
		else if(currentQuestion is MultipleChoiceQuestion mcq)
		{
			answerButton1.Text = mcq.Choices[0];
            answerButton2.Text = mcq.Choices[1];
            answerButton3.Text = mcq.Choices[2];
            answerButton4.Text = mcq.Choices[3];
            answerButton3.IsVisible = true;
            answerButton4.IsVisible = true;
        }
    }

	private void OnAnswerButtonClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		string userAnswer = button.Text;

		quiz.CheckUserAnswer(currentQuestion, userAnswer);

		if (currentQuestion.CorrectAnswer.Equals(userAnswer, StringComparison.OrdinalIgnoreCase))
		{
			
		}
		else
		{
            
        }
		
    }

	private void OnNextQuestionClicked(object sender, EventArgs e)
	{
		currentQuestion = quiz.GetNextQuestion();

		if(currentQuestion == null)
		{
			DisplayScore();
		}
		else
		{
			ResetButtonColors();
			ShowQuestion();
		}
	}

	private void OnQuitButtonClicked(object sender, EventArgs e)
	{

		DisplayScore();

	}

	private void DisplayScore()
	{
		int totalQuestions = quiz.GetTotalNumberOfQuestions();
		string message = $"You got {quiz.Score} correct answers out of {totalQuestions}";
		DisplayAlert("Quiz Score", message, "OK");
	}

	private void ResetButtonColors()
	{
	
    }


}
    



